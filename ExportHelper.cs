using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    static class ExportHelper
    {
        static public void Export(List<Meet> meets, string filename)
        {
            string writePath =Directory.GetCurrentDirectory()+@"\"+filename+".txt";
            string content = "";
            foreach(var meet in meets)
            {
                content += "Название встречи: " + meet.GetName()+", \t";
                content += "Время начала: " + meet.GetStartTime() + ", \t";
                content += "Время окончания: " + meet.GetEndTime() + ", \t";
                content += "\n";
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(content);
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
