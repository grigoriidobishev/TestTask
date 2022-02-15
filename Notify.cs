﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TestTask
{
    public class Notify
    {
        private EventHandler alarmEvent;
        private Timer timer;
        private DateTime alarmTime;
        public bool Enabled;
        public Notify(DateTime alarmTime)
        {
            this.alarmTime = alarmTime;

            timer = new Timer();
            timer.Elapsed += timer_Elapsed;
            timer.Interval = 1000;
            timer.Start();

            Enabled = true;
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Enabled && DateTime.Now > alarmTime)
            {
                Enabled = false;
                OnAlarm();
                timer.Stop();
            }
        }
        public DateTime GetTime()
        {
            return alarmTime;
        }

        protected virtual void OnAlarm()
        {
            if (alarmEvent != null)
                alarmEvent(this, EventArgs.Empty);
        }


        public event EventHandler Alarm
        {
            add { alarmEvent += value; }
            remove { alarmEvent -= value; }
        }


    }
}
