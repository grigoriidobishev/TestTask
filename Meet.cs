using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class Meet
    {
        private int _id;
        private string _name;
        private DateTime _timeStart;
        private DateTime _timeEnd;
        public Notify notify;

        public Meet(int id, string name, DateTime timeStart, DateTime timeEnd, int min)
        {
            _id = id;
            _name = name;
            _timeStart = timeStart;
            _timeEnd = timeEnd;
            if (min != 0)
            {
                notify = new Notify(timeStart.AddMinutes(-min));
                notify.Alarm += (sender, e) => Console.WriteLine("Встреча " + name + " начнется через "+ min +" минут!!");
            }
        }
        public int GetId()
        {
            return _id;
        }
        public DateTime GetStartTime()
        {
            return _timeStart;
        }
        public DateTime GetEndTime()
        {
            return _timeEnd;
        }
        public string GetName()
        {
            return _name;
        }
        public string GetTimeNotif()
        {
            if (notify == null) return "нет";
            return notify.GetTime().ToString();
        }
        public void NotifyOff()
        {
            if(notify!=null)
            notify.Enabled = false;
        }
        
    }
}
