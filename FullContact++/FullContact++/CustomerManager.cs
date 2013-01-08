using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullContact__
{
    class CustomerManager
    {
        public BLHCustomerDbEntities Customers { get; private set; }

        public CustomerManager()
        {
            Customers = new BLHCustomerDbEntities();
        }

        public void AddCustomer(BLHCustomer customer)
        {
            Customers.BLHCustomers.AddObject(customer);
            Customers.SaveChanges();
        }

    #region FindCustomer Overloaded Methods

        public BLHCustomer FindCustomer(int customerID)
        {
            return FindByCustomerID(customerID).First();
        }

        public IEnumerable<BLHCustomer> FindCustomer(string customerID, string lastName,
            string firstName, string zip)
        {
            if (customerID != "")
            {
                int id;
                int.TryParse(customerID, out id);
                return FindByCustomerID(id);
            }
            if (lastName == "")
            {
                throw new ArgumentException("You must enter the Last Name");
            }
            if (firstName != "" && zip != "")
            {
                return FindByLastNameFistNameZip(lastName, firstName, zip);
            }
            else if (firstName != "")
            {
                return FindByLastNameFirstName(lastName, firstName);
            }
            else if (zip != "")
            {
                return FindByLastNameZip(lastName, zip);
            }
            else
            {
                return FindByLastName(lastName);
            }
        }

        private IEnumerable<BLHCustomer> FindByCustomerID(int customerID)
        {
            IEnumerable<BLHCustomer> customer =
                from c in Customers.BLHCustomers
                where c.CustomerID == customerID
                select c;

            return customer;
        }

        private IEnumerable<BLHCustomer> FindByLastName(string lastName)
        {
            IEnumerable<BLHCustomer> customersByLastName =
                from c in Customers.BLHCustomers
                where c.LastName == lastName
                select c;

            return customersByLastName;
        }

        private IEnumerable<BLHCustomer> FindByLastNameZip(string lastName, string zip)
        {
            IEnumerable<BLHCustomer> customersByLastAndZip =
                from c in Customers.BLHCustomers
                where c.LastName == lastName && c.Zip == zip
                select c;

            return customersByLastAndZip;
        }

        private IEnumerable<BLHCustomer> FindByLastNameFirstName(string lastName, string firstName)
        {
            IEnumerable<BLHCustomer> customersByLastAndFirst =
                from c in Customers.BLHCustomers
                where c.LastName == lastName && c.FirstName == firstName
                select c;

            return customersByLastAndFirst;
        }

        private IEnumerable<BLHCustomer> FindByLastNameFistNameZip(string lastName, string firstName, string zip)
        {
            IEnumerable<BLHCustomer> customersByLastFirstZip =
                from c in Customers.BLHCustomers
                where c.LastName == lastName && 
                c.FirstName == firstName && c.Zip == zip
                select c;

            return customersByLastFirstZip;
        }

        public int FindCustomerNumber(string firstName, string lastName, string address, string zipCode)
        {
            int customerNumber =
                (from c in Customers.BLHCustomers
                where firstName.Equals(c.FirstName) && lastName.Equals(c.LastName)
                && address.Equals(c.Address) && zipCode.Equals(c.Zip)
                select c.CustomerID).First();

            return customerNumber;
        }
    #endregion
    }
}
