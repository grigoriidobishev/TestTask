using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Views;

namespace TestTask.Controllers
{
    class MeetViewController : Controller
    {
        private Meet _meet;
        public MeetViewController(Meet meet)
        {
            _meet = meet;
        }

    public override void SetCommands()
        {
            Commands = new Dictionary<string, Action>()
            {
                {
                    "1",
                    () =>
                    {
                        string value = ViewManager<InputDataView>.ShowAndGet("Введите новое название");
                        MeetManager.EditName(_meet, value);
                        ViewManager<MeetsView>.Show();
                    }
                },
                {
                    "2",
                    () =>
                    {
                        string dateStart = ViewManager<InputDataView>.ShowAndGet("Введите новое время начала встречи в формате yyyy-MM-dd HH:mm");
                        MeetManager.EditStartTime(_meet, dateStart);
                        ViewManager<MeetsView>.Show();
                    }
                },
                {
                    "3",
                    () =>
                    {
                        string dateEnd = ViewManager<InputDataView>.ShowAndGet("Введите новое время окончания встречи в формате yyyy-MM-dd HH:mm");
                        MeetManager.EditEndTime(_meet, dateEnd);
                        ViewManager<MeetsView>.Show();
                    }
                },
                {
                    "4",
                    () =>
                    {
                        string min = ViewManager<InputDataView>.ShowAndGet("Введите за какое количество минут напомнить");
                        MeetManager.EditNotifyTime(_meet, min);
                        ViewManager<MeetsView>.Show();
                    }
                },
                {
                    "5",
                    () =>
                    {
                        MeetManager.RemoveMeet(_meet.GetId());
                        ViewManager<MeetsView>.Show();
                    }
                },
                {
                    "6",
                    () =>
                    {
                        ViewManager<MeetsView>.Show();
                    }
                }

            };
        }
    }
}
