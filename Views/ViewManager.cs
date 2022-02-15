using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    static class ViewManager<T> where T: View, new()
    {
        public static void Show()
        {
            Console.Clear();
            var view = new T();
            view.Init();
            view.Show();
            try
            {
                view.CommandListen();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
                ViewManager<MainView>.Show();
            }
            
        }
        public static void Show(params object[] args)
        {
            Console.Clear();
            T view = (T)Activator.CreateInstance(typeof(T), args);
            view.Init();
            view.Show();
            try
            {
                view.CommandListen();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
                ViewManager<MainView>.Show();
            }
        }
        public static string ShowAndGet(params object[] args)
        {
            Console.Clear();
            T view = (T)Activator.CreateInstance(typeof(T), args);
            view.Init();
            view.Show();
            return view.InputValueListener();
        }

    }
}
