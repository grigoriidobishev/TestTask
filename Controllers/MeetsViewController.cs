using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Views;

namespace TestTask.Controllers
{
    class MeetsViewController : Controller
    {
        List<Meet> _meets;

        public MeetsViewController(List<Meet> meets)
        {
            _meets = meets;
        }

        public override void SetCommands()
        {
            Commands = new Dictionary<string, Action>()
            {
                {
                    "q",
                    () =>
                    {
                        string name = ViewManager<InputDataView>.ShowAndGet("Введите название встречи");
                        string dateStart = ViewManager<InputDataView>.ShowAndGet("Введите время начала встречи в формате yyyy-MM-dd HH:mm");
                        string dateEnd = ViewManager<InputDataView>.ShowAndGet("Введите время окончания встречи в формате yyyy-MM-dd HH:mm");
                        string notifyTime = ViewManager<InputDataView>.ShowAndGet("Введите за сколько минут напомнить (необязательно)");

                            MeetManager.AddMeet(name, dateStart, dateEnd, notifyTime);
                            ViewManager<MeetsView>.Show();
                        


                    }
                },
                {
                    "w",
                    () =>
                    {
                        string input = ViewManager<InputDataView>.ShowAndGet("Введите дату в формате yyyy-MM-dd");
                        ViewManager<MeetsView>.Show(input);
                    }
                },
                {
                    "e",
                    () =>
                    {
                        string fileName = ViewManager<InputDataView>.ShowAndGet("Введите название файла");
                        try
                        {
                            ExportHelper.Export(_meets, fileName);
                        }catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.Read();
                        }
                        
                        ViewManager<MainView>.Show();
                    }
                },
                {
                    "r",
                    () =>
                    {
                        ViewManager<MainView>.Show();
                    }
                }

            };
            for(int i=0;i<MeetManager.Count(); i++)
            {
                var curIndex = i+1;
                Commands.Add((curIndex).ToString(), () =>
                {
                    ViewManager<MeetView>.Show(MeetManager.GetMeetAt(curIndex));
                });
            }
        }
    }
}
