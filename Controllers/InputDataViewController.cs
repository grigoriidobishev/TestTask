using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Controllers
{
    class InputDataViewController : Controller
    {
        public InputDataViewController()
        {
            
        }
        public override void SetCommands()
        {
            Commands = new Dictionary<string, Action>();
        }

    }
}
