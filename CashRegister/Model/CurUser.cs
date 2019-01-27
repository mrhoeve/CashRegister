using CashRegister.DAL;
using CashRegister.DataModels;
using System;
using System.Timers;
using System.Linq;

namespace CashRegister.Model
{
    public sealed class CurUser : IDisposable
    {
        // Make sure we only get one instance of this class
        // See https://stackoverflow.com/questions/6320393/how-to-create-a-class-which-can-only-have-a-single-instance-in-c-sharp
        public static readonly CurUser curUser = new CurUser();

        private Persoon _persoon { get; set; }
        private SysteemGebruiker _systeemGebruiker { get; set; }
        private TimeSpan _timerInterval { get; set; }
        private Timer _timer;

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
        public void LogIn(Persoon p, string password)
        {
            // When we get a login request, we automatically log the current user out
            LogOut();
            // Do we have a valid Persoon
            if (p == null) return;
            // Check the credentials
            using (var dbcontext = new databaseContext())
            {
                SysteemGebruiker systeemGebruiker = dbcontext.SysteemGebruiker.Where(s => s.GebruikerId == p.Id).SingleOrDefault();
                // systeemGebruiker is null or the password is incorrect
                if (systeemGebruiker == null || !systeemGebruiker.isPasswordCorrect(password)) return;
                _persoon = p;
                _systeemGebruiker = systeemGebruiker;
                StartTimer();
            }
        }

        public void LogOut()
        {
            StopTimer();
            _persoon = new Persoon();
            _systeemGebruiker = new SysteemGebruiker();

        }
        public void Dispose()
        {
            StopTimer();
            _timer.Dispose();
            curUser.Dispose();
        }
        #endregion

        #region "Timer functions"
        private void SetTimerInterval(TimeSpan newInterval)
        {
            this._timerInterval = newInterval;
        }

        private void StartTimer()
        {
            if(!_timer.Enabled)
            {
                _timer.Interval = _timerInterval.TotalMilliseconds;
                _timer.Enabled = true;
            }
        }

        private void StopTimer()
        {
            if(_timer.Enabled)
            {
                _timer.Stop();
            }
        }

        // When the timer goes, we automatically log the current user out
        private static void OnTimedEvent(object source, ElapsedEventArgs e) =>
            curUser.LogOut();

        #endregion
    }
}
