using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Diagnostics;

namespace ProcessNote
{
    [Serializable()] //internal
    public class ProgramProcess : ISerializable
    {
        public string Name { get; set; }
        public int PID { get; set; }
        public string  Comment { get; set; }

        public ProgramProcess()
        {
        }

        public ProgramProcess(string name, int pid, string comment ="")
        { 
            Name = name;
            PID = pid;
            Comment = comment;
        }

        public void GetObjectData(SerializationInfo info, 
            StreamingContext context)
        {
            info.AddValue("", Name);
            info.AddValue("", PID);
        }


        internal static IEnumerable<object> GetProcesses()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }

    
}
