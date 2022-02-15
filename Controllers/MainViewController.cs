using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class MainViewController : Controller
    {
        public override void SetCommands()
        {
            Commands = new Dictionary<string, Action>()
            {
                {
                    "1",
                    () =>
                    {
                        ViewManager<MeetsView>.Show();
                    }
                },
                {
                    "2",
                    () =>
                    {
                        Environment.Exit(0);
                    }
                }

            };
        }
    }
}
