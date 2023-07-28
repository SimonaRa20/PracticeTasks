using Activity1;
using Activity2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CoreNetActivities.Tests
{
    [TestClass]
    public class ArrayStackTest
    {
        private PlayerProfile[] data;

        private ArrayStack<string> stringStack;

        private ArrayStack<int> intStack;

        private readonly int stackCapacity = 3;

        private readonly int defaultStackCapacity = 5;

        [TestInitialize]
        public void Init()
        {
            this.data = new PlayerProfile[4];
            this.data[0] = new PlayerProfile("Eugene", PlayerProfile.MALE, new DateTime(1977, 9, 13));
            this.data[1] = new PlayerProfile("Nadja", PlayerProfile.FEMALE, new DateTime(1981, 8, 11));
            this.data[2] = new PlayerProfile("Toby", PlayerProfile.MALE, new DateTime(1980, 5, 19));
            this.data[3] = new PlayerProfile("The OW", PlayerProfile.MALE, DateTime.Now);

            stringStack = new ArrayStack<string>(this.stackCapacity);
            intStack = new ArrayStack<int>(this.stackCapacity);
        }

        [TestMethod]
        public void ArrayStack_NoInput_DefaultSize()
        {
            // Arrange
            var newStack = new ArrayStack<string>();

            // Act & Assert
            Assert.AreEqual(defaultStackCapacity, newStack.Capacity);
        }

        [TestMethod]
        public void ArrayStack_InvalidInput_DefaultSize()
        {
            // Arrange
            var arraySize = -1;
            var newStack = new ArrayStack<string>(arraySize);

            // Act & Assert
            Assert.AreEqual(defaultStackCapacity, newStack.Capacity);
        }

        [TestMethod]
        [DataRow(4)]
        [DataRow(-1)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void StoreArrayIndexerProperty_InvalidInput_ThrowException(int index)
        {
            _ = this.stringStack[index];
        }

        [TestMethod]
        public void Capacity_ValidStack_ReturnsStoreArrayLenght()
        {
            // Arrange
            var newStack = new ArrayStack<string>(this.stackCapacity);

            // Act & Assert
            Assert.AreEqual(this.stackCapacity, newStack.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_EmptyStack_ThrowError()
        {
            _ = this.stringStack.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_EmptyStack_ThrowError()
        {
            _ = this.stringStack.Peek();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveAt_EmptyStack_ThrowException()
        {
            this.stringStack.RemoveAt(0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Push_FullStack_ThrowException()
        {
            // Arrange
            var stackSize = 1;
            var newStack = new ArrayStack<string>(stackSize);
            newStack.Add(this.data[0].PlayerName);

            // Act
            newStack.Push(this.data[3].PlayerName);
        }

        [TestMethod]
        public void IsEmpty_EmptyStack_ReturnsTrue()
        {
            // Arrange & Act
            var result = this.stringStack.IsEmpty();

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, this.stringStack.Count);
        }

        [TestMethod]
        [DataRow(1, true)]
        [DataRow(2, false)]
        public void IsFull_Validinput_ReturnsExpectedResult(int stackSize, bool expectedResult)
        {
            // Arrange
            var newStack = new ArrayStack<string>(stackSize);
            newStack.Push(this.data[0].PlayerName);

            // Act
            var result = newStack.IsFull();

            // Assert
            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(1, newStack.Count);
        }

        [TestMethod]
        public void Push_DublicateStringValue_ValueNotAdded()
        {
            // Arange
            this.stringStack.Push(this.data[0].PlayerName);
            this.stringStack.Push(this.data[1].PlayerName);

            // Act
            this.stringStack.Push(this.data[1].PlayerName);

            // Assert
            Assert.AreEqual(this.data[0].PlayerName, this.stringStack[0]);
            Assert.AreEqual(this.data[1].PlayerName, this.stringStack[1]);
            Assert.AreEqual(2, this.stringStack.Count);
        }

        [TestMethod]
        public void Push_DublicateIntegerValue_ValueNotAdded()
        {
            // Arange
            this.intStack.Push(0);
            this.intStack.Push(1);

            // Act
            this.intStack.Push(1);

            // Assert
            Assert.AreEqual(0, this.intStack[0]);
            Assert.AreEqual(1, this.intStack[1]);
            Assert.AreEqual(2, this.intStack.Count);
        }

        [TestMethod]
        public void Push_ValidStringInput_ReturnExpectedResult()
        {
            // Arrange and Act
            this.stringStack.Push(this.data[0].PlayerName);
            this.stringStack.Push(this.data[1].PlayerName);
            this.stringStack.Push(this.data[2].PlayerName);

            // Assert
            Assert.AreEqual(this.data[0].PlayerName, this.stringStack[0]);
            Assert.AreEqual(this.data[1].PlayerName, this.stringStack[1]);
            Assert.AreEqual(this.data[2].PlayerName, this.stringStack[2]);
            Assert.AreEqual(3, this.stringStack.Count);
        }

        [TestMethod]
        public void Push_ValidIntegerInput_ReturnExpectedResult()
        {
            // Arrange and Act
            this.intStack.Push(0);
            this.intStack.Push(1);
            this.intStack.Push(2);

            // Assert
            Assert.AreEqual(0, this.intStack[0]);
            Assert.AreEqual(1, this.intStack[1]);
            Assert.AreEqual(2, this.intStack[2]);
            Assert.AreEqual(3, this.intStack.Count);
        }

        [TestMethod]
        public void Peek_ValidStringInput_ReturnExpectedResult()
        {
            // Arange
            this.stringStack.Add(this.data[0].PlayerName);
            this.stringStack.Add(this.data[1].PlayerName);

            // Act
            var result = this.stringStack.Peek();

            // Assert
            Assert.AreEqual(this.data[1].PlayerName, this.stringStack[1]);
            Assert.AreEqual(this.data[1].PlayerName, result);
        }

        [TestMethod]
        public void Peek_ValidIntegerInput_ReturnExpectedResult()
        {
            // Arange
            this.intStack.Add(0);
            this.intStack.Add(1);

            // Act
            var result = this.intStack.Peek();

            // Assert
            Assert.AreEqual(1, this.intStack[1]);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Pop_ValidStringInput_ReturnExpectedResult()
        {
            // Arange
            this.stringStack.Add(this.data[0].PlayerName);
            this.stringStack.Add(this.data[1].PlayerName);
            this.stringStack.Add(this.data[2].PlayerName);

            // Act
            var result = this.stringStack.Pop();

            // Assert
            Assert.AreEqual(this.data[0].PlayerName, this.stringStack[0]);
            Assert.AreEqual(this.data[1].PlayerName, this.stringStack[1]);
            Assert.AreEqual(this.data[2].PlayerName, result);
            Assert.AreEqual(2, this.stringStack.Count);
        }

        [TestMethod]
        public void Pop_ValidIntegerInput_ReturnExpectedResult()
        {
            // Arange
            this.intStack.Add(0);
            this.intStack.Add(1);
            this.intStack.Add(2);

            // Act
            var result = this.intStack.Pop();

            // Assert
            Assert.AreEqual(0, this.intStack[0]);
            Assert.AreEqual(1, this.intStack[1]);
            Assert.AreEqual(2, result);
            Assert.AreEqual(2, this.intStack.Count);
        }
    }
}
