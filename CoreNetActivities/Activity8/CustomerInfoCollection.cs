using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity8
{
    public class CustomerInfoCollection
    {
        private List<CustomerInfo> customers;

        public CustomerInfoCollection()
        {
            customers = new List<CustomerInfo>();
        }

        public int Add(CustomerInfo customer)
        {
            if(customer == null)
            {
                throw new ArgumentNullException();
            }

            int existingIndex = customers.FindIndex(c => c.ID == customer.ID);
            if (existingIndex >= 0)
            {
                return -1;
            }

            customers.Add(customer);
            return customers.Count - 1;
        }

        public void Insert(int index, CustomerInfo customer)
        {
            if(customer == null)
            {
                throw new ArgumentNullException();
            }
            else if(index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                int existingIndex = customers.FindIndex(c => c.ID == customer.ID);
                if (existingIndex < 0)
                {
                    customers.Insert(index, customer);
                }
            }
        }

        public void Remove(CustomerInfo customer)
        {
            if(customer == null)
            {
                throw new ArgumentNullException();
            }

            customers.Remove(customer);
        }

        public bool Contains(CustomerInfo customer)
        {
            if(customer == null)
            {
                throw new ArgumentNullException();
            }
            return customers.Contains(customer);
        }

        public int IndexOf(CustomerInfo customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException();
            }

            return customers.FindIndex(c => c.ID == customer.ID);
        }

        public CustomerInfo this[int index]
        {
            get
            {
                if (index >= 0 && index < customers.Count)
                    return customers[index];
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < customers.Count)
                {
                    if (value == null)
                        throw new ArgumentNullException();

                    int existingIndex = customers.FindIndex(c => c.ID == value.ID);
                    if (existingIndex >= 0 && existingIndex != index)
                        throw new ArgumentException();

                    customers[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
            }
        }
    }
}
