using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



namespace ProcessNote
{
    class MyProcess
    {
        void BindToRunningProcess()
        {
            System.Diagnostics.Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();
            Console.WriteLine(currentProcess);

        }

        static void Print()
        {

        }
        
    }
}
