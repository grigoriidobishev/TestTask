using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    static class MeetManager
    {
        static List<Meet> _meets = new List<Meet>()
        {
            new Meet(0, "Собрание 1", DateTime.Now.AddMinutes(3), DateTime.Today.AddDays(2), 2),
            new Meet(1, "Собеседование", DateTime.Today.AddDays(3), DateTime.Today.AddDays(4),10),
            new Meet(2, "Собрание 2", DateTime.Today.AddDays(5), DateTime.Today.AddDays(6),60),
            new Meet(3, "Встреча с Систем-Консалт", DateTime.Today.AddDays(7), DateTime.Today.AddDays(8),120),
            new Meet(4, "Встреча с центром занятости", DateTime.Today.AddDays(9), DateTime.Today.AddDays(10),140)
        };

        static public void AddMeet(string name, string startTime, string endTime, string notifyTime)
        {
            int min = 0;

            int.TryParse(notifyTime, out min);
            Meet newMeet;
            if (_meets.Count>0)
            newMeet = new Meet(_meets.Last().GetId() + 1, name, FromStringToDateTime(startTime), FromStringToDateTime(endTime), min);
            else newMeet = new Meet(1, name, FromStringToDateTime(startTime), FromStringToDateTime(endTime), min);
            Validate(newMeet);
            _meets.Add(newMeet);
        }
        static public bool CheckForTimeCollision(DateTime startTime, DateTime endTime, int id)
        {
            foreach(var meet in _meets)
            {
                if (Math.Max(meet.GetStartTime().Ticks, startTime.Ticks) <= Math.Min(meet.GetEndTime().Ticks, endTime.Ticks)) {
                    if(meet.GetId()!=id)  return true; 
                }
            }
            return false;
        }
        static private void EditMeet(int id, string name, DateTime startTime, DateTime endTime, int min=0)
        {
            Meet newMeet = new Meet(_meets.Last().GetId() + 1, name, startTime, endTime, min);
            Validate(newMeet, id);
            if(_meets.ElementAt(id)==null)
            {
                throw new Exception("This meet is null");
            }
            _meets.Where(x => x.GetId() == id).First().NotifyOff();
            _meets[_meets.IndexOf(_meets.Where(x => x.GetId() == id).First())] = new Meet(id, name, startTime, endTime, min);
        }
        static public void RemoveMeet(int id)
        {
            if (_meets.Where(x=>x.GetId()==id).First() == null)
            {
                throw new Exception("This meet is null");
            }
            _meets.Remove(_meets.Where(x => x.GetId() == id).First());
        }
        static public void Validate(Meet meet, int id=-1)
        {
            if (CheckForTimeCollision(meet.GetStartTime(), meet.GetEndTime(), id))
            {
                throw new Exception("Данная встреча пересекается с другой встречей");
            }
            if (meet.GetStartTime() > meet.GetEndTime())
            {
                throw new Exception("Время начала должно быть раньше времени окончания");
            }
            if (meet.GetStartTime() < DateTime.Now)
            {
                throw new Exception("Встреча должна быть в будущем");
            }
        }
        static public List<Meet> GetMeets()
        {
            return _meets;
        }
        static public int Count()
        {
            return _meets.Count();
        }

        static private DateTime FromStringToDateTime(string value)
        {
            try
            {
                return DateTime.ParseExact(value, "yyyy-MM-dd HH:mm",
                                           System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                throw new Exception("Некорекктная дата");
            }
        }

        static private DateTime FromStringToDate(string value)
        {
            try
            {
                return DateTime.ParseExact(value, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                throw new Exception("Некорекктная дата");
            }
        }
        static public Meet GetMeetAt(int num)
        {
            return _meets.ElementAt(num - 1);
        }

        static public void EditName(Meet meet, string name)
        {
            EditMeet(meet.GetId(), name, meet.GetStartTime(), meet.GetEndTime());
        }
        static public void EditStartTime(Meet meet, string time)
        {
            EditMeet(meet.GetId(), meet.GetName(), FromStringToDateTime(time), meet.GetEndTime());
        }
        static public void EditEndTime(Meet meet, string time)
        {
            EditMeet(meet.GetId(), meet.GetName(), meet.GetStartTime(), FromStringToDateTime(time));
        }
        static public void EditNotifyTime(Meet meet, string notifyTime)
        {
            int min = 0;
            int.TryParse(notifyTime, out min);
            EditMeet(meet.GetId(), meet.GetName(), meet.GetStartTime(), meet.GetEndTime(), min);
        }
        static public List<Meet> GetMeetsOfDays(string startPeriod, string endPeriod)
        {
            return _meets.Where(x => x.GetStartTime().Date >= FromStringToDate(startPeriod) && x.GetStartTime().Date <= FromStringToDate(endPeriod)).ToList();
        }
        static public List<Meet> GetMeetsOfDay(string day)
        {
            return GetMeetsOfDays(day, day);
        }
    }
}
