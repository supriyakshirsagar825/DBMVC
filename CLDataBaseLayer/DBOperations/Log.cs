using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace CLDataBaseLayer.DBOperations
{
    public sealed class Log : ILog
    {
        private static readonly Lazy<Log> instance = new Lazy<Log>(()=>new Log());
        private Log()
        {

        }
        public static Log GetInstance
        {
            get
            {
                return instance.Value;
            } 
        }
        public void LogException(string msg)
        {

            string path = string.Format("{0}-{1}.log", AppDomain.CurrentDomain.BaseDirectory, "supriya.log");
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(msg);
                    writer.Flush();
                }

                // File.WriteAllText(@"C:\Users\pankaj\Desktop\ASP.NET MVC Projects\WriteText.txt", msg);

                //throw new NotImplementedException();
            }
        }
}
