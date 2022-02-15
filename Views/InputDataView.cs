using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Controllers;

namespace TestTask.Views
{
    class InputDataView : View
    {
        private string _discription;

        public InputDataView()
        {
        }

        public InputDataView(string discription)
        {
            _discription = discription;
        }

        public override void SetContent()
        {
            Content = new Dictionary<string, string>()
            {
                {
                    "1", _discription
                }
            };
        }

        public override void SetController()
        {
            controller = new InputDataViewController();
        }

        public override void SetHeader()
        {
            Header = "Ввод данных";
        }

        public override void SetOptions()
        {
            Options = new Dictionary<string, string>();
        }
    }
}
