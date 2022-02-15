using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class MainView : View
    {
        
        public MainView()
        {
            
        }

        public override void SetContent()
        {
            Content = new Dictionary<string, string>();
        }

        public override void SetController()
        {
            controller = new MainViewController();
        }

        public override void SetHeader()
        {
            Header = "Главное окно";
        }

        public override void SetOptions()
        {
            Options = new Dictionary<string, string>()
            {
                {
                    "1", "Все мои встречи"
                },
                {
                    "2", "Выход"
                }
            };
        }


    }
}
