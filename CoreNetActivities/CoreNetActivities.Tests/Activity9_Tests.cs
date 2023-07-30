using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainEvents;

namespace CoreNetActivities.Tests
{
    [TestClass]
    public class TrainStationTests
    {
        [TestMethod]
        public void TestArrivalEvent_SubscribeAndFireEvent()
        {
            TrainStation station = new TrainStation();

            station.Arrival += ArrivalHandler1;

            station.Arrival += ArrivalHandler2;

            int trainNumber = 123;
            ArrivalStatus arrivalStatus = ArrivalStatus.Arriving;
            DateTime arrivalTime = DateTime.Now;

            station.AnnounceArrival(trainNumber, arrivalStatus, arrivalTime);
        }

        private void ArrivalHandler1(object sender, ArrivalEventArgs args)
        {
            Console.WriteLine($"Subscriber 1: Train {args.TrainNumer} is {args.ArrivalStatus} at {args.ArrivalTime}.");
        }

        private void ArrivalHandler2(object sender, ArrivalEventArgs args)
        {
            Console.WriteLine($"Subscriber 2: Train {args.TrainNumer} is {args.ArrivalStatus} at {args.ArrivalTime}.");
        }
    }
}
