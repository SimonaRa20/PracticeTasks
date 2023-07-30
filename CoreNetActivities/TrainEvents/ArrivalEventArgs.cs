using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainEvents
{
    public class ArrivalEventArgs
    {
        public int TrainNumer { get; set; }

        public ArrivalStatus ArrivalStatus { get; set; }

        public DateTime ArrivalTime { get; set; }

        public ArrivalEventArgs(int num, ArrivalStatus status, DateTime time)
        {
            TrainNumer = num;
            ArrivalStatus = status;
            ArrivalTime = time;
        }
    }
}
