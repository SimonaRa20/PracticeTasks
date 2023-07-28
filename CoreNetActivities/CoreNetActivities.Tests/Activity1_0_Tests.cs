using Activity1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CoreNetActivities.Tests
{
    [TestClass]
    public class ComputeAgeTests
    {
        private readonly int ageBeforeBirthday = 0;

        private readonly int ageAfterBirthday = 1;

        [TestMethod]
        public void ComputeAge_BirthdayInMonth_ReturnAgeBeforeBirthday()
        {
            // Arrange
            int currentAge = ageBeforeBirthday;
            DateTime birthday = DateTime.Now.AddYears(ageAfterBirthday * -1).AddMonths(1);
            var player = new PlayerProfile("Eugene", PlayerProfile.MALE, new DateTime(birthday.Year, birthday.Month, birthday.Day));

            // Act
            int actualAge = player.ComputeAge();

            // Assert
            Assert.AreEqual(currentAge, actualAge);
        }

        [TestMethod]
        public void ComputeAge_BirthdayTomorow_ReturnAgeBeforeBirthday()
        {
            // Arrange
            int currentAge = ageBeforeBirthday;
            DateTime birthday = DateTime.Now.AddYears(ageAfterBirthday * -1).AddDays(1);
            var player = new PlayerProfile("John", PlayerProfile.FEMALE, new DateTime(birthday.Year, birthday.Month, birthday.Day));

            // Act
            int actualAge = player.ComputeAge();

            // Assert
            Assert.AreEqual(currentAge, actualAge);
        }

        [TestMethod]
        public void ComputeAge_BirthdayToday_ReturnAgeAfterBirthday()
        {
            // Arrange
            int currentAge = ageAfterBirthday;
            DateTime birthday = DateTime.Now.AddYears(ageAfterBirthday * -1);
            var player = new PlayerProfile("Tony", PlayerProfile.MALE, new DateTime(birthday.Year, birthday.Month, birthday.Day));

            // Act
            int actualAge = player.ComputeAge();

            // Assert
            Assert.AreEqual(currentAge, actualAge);
        }

        [TestMethod]
        public void ComputeAge_BornToday_ReturnAgeBeforeBirthday()
        {
            // Arrange
            int currentAge = ageBeforeBirthday;
            DateTime birthday = DateTime.Now;
            var player = new PlayerProfile("The Zero", PlayerProfile.MALE, new DateTime(birthday.Year, birthday.Month, birthday.Day));

            // Act
            int actualAge = player.ComputeAge();

            // Assert
            Assert.AreEqual(currentAge, actualAge);
        }

        [TestMethod]
        public void ComputeAge_BirthdayYesterday_ReturnAgeAfterBirthday()
        {
            // Arrange
            int currentAge = ageAfterBirthday;
            DateTime birthday = DateTime.Now.AddYears(ageAfterBirthday * -1).AddDays(-1);
            var player = new PlayerProfile("Nadja", PlayerProfile.FEMALE, new DateTime(birthday.Year, birthday.Month, birthday.Day));

            // Act
            int actualAge = player.ComputeAge();

            // Assert
            Assert.AreEqual(currentAge, actualAge);
        }

        [TestMethod]
        public void ComputeAge_BirthdayLastMonth_ReturnAgeAfterBirthday()
        {
            // Arrange
            int currentAge = ageAfterBirthday;
            DateTime birthday = DateTime.Now.AddYears(ageAfterBirthday * -1).AddMonths(-1);
            var player = new PlayerProfile("Bob", PlayerProfile.MALE, new DateTime(birthday.Year, birthday.Month, birthday.Day));

            // Act
            int actualAge = player.ComputeAge();

            // Assert
            Assert.AreEqual(currentAge, actualAge);
        }

        [TestMethod]
        public void ComputeAge_BornOnYearOne_ReturnsCorrectAge()
        {
            // Arrange
            int currentAge = DateTime.Now.Year - 1;
            int ageAfterBirthday = DateTime.Now.Year - 1;
            DateTime birthday = DateTime.Now.AddYears(ageAfterBirthday * -1);
            var player = new PlayerProfile("Chris", PlayerProfile.MALE, new DateTime(DateTime.MinValue.Year, birthday.Month, birthday.Day));

            // Act
            int actualAge = player.ComputeAge();

            // Assert
            Assert.AreEqual(currentAge, actualAge);
        }

        [TestMethod]
        public void ComputeAge_BornOnFirstDayOfYear_ReturnsCorrectAge()
        {
            // Arrange
            int currentAge = ageAfterBirthday;
            DateTime birthday = new DateTime(DateTime.Now.Year - 1, 1, 1);
            var player = new PlayerProfile("Agatha", PlayerProfile.MALE, new DateTime(birthday.Year, birthday.Month, birthday.Day));

            // Act
            int actualAge = player.ComputeAge();

            // Assert
            Assert.AreEqual(currentAge, actualAge);
        }

        [TestMethod]
        public void ComputeAge_BornOnFirstDayOfNextMonth_ReturnsCorrectAge()
        {
            // Arrange
            int currentAge = ageBeforeBirthday;
            DateTime birthday = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month + 1, 1);
            var player = new PlayerProfile("Martha", PlayerProfile.FEMALE, new DateTime(birthday.Year, birthday.Month, birthday.Day));

            // Act
            int actualAge = player.ComputeAge();

            // Assert
            Assert.AreEqual(currentAge, actualAge);
        }

        [TestMethod]
        public void ComputeAge_BornOnLastDayOfyear_ReturnsCorrectAge()
        {
            // Arrange
            int currentAge = ageBeforeBirthday;
            DateTime birthday = new DateTime(DateTime.Now.Year - 1, 12, 31);
            var player = new PlayerProfile("Sean", PlayerProfile.FEMALE, new DateTime(birthday.Year, birthday.Month, birthday.Day));

            // Act
            int actualAge = player.ComputeAge();

            // Assert
            Assert.AreEqual(currentAge, actualAge);
        }
    }
}
