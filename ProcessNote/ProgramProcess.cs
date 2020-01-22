using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ProcessNote
{
    [Serializable()] //internal
    public class ProgramProcess : ISerializable
    {
        public string Name { get; set; }
        public int PID { get; set; }
        public int CPU { get; set; }
        public long Memory { get; set; }
        public TimeSpan ProcTime { get; set; }
        public DateTime StartTime { get; set; }

        public ProgramProcess()
        {

        }


        public ProgramProcess(string name, int pid, long memory, TimeSpan time, DateTime start)
        { 
            Name = name;
            PID = pid;
            Memory = memory;
            ProcTime = time;
            StartTime = start;
        }

        public void GetObjectData(SerializationInfo info, 
            StreamingContext context)
        {
            info.AddValue("", Name);
            info.AddValue("", PID);
            info.AddValue("", ProcTime);
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
