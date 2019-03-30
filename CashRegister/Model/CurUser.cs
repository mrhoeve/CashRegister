using CashRegister.DAL;
using CashRegister.DataModels;
using System;
using System.Linq;
using System.Timers;
using CashRegister.Enum;

namespace CashRegister.Model
{
    public sealed class CurUser
    {
        // Make sure we only get one instance of this class
        // See https://stackoverflow.com/questions/6320393/how-to-create-a-class-which-can-only-have-a-single-instance-in-c-sharp
        public static readonly CurUser curUser = new CurUser();
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private Persoon _persoon { get; set; }
        private SysteemGebruiker _systeemGebruiker { get; set; }
        private TimeSpan _timerInterval { get; set; }
        private Timer _timer;
        private IDatabaseContext _context;

        // Constructor, hidden because we only want one instance
        private CurUser()
        {
            // Make sure we begin with nothing
            _persoon = new Persoon();
            _systeemGebruiker = new SysteemGebruiker();
            // Setup the timer
            _timer = new Timer();
            _timerInterval = TimeSpan.FromMinutes(5);
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = false;
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
            logger.Info($"User {_persoon.GetVolledigeNaam(NameOrder.Firstname)} logged out.");
            _persoon = new Persoon();
            _systeemGebruiker = new SysteemGebruiker();

        }

        public bool isLoggedIn()
        {
            if(_timer.Enabled) _timer.Reset();
            return (_persoon.Id != 0 && _systeemGebruiker.PersoonId != 0);
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
            }
        }

        private void StopTimer()
        {
            if (_timer.Enabled)
            {
                _timer.Stop();
            }
        }

        // When the timer goes, we automatically log the current user out
        private static void OnTimedEvent(object source, ElapsedEventArgs e) =>
            curUser.LogOut();

        #endregion

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
