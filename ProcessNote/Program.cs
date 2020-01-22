using System;
using System.Collections.Generic;
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
           
            ProgramProcess browser = new ProgramProcess("Name1", 10);
            Stream stream = File.Open("ComputerData.xml",
                FileMode.Create);

            stream.Close();

            stream = File.Open("ComputerData.xml", FileMode.Open);


            Console.WriteLine(browser.ToString());
 ///////////////////////////////////////////////////////////////




           


            var allProcesses = System.Diagnostics.Process.GetProcesses();
            List<ProgramProcess> processlist = new List<ProgramProcess>();

            foreach (var proc in Process.GetProcesses())
            {
                ProgramProcess p = new ProgramProcess(proc.ProcessName, proc.Id);
                processlist.Add(p);
            }



            //////////////////////////////////////////////////////////////////////
                XmlSerializer serializer = new XmlSerializer(typeof
               (List<ProgramProcess>));
                using (TextWriter tw = new StreamWriter("CD1.xml"))
                {
                    serializer.Serialize(tw, processlist);
                }

                //browser = null;

                XmlSerializer deserializer = new XmlSerializer(typeof(ProgramProcess));
                TextReader reader = new StreamReader("CD1.xml");

                object obj = deserializer.Deserialize(reader);
                processlist = (ProgramProcess)obj;
                reader.Close();
             
            
            Console.WriteLine(processlist.ToString());

            List<ProgramProcess> Processes = new List<ProgramProcess>();
            XmlSerializer serializer2 = new XmlSerializer(typeof(List<ProgramProcess>));



            using (TextWriter writer = new StreamWriter("CD1.xml"))
            {
                serializer2.Serialize(writer, processlist);
            }
            processlist = null;

            //XmlSerializer serializer3 = new XmlSerializer(typeof(List<Process>));
            //using(FileStream fs2 = File.OpenRead(@"C:\CSharp\Week2\TW\ProcessNote\ProcessNote\CompData.xml"))
            //{
            //    theAnimals = (List<Process>)serializer3.Deserialize
            //        (fs2);
            //}
            

        }

        //private static void ShowLargeFilesWithLinq(string path)
        //{
        //    var query = from file in new DirectoryInfo(path).GetFiles()
        //                orderby file.Length descending
        //                select file;
        //    foreach (var file in query.Take(5))
        //    {
        //        Console.WriteLine($"{file.Name, -20} : {file.Length, 10:N0}");
        //    }

        //}

        
    }
}
