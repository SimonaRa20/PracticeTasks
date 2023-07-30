using Activity8;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreNetActivities.Tests
{
    [TestClass]
    public class CustomerInfoCollectionTests
    {
        [TestMethod]
        public void TestInsertMethod()
        {
            CustomerInfoCollection customerCollection = new CustomerInfoCollection();
            CustomerInfo customer1 = new CustomerInfo(1, "John Doe", "123 Main St", "john@example.com");
            CustomerInfo customer2 = new CustomerInfo(2, "Jane Smith", "456 Oak Ave", "jane@example.com");
            customerCollection.Insert(0, customer1);
            customerCollection.Insert(1, customer2);

            CustomerInfo newCustomer = new CustomerInfo(3, "Bob Johnson", "789 Elm St", "bob@example.com");
            customerCollection.Insert(1, newCustomer);

            Assert.AreEqual(newCustomer, customerCollection[1]);
        }

        [TestMethod]
        public void TestRemoveMethod()
        {
            CustomerInfoCollection customerCollection = new CustomerInfoCollection();
            CustomerInfo customer1 = new CustomerInfo(1, "John Doe", "123 Main St", "john@example.com");
            CustomerInfo customer2 = new CustomerInfo(2, "Jane Smith", "456 Oak Ave", "jane@example.com");
            customerCollection.Insert(0, customer1);
            customerCollection.Insert(1, customer2);

            customerCollection.Remove(customer2);

            Assert.IsFalse(customerCollection.Contains(customer2));
        }

        [TestMethod]
        public void TestContainsMethod()
        {
            CustomerInfoCollection customerCollection = new CustomerInfoCollection();
            CustomerInfo customer1 = new CustomerInfo(1, "John Doe", "123 Main St", "john@example.com");
            CustomerInfo customer2 = new CustomerInfo(2, "Jane Smith", "456 Oak Ave", "jane@example.com");
            customerCollection.Insert(0, customer1);

            bool containsCustomer1 = customerCollection.Contains(customer1);
            Assert.IsTrue(containsCustomer1);

            bool containsCustomer2 = customerCollection.Contains(customer2);
            Assert.IsFalse(containsCustomer2);
        }

        [TestMethod]
        public void TestIndexOfMethod()
        {
            CustomerInfoCollection customerCollection = new CustomerInfoCollection();
            CustomerInfo customer1 = new CustomerInfo(1, "John Doe", "123 Main St", "john@example.com");
            CustomerInfo customer2 = new CustomerInfo(2, "Jane Smith", "456 Oak Ave", "jane@example.com");
            customerCollection.Insert(0, customer1);

            int index = customerCollection.IndexOf(customer1);
            Assert.AreEqual(0, index);

            int indexNotFound = customerCollection.IndexOf(customer2);
            Assert.AreEqual(-1, indexNotFound);
        }
    }
}
