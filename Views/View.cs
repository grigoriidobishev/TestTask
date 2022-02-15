using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    abstract class View
    {
        public Controller controller;
        public string Header;
        public Dictionary<string, string> Content;
        public Dictionary<string, string> Options;

        protected View()
        {
            
        }

        public void Init()
        {
            try
            {
                SetHeader();
                SetContent();
                SetOptions();
                SetController();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
                ViewManager<MainView>.Show();
            }
            
        }

        public void Show()
        {
            Console.WriteLine("***************" + Header + "***************");
            foreach(var item in Content)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
            Console.WriteLine("---------------Меню---------------");
            foreach (var item in Options)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }

        abstract public void SetController();
        virtual public void CommandListen()
        {
            string command = Console.ReadLine();
            
            if (controller.Commands.Keys.Contains(command))
            {
                controller.Commands[command].Invoke();
            }
            else
            {
                Console.WriteLine("Опция не найдена");
                CommandListen();
            }
        }
        virtual public string InputValueListener()
        {
            string inputValue = Console.ReadLine();
            return inputValue;
        }
        abstract public void SetHeader();
        abstract public void SetContent();
        abstract public void SetOptions();


    }
}
