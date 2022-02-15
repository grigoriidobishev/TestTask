using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Controllers;

namespace TestTask
{
    class MeetsView : View
    {
        string _date="";
        List<Meet> _meets = new List<Meet>();
        public MeetsView()
        {
            
        }
        public MeetsView(string date)
        {
            _date = date;
        }
        public override void SetContent()
        {
            Content = new Dictionary<string, string>();
            if (_date != "")
            {
                try
                {
                    for (int i = 0; i < MeetManager.GetMeetsOfDay(_date).Count(); i++)
                    {
                        Content.Add((i + 1).ToString(), MeetManager.GetMeetsOfDay(_date)[i].GetName());
                        _meets.Add(MeetManager.GetMeetsOfDay(_date)[i]);
                    }
                }
                catch
                {
                    throw new Exception("Некорректная дата");
                }
            }
            else
            {
                for (int i = 0; i < MeetManager.Count(); i++)
                {
                    Content.Add((i + 1).ToString(), MeetManager.GetMeetAt(i + 1).GetName());
                    _meets.Add(MeetManager.GetMeetAt(i + 1));
                }
            }

        }

        public override void SetController()
        {
            controller = new MeetsViewController(_meets);
        }

        public override void SetHeader()
        {
            Header = "Ваши встречи";
        }

        public override void SetOptions()
        {
            Options = new Dictionary<string, string>()
            {
                {
                    "q", "Создать встречу"
                },
                {
                    "w", "Встречи за определенную дату"
                },
                {
                    "r", "Назад"
                },
                {
                    "1-"+MeetManager.Count(), "Выбрать встречу"
                }
            };
            if (_date != "")
            {
                Options.Add("e", "Экспортировать");
            }
        }
    }


    
}
