using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckExampleVZ.Helpers
{
    public class CustomLogger
    {
        public readonly List<string> logs;

        public CustomLogger()
        {
            logs = new List<string>();
        }

        public void WriteLog(string message)
        {
            logs.Add(message);
            System.Diagnostics.Debug.WriteLine("#### LOGGER ### -> " + message);
        }
    }
}
