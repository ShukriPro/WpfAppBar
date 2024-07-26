using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBar
{
    public class Log
    {
        private static readonly string filename = string.Format("{0}/simeishub.log", Environment.CurrentDirectory);

        public static void LogMsg(string msg, string level)
        {
            using (StreamWriter writer = new(filename, true))
            {
                if (msg == "")
                {
                    writer.WriteLine("");
                }
                else
                {
                    writer.WriteLine(string.Format("[{0}] [{1}] {2}", System.DateTime.Now, level, msg));
                }
            }
        }
    }
}
