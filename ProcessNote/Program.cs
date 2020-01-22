using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Diagnostics;

namespace ProcessNote
{
    class Program
    {
        static void Main(string[] args)
        {


            ///////////////////////////////////////////////////////////////

            PerformaceCounterCategory





            List<ProgramProcess> processlist = new List<ProgramProcess>();

            foreach (var proc in Process.GetProcesses())
            {
                try
                {                                           //CPU usage MISSING
                    ProgramProcess p = new ProgramProcess(proc.ProcessName, proc.Id, proc.WorkingSet64, proc.TotalProcessorTime, proc.StartTime);
                    processlist.Add(p);
                    Console.WriteLine("INFO: Name:{0}, PID:{1}, Memory Usage:{2}, Running Time:{3}, Start Time:{4}", proc.ProcessName, proc.Id, proc.WorkingSet64, proc.TotalProcessorTime, proc.StartTime);

                }
                catch (System.ComponentModel.Win32Exception)
                {

                    Console.WriteLine("Acess Denied!");
                }      
                
            }



            //////////////////////////////////////////////////////////////////////
            XmlSerializer serializer = new XmlSerializer(typeof
           (List<ProgramProcess>));
            using (TextWriter tw = new StreamWriter("CD1.xml"))
            {
                serializer.Serialize(tw, processlist);
            }

            Console.WriteLine("//////////////////");

            List<ProgramProcess> deserializedProcesses = new List<ProgramProcess>();
            using(FileStream destream = File.OpenRead("CD1.xml"))
            {
                deserializedProcesses = (List<ProgramProcess>)serializer.Deserialize(destream);
            }

            foreach (var item in deserializedProcesses)
            {
                Console.WriteLine("INFO: Name:{0}, PID:{1}, Memory Usage:{2}, Running Time:{3}, Start Time:{4}", item.Name, item.PID, item.Memory, item.ProcTime, item.StartTime);

            }


        }


    }
}
