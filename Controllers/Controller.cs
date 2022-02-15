using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    abstract class Controller
    {
        protected Controller()
        {
            SetCommands();
        }

        public Dictionary<string, Action> Commands { get; set; }

        abstract public void SetCommands();

    }
}
