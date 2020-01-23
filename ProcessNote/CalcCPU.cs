using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace ProcessNote
{
    class CalcCPU
    {
        private static DateTime lastTime;
        private static TimeSpan lastTotalProcessorTime;
        private static DateTime curTime;
        private static TimeSpan curTotalProcessorTime;

        public static  void CalculateCpu() //copied it, but I understand it nagyjabol
        {
            Console.WriteLine("Please type the process' name: ");
            string processName = Console.ReadLine();
            Console.WriteLine("Press any button to stop!\n");

            while (!Console.KeyAvailable)
            {
                Process[] pp = Process.GetProcessesByName(processName);
                if (pp.Length == 0)
                {
                    Console.WriteLine(processName + "Please type another process' name!");
                }
                else
                {
                    Process p = pp[0];
                    if (lastTime == null || lastTime == new DateTime())
                    {
                        lastTime = DateTime.Now;
                        lastTotalProcessorTime = p.TotalProcessorTime;
                    }
                    else
                    {
                        curTime = DateTime.Now;
                        curTotalProcessorTime = p.TotalProcessorTime;

                        double CPUUsage = (curTotalProcessorTime.TotalMilliseconds - lastTotalProcessorTime.TotalMilliseconds) / curTime.Subtract(lastTime).TotalMilliseconds / Convert.ToDouble(Environment.ProcessorCount);
                        Console.WriteLine("{0} CPU: {1:0.0}%", processName, CPUUsage*100);

                        lastTime = curTime;
                        lastTotalProcessorTime = curTotalProcessorTime;
                    }
                }
                Thread.Sleep(700);
            }


        }





    }




}
