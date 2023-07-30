using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainEvents
{
    public class TrainStation
    {
        public event EventHandler<ArrivalEventArgs> Arrival;

        protected void OnArrival(ArrivalEventArgs e)
        {
            Arrival?.Invoke(this, e);
        }

        public void AnnounceArrival(int train, ArrivalStatus arrivalStatus, DateTime arrivalTime)
        {
            ArrivalEventArgs args = new ArrivalEventArgs(train, arrivalStatus, arrivalTime);
            OnArrival(args);
        }
    }
}
