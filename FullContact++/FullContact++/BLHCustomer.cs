using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullContact__
{
    public partial class BLHCustomer
    {

        public static string CreateAddress(string address, string apt, 
            string city, string state, string zip)
        {
            string formattedAddress;
            if (apt != null || apt != "")
            {
                formattedAddress = string.Format( "{0}\n{1}\n{2}, {3} {4}", 
                    address, apt, city, state, zip);
            }
            else
            {
                formattedAddress = string.Format("{0}\n{1}, {2} {3}", 
                    address, city, state, zip);
            }

            return formattedAddress;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            BLHCustomer customer = obj as BLHCustomer;
            if (customer.CustomerID == CustomerID)
            {
                return true;
            }
            if (customer.LastName.Equals(LastName) && customer.FirstName.Equals(FirstName))
            {
                if (customer.Zip.Equals(Zip) && customer.Address.Equals(Address))
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return CustomerID * 17 + LastName.GetHashCode() + FirstName.GetHashCode() + 
                Zip.GetHashCode() + Address.GetHashCode();
        }
    }
}
