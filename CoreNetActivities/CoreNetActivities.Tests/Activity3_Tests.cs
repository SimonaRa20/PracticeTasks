using Activity1;
using Activity3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CoreNetActivities.Tests
{
    [TestClass]
    public class ArrayQueueTests
    {
        private PlayerProfile[] data;
        private ArrayQueue<PlayerProfile> q;

        [TestInitialize]
        public void Init()
        {
            data = new PlayerProfile[4];
            data[0] = new PlayerProfile("Eugene", PlayerProfile.MALE, new DateTime(1977, 9, 13));
            data[1] = new PlayerProfile("Nadja", PlayerProfile.FEMALE, new DateTime(1981, 8, 11));
            data[2] = new PlayerProfile("Toby", PlayerProfile.MALE, new DateTime(1980, 5, 19));
            data[3] = new PlayerProfile("Mr. Procrastinator", PlayerProfile.MALE, new DateTime(1, 1, 1));

            q = new ArrayQueue<PlayerProfile>(3);
        }

        [TestMethod]
        public void TestArrayQueue()
        {
            Assert.AreEqual(3, q.Capacity);

            Assert.AreEqual(false, q.IsFull());

            Assert.AreEqual(true, q.Enqueue(data[0]));
            Assert.AreEqual(true, q.Enqueue(data[1]));
            Assert.AreEqual(true, q.Enqueue(data[2]));
            Assert.AreEqual(false, q.Enqueue(data[3]));

            Assert.AreEqual(true, q.IsFull());

            Assert.AreEqual(false, q.Enqueue(data[2]));

            Assert.AreEqual(3, q.Count);

            Assert.AreEqual(1, q.IndexOf(data[1]));
            Assert.AreEqual(ArrayQueue<PlayerProfile>.NOT_IN_STRUCTURE, q.IndexOf(data[3]));

            Assert.AreEqual(data[2].PlayerName, ((PlayerProfile)q.Check(2)).PlayerName);

            Assert.AreEqual(data[0].PlayerName, ((PlayerProfile)q.CheckNext()).PlayerName);

            Assert.AreEqual(data[0].PlayerName, ((PlayerProfile)q.Dequeue()).PlayerName);
            Assert.AreEqual(data[1].PlayerName, ((PlayerProfile)q.Dequeue()).PlayerName);

            Assert.AreEqual(0, q.IndexOf(data[2]));

            Assert.AreEqual(true, q.HasNext());
            Assert.AreEqual(1, q.Count);

            q.Dequeue();
            Assert.AreEqual(false, q.HasNext());

            Assert.AreEqual(true, q.Enqueue(data[3]));
            Assert.AreEqual(true, q.Enqueue(data[2]));
            Assert.AreEqual(true, q.Enqueue(data[1]));

            Assert.AreEqual(3, q.Count);

            Assert.AreEqual(data[1].PlayerName, ((PlayerProfile)q.Check(2)).PlayerName);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestEnqueueNull()
        {
            q.Enqueue(null);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestIndexOfNull()
        {
            q.IndexOf(null);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void TestCheckIndex1()
        {
            q.Check(10000);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void TestCheckIndex2()
        {
            q.Check(-1);
        }

        [TestMethod]
        public void TestArrayQueueForValueTypeElements()
        {
            var q = new ArrayQueue<int>(3);

            Assert.AreEqual(3, q.Capacity);

            Assert.AreEqual(false, q.IsFull());

            Assert.AreEqual(true, q.Enqueue(0));
            Assert.AreEqual(true, q.Enqueue(1));
            Assert.AreEqual(true, q.Enqueue(2));
            Assert.AreEqual(false, q.Enqueue(3));

            Assert.AreEqual(true, q.IsFull());

            Assert.AreEqual(false, q.Enqueue(2));

            Assert.AreEqual(3, q.Count);

            Assert.AreEqual(1, q.IndexOf(1));
            Assert.AreEqual(ArrayQueue<int>.NOT_IN_STRUCTURE, q.IndexOf(3));

            Assert.AreEqual(2, q.Check(2));

            Assert.AreEqual(0, q.CheckNext());

            Assert.AreEqual(0, q.Dequeue());
            Assert.AreEqual(1, q.Dequeue());

            Assert.AreEqual(0, q.IndexOf(2));

            Assert.AreEqual(true, q.HasNext());
            Assert.AreEqual(1, q.Count);

            q.Dequeue();
            Assert.AreEqual(false, q.HasNext());

            Assert.AreEqual(true, q.Enqueue(3));
            Assert.AreEqual(true, q.Enqueue(2));
            Assert.AreEqual(true, q.Enqueue(1));

            Assert.AreEqual(3, q.Count);

            Assert.AreEqual(1, q.Check(2));
        }

        [TestMethod]
        public void Dequeue_FillQueueDequeueOneEnqueueOneDequeue_FirstObject()
        {
            // Arrange
            ArrayQueue<int>? queue = new ArrayQueue<int>(3);

            for (int i = 0; i < queue.Capacity; i++)
            {
                queue.Enqueue(i);
            }

            queue.Dequeue();
            queue.Enqueue(4);

            // Act
            int number = queue.Dequeue();

            // Assert
            Assert.AreEqual(number, 1);
        }

        [TestMethod]
        public void MeasureExecutionTime()
        {
            // Arrange
            ArrayQueue<int>? queue = new ArrayQueue<int>(20000);

            for (int i = 0; i < queue.Capacity - 1; i++)
            {
                queue.Enqueue(i);
            }

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            queue.Enqueue(queue.Capacity - 1);
            stopwatch.Stop();
            var firstTime = stopwatch.Elapsed.TotalMilliseconds;

            stopwatch.Reset();

            stopwatch.Start();
            queue.Dequeue();
            stopwatch.Stop();
            var secondTime = stopwatch.Elapsed.TotalMilliseconds;

            // Act
            var relativeDiff = (firstTime - secondTime) / firstTime;
            var test = relativeDiff > 0.8;

            // Assert
            Assert.IsTrue(test);
        }
    }
}
