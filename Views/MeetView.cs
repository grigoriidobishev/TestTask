using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Controllers;

namespace TestTask
{
    class MeetView : View
    {
        private Meet _meet;
        public MeetView()
        {
        }
        public MeetView(Meet meet)
        {
            
            _meet = meet;
        }

        public override void SetContent()
        {
            Content = new Dictionary<string, string>()
            {
                {
                    "Название", _meet.GetName()
                },
                {
                    "Начало", _meet.GetStartTime().ToString()
                },
                {
                    "Конец", _meet.GetEndTime().ToString()
                },
                {
                    "Напоминание", _meet.GetTimeNotif()
                }
            };
        }

        public override void SetController()
        {
            controller = new MeetViewController(_meet);
        }

        public override void SetHeader()
        {
            Header = "Встреча";
        }

        public override void SetOptions()
        {
            Options = new Dictionary<string, string>()
            {
                {
                    "1", "Изменить название"
                },
                {
                    "2", "Изменить время начала"
                },
                {
                    "3", "Изменить время окончания"
                },
                {
                    "4", "Изменить время напоминания"
                },
                {
                    "5", "Удалить"
                },
                {
                    "6", "Назад"
                }
            };
        }

    }
}
