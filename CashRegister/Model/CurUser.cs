using CashRegister.DAL;
using CashRegister.DataModels;
using CashRegister.Enum;
using NLog;
using System;
using System.Linq;
using System.Timers;

namespace CashRegister.Model
{
    public delegate void CurUserStatusChange(CurUserStatus curUserStatus);

    public sealed class CurUser
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        // Make sure we only get one instance of this class
        // See https://stackoverflow.com/questions/6320393/how-to-create-a-class-which-can-only-have-a-single-instance-in-c-sharp
        private static readonly CurUser _curUser = new CurUser();

        private event CurUserStatusChange curUserStatusChange;
        private Persoon _persoon { get; set; }
        private SysteemGebruiker _systeemGebruiker { get; set; }
        private TimeSpan _timerInterval { get; set; }
        private Timer _timer;
        private DatabaseContext _context;

        // Constructor, hidden because we only want one instance
        private CurUser()
        {
            logger.Trace("CurUser started");
            // Make sure we begin with nothing
            _persoon = null;
            _systeemGebruiker = null;
            // Setup the timer
            _timer = new Timer();
            _timerInterval = TimeSpan.FromMinutes(5);
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = false;
            getContext();
            logger.Debug($"Context: {_context}");
        }

        public static CurUser get()
        {
            return _curUser;
        }

        #region "Public functions"
        public void LogIn(Persoon persoon, string password)
        {
            // When we get a login request, we automatically log the current user out
            LogOut();
            // Do we have a valid context
            if (_context == null) getContext();
            // Do we have a valid Persoon
            if (persoon == null) return;
            // Check the credentials
            Persoon per = _context.Persoon.Where(p => p.Id == persoon.Id).SingleOrDefault();
            if (per == null || per.SysteemGebruiker == null) return;
            SysteemGebruiker systeemGebruiker = per.SysteemGebruiker;
            // systeemGebruiker is null or the password is incorrect
            if (!systeemGebruiker.isPasswordCorrect(password)) return;
            _persoon = persoon;
            _systeemGebruiker = systeemGebruiker;
            logger.Info($"User {_persoon.GetVolledigeNaam(NameOrder.Firstname)} logged in.");
            StartTimer();
        }

        public void LogOut()
        {
            StopTimer();
            if (_persoon != null)
            {
                logger.Info($"User {_persoon.GetVolledigeNaam(NameOrder.Firstname)} logged out.");
            }
            _persoon = null;
            _systeemGebruiker = null;

        }

        public void SubscribeToUserStatusChange(CurUserStatusChange subscriber)
        {
            curUserStatusChange += subscriber;
        }

        public void UnsubscribeFromUserStatusChange(CurUserStatusChange unsubscriber)
        {
            curUserStatusChange -= unsubscriber;
        }

        public bool isLoggedIn()
        {
            if(_timer.Enabled) _timer.Reset();
            return ((_persoon != null && _persoon.Id != 0) && (_systeemGebruiker != null && _systeemGebruiker.PersoonId != 0));
        }

        public Persoon getCurrentUser()
        {
            return _persoon;
        }
        #endregion

        private void getContext() =>
            _context = Context.getInstance().Get();

        #region "Timer functions"
        private void SetTimerInterval(TimeSpan newInterval) =>
            this._timerInterval = newInterval;

        private void StartTimer()
        {
            if (!_timer.Enabled)
            {
                _timer.Interval = _timerInterval.TotalMilliseconds;
                _timer.Enabled = true;
                // Fire event to notify observers of change in status
                curUserStatusChange?.Invoke(new CurUserStatus(true, _persoon));
            }
        }

        private void StopTimer()
        {
            if (_timer.Enabled)
            {
                _timer.Stop();
                // Fire event to notify observers of change in status
                curUserStatusChange?.Invoke(new CurUserStatus(false, null));
            }
        }

        // When the timer goes, we automatically log the current user out
        private static void OnTimedEvent(object source, ElapsedEventArgs e) =>
            _curUser.LogOut();

        #endregion

    }

    public class CurUserStatus
    {
        public bool isLoggedIn { get; }
        public Persoon currentUser { get; }

        public CurUserStatus(bool isLoggedIn, Persoon currentUser)
        {
            this.isLoggedIn = isLoggedIn;
            this.currentUser = currentUser;
        }
    }

    internal static class TimerHelper
    {
        public static void Reset(this Timer timer)
        {
            timer.Stop();
            timer.Start();
        }
    }
}
