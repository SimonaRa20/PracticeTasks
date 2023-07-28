using Activity1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CoreNetActivities.Tests
{
    [TestClass]
    public class GetZodiacSignTests
    {
        [TestMethod]
        [DataRow(9, 13)]
        [DataRow(8, 23)]
        [DataRow(9, 22)]
        public void GetZodiacSign_Virgo_ReturnExpectedSign(int month, int day)
        {
            // Arrange
            var date = new DateTime(1977, month, day);

            // Act
            var result = Zodiac.GetZodiacSign(date);

            // Assert
            Assert.AreEqual(Zodiac.VIRGO, result);
        }

        [TestMethod]
        [DataRow(8, 11)]
        [DataRow(7, 23)]
        [DataRow(8, 22)]
        public void GetZodiacSign_Leo_ReturnExpectedSign(int month, int day)
        {
            // Arrange
            var date = new DateTime(1981, month, day);

            // Act
            var result = Zodiac.GetZodiacSign(date);

            // Assert
            Assert.AreEqual(Zodiac.LEO, result);
        }

        [TestMethod]
        [DataRow(5, 13)]
        [DataRow(4, 20)]
        [DataRow(5, 20)]
        public void GetZodiacSign_Taurus_ReturnExpectedSign(int month, int day)
        {
            // Arrange
            var date = new DateTime(2981, month, day);

            // Act
            var result = Zodiac.GetZodiacSign(date);

            // Assert
            Assert.AreEqual(Zodiac.TAURUS, result);
        }

        [TestMethod]
        [DataRow(4, 1)]
        [DataRow(3, 21)]
        [DataRow(4, 19)]
        public void GetZodiacSign_Aries_ReturnExpectedSign(int month, int day)
        {
            // Arrange
            var date = new DateTime(1923, month, day);

            // Act
            var result = Zodiac.GetZodiacSign(date);

            // Assert
            Assert.AreEqual(Zodiac.ARIES, result);
        }

        [TestMethod]
        [DataRow(5, 30)]
        [DataRow(5, 21)]
        [DataRow(6, 20)]
        public void GetZodiacSign_Gemini_ReturnExpectedSign(int month, int day)
        {
            // Arrange
            var date = new DateTime(1982, month, day);

            // Act
            var result = Zodiac.GetZodiacSign(date);

            // Assert
            Assert.AreEqual(Zodiac.GEMINI, result);
        }

        [TestMethod]
        [DataRow(7, 20)]
        [DataRow(6, 21)]
        [DataRow(7, 22)]
        public void GetZodiacSign_Cancer_ReturnExpectedSign(int month, int day)
        {
            // Arrange
            var date = new DateTime(1642, month, day);

            // Act
            var result = Zodiac.GetZodiacSign(date);

            // Assert
            Assert.AreEqual(Zodiac.CANCER, result);
        }

        [TestMethod]
        [DataRow(9, 26)]
        [DataRow(9, 23)]
        [DataRow(10, 22)]
        public void GetZodiacSign_Libra_ReturnExpectedSign(int month, int day)
        {
            // Arrange
            var date = new DateTime(1776, month, day);

            // Act
            var result = Zodiac.GetZodiacSign(date);

            // Assert
            Assert.AreEqual(Zodiac.LIBRA, result);
        }

        [TestMethod]
        [DataRow(11, 21)]
        [DataRow(10, 23)]
        [DataRow(11, 21)]
        public void GetZodiacSign_Scorpio_ReturnExpectedSign(int month, int day)
        {
            // Arrange
            var date = new DateTime(1021, month, day);

            // Act
            var result = Zodiac.GetZodiacSign(date);

            // Assert
            Assert.AreEqual(Zodiac.SCORPIO, result);
        }

        [TestMethod]
        [DataRow(12, 1)]
        [DataRow(11, 22)]
        [DataRow(12, 21)]
        public void GetZodiacSign_Sagittarius_ReturnExpectedSign(int month, int day)
        {
            // Arrange
            var date = new DateTime(1, month, day);

            // Act
            var result = Zodiac.GetZodiacSign(date);

            // Assert
            Assert.AreEqual(Zodiac.SAGITTARIUS, result);
        }

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(12, 22)]
        [DataRow(1, 19)]
        public void GetZodiacSign_Capricorn_ReturnExpectedSign(int month, int day)
        {
            // Arrange
            var date = new DateTime(100, month, day);

            // Act
            var result = Zodiac.GetZodiacSign(date);

            // Assert
            Assert.AreEqual(Zodiac.CAPRICORN, result);
        }

        [TestMethod]
        [DataRow(2, 14)]
        [DataRow(1, 20)]
        [DataRow(2, 18)]
        public void GetZodiacSign_Aquarius_ReturnExpectedSign(int month, int day)
        {
            // Arrange
            var date = new DateTime(100, month, day);

            // Act
            var result = Zodiac.GetZodiacSign(date);

            // Assert
            Assert.AreEqual(Zodiac.AQUARIUS, result);
        }

        [TestMethod]
        [DataRow(2, 24)]
        [DataRow(2, 19)]
        [DataRow(3, 20)]
        public void GetZodiacSign_Pisces_ReturnExpectedSign(int month, int day)
        {
            // Arrange
            var date = new DateTime(100, 2, 24);

            // Act
            var result = Zodiac.GetZodiacSign(date);

            // Assert
            Assert.AreEqual(Zodiac.PISCES, result);
        }
    }
}
