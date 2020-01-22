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
        //public DateTime Time { get; set;}
        public ProgramProcess()
        {

        }


        public ProgramProcess(string name, int pid)
        {
            Name = name;
            PID = pid;
        }

        public void GetObjectData(SerializationInfo info, 
            StreamingContext context)
        {
            info.AddValue("", Name);
            info.AddValue("", PID);
            //info.AddValue(0, Time);

        }

        public void Process2(SerializationInfo info,
            StreamingContext context)
        {
            Name = (string)info.GetString("Name");
            PID = (int)info.GetInt32("PID");
            //Time = (DateTime)info.GetDateTime("Time");
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
