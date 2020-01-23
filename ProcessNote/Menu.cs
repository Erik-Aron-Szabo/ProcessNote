using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProcessNote
{
    class Menu
    {
        public static void displayMenu()
        {
            Console.WriteLine("");
            while (!Console.KeyAvailable)
            {
                Console.WriteLine("Main Menu:");
                Console.WriteLine("(1) List processes");
                Console.WriteLine("(2) List process attributes");
                Console.WriteLine("(3) CPU usage");
                Console.WriteLine("(0) Exit program");

                int userChoice = Int32.Parse(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        Menu.ListProcesses();
                        break;

                    case 2:
                        Menu.listProcAttribute();
                        break;

                    case 3:
                        CalcCPU.CalculateCpu();
                        break;

                    case 0:
                        Menu.Exit();
                        break;

                }
            }
        }
        public static void listProcAttribute()
        {
            Console.WriteLine("Name of attribute: ");
            string procName = Console.ReadLine();

            List<Pattributes> attributeList = new List<Pattributes>();
            foreach (var atr in Process.GetProcessesByName(procName))
            {
                try
                {                                           //CPU usage MISSING
                    Pattributes a = new Pattributes(atr.WorkingSet64, atr.TotalProcessorTime, atr.StartTime);
                    attributeList.Add(a);
                    CalcCPU calcCPU2 = new CalcCPU();

                    Console.WriteLine("INFO:CPU:{3}, Memory Usage:{0}, Processor Time:{1}, Star Time:{2}", atr.WorkingSet64, atr.TotalProcessorTime, atr.StartTime);

                }
                catch (System.ComponentModel.Win32Exception)
                {

                    Console.WriteLine("Acess Denied!");
                }

            }


        }



        public static void Comment(List<ProgramProcess> processlist)
        {
            Console.WriteLine("PID of attribute: ");
            int searchPID = Int32.Parse(Console.ReadLine());
            ProgramProcess searchedProcess = null;
            foreach (ProgramProcess item in processlist)
            {
                if (item.PID == searchPID)
                {
                    searchedProcess = item;
                }

            }

            if (searchedProcess == null)
            {
                Console.WriteLine("No such process, invalid ID: " + searchPID);
            }
            else
            {
                Console.WriteLine("Type comment you would like to add: ");
                string comment = Console.ReadLine();
                searchedProcess.Comment = comment;
            }
        }



        public static void ListProcesses()
        {

            List<ProgramProcess> processlist = new List<ProgramProcess>();

            foreach (var proc in Process.GetProcesses())
            {
                try
                {                                           //CPU usage MISSING
                    ProgramProcess p = new ProgramProcess(proc.ProcessName, proc.Id);
                    processlist.Add(p);
                    Console.WriteLine("INFO: Name:{0}, PID:{1}", proc.ProcessName, proc.Id);

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
            using (FileStream destream = File.OpenRead("CD1.xml"))
            {
                deserializedProcesses = (List<ProgramProcess>)serializer.Deserialize(destream);
            }

            foreach (var item in deserializedProcesses) //PID+Name
            {
                Console.WriteLine("INFO: Name:{0}, PID:{1}", item.Name, item.PID);

            }



        }

        public static void Exit()
        {
            Environment.Exit(0);
        }


    }
}
