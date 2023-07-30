using Activity6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreNetActivities.Tests
{
    [TestClass]
    public class ShapeTest
    {
        [TestMethod]
        public void Circle_Area_CalculatedCorrectly()
        {
            // Arrange
            double radius = 5;
            double expectedArea = Math.PI * Math.Pow(radius, 2);
            Circle circle = new Circle(radius);

            // Act
            circle.CalculateArea();

            // Assert
            Assert.AreEqual(expectedArea, circle.Area, 0.0001);
        }

        [TestMethod]
        public void Rectangle_Area_CalculatedCorrectly()
        {
            // Arrange
            double length = 6;
            double width = 4;
            double expectedArea = length * width;
            Rectangle rectangle = new Rectangle(length, width);

            // Act
            rectangle.CalculateArea();

            // Assert
            Assert.AreEqual(expectedArea, rectangle.Area, 0.0001);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidShapeParameterException))]
        public void Circle_InvalidRadius_ThrowsException()
        {
            // Arrange
            double invalidRadius = -1;
            Circle circle = new Circle(invalidRadius);

            // Act & Assert
            circle.CalculateArea();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidShapeParameterException))]
        public void Rectangle_InvalidDimensions_ThrowsException()
        {
            // Arrange
            double invalidLength = 0;
            double invalidWidth = 3;
            Rectangle rectangle = new Rectangle(invalidLength, invalidWidth);

            // Act & Assert
            rectangle.CalculateArea();
        }
    }
}
