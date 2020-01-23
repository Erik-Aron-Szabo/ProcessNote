using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Diagnostics;
namespace ProcessNote
{
    [Serializable()]
        //internal
   public class Pattributes : ISerializable
    { 

        public long Memory { get; set; }
        public TimeSpan ProcTime { get; set; }
        public DateTime StartTime { get; set; }
        public string Comment { get; set; }

        public Pattributes()
        {
        }

       public Pattributes(long memory, TimeSpan time, DateTime start)
       {

            Memory = memory;
            ProcTime = time;
            StartTime = start;
       }

       public void GetObjectData(SerializationInfo info, StreamingContext context)
       {
           throw new NotImplementedException();
       }
    }
}
