using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tfl.RoadStatus.Core.ConsoleHost;

namespace Tfl.RoadStatusApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //comment added
            if (args.Length > 0)
            {
                var consoleClient = new RoadStatusConsoleClient();
                consoleClient.Run(args[0]);
            }
        }
    }
}
