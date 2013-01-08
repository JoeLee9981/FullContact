using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FullContact__
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region private fields
        private string customerSummary, firstName, lastName, address, apt,
            city, state, zip, phone, email, orderType;

        private string shippingFirstName, shippingLastName, shippingAddress, shippingApt,
            shippingCity, shippingState, shippingZip, shippingPhone, shippingEmail, shippingType;
        
        #endregion

        public string CustomerSummary
        {
            get
            {
                return customerSummary;
            }
            set
            {
                customerSummary = value.ToUpper();
                OnPropertyChanged("CustomerSummary");
            }
        }

        #region Billing Properties
        

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value.ToUpper();
                UpdateSummary();
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value.ToUpper();
                UpdateSummary();
                OnPropertyChanged("LastName");
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value.ToUpper();
                UpdateSummary();
                OnPropertyChanged("Address");
            }
        }

        public string Apt
        {
            get
            {
                return apt;
            }
            set
            {
                if (value != null)
                {
                    apt = value.ToUpper();
                }
                UpdateSummary();
                OnPropertyChanged("Apt");
            }
        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value.ToUpper();
                UpdateSummary();
                OnPropertyChanged("City");
            }
        }

        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value.ToUpper();
                UpdateSummary();
                OnPropertyChanged("State");
            }
        }

        public string Zip
        {
            get
            {
                return zip;
            }
            set
            {
                zip = value.ToUpper();
                UpdateSummary();
                OnPropertyChanged("Zip");
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value.ToUpper();
                UpdateSummary();
                OnPropertyChanged("Phone");
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (value != null)
                {
                    email = value.ToUpper();
                }
                UpdateSummary();
                OnPropertyChanged("Email");
            }
        }

        public string OrderType
        {
            get
            {
                return orderType;
            }
            set
            {
                orderType = value;
                UpdateSummary();
                OnPropertyChanged("OrderType");
            }
        }
        #endregion

        #region Shipping Properties

        public string ShippingFirstName
        {
            get
            {
                return shippingFirstName;
            }
            set
            {
                shippingFirstName = value;
                UpdateSummary();
                OnPropertyChanged("ShippingFirstName");
            }
        }

        public string ShippingLastName
        {
            get
            {
                return shippingLastName;
            }
            set
            {
                shippingLastName = value.ToUpper();
                UpdateSummary();
                OnPropertyChanged("ShippingLastName");
            }
        }

        public string ShippingAddress
        {
            get
            {
                return shippingAddress;
            }
            set
            {
                shippingAddress = value.ToUpper();
                UpdateSummary();
                OnPropertyChanged("ShippingAddress");
            }
        }

        public string ShippingApt
        {
            get
            {
                return shippingApt;
            }
            set
            {
                shippingApt = value.ToUpper();
                UpdateSummary();
                OnPropertyChanged("ShippingApt");
            }
        }

        public string ShippingCity
        {
            get
            {
                return shippingCity;
            }
            set
            {
                shippingCity = value.ToUpper();
                UpdateSummary();
                OnPropertyChanged("ShippingCity");
            }
        }

        public string ShippingState
        {
            get
            {
                return shippingState;
            }
            set
            {
                shippingState = value.ToUpper();
                UpdateSummary();
                OnPropertyChanged("ShippingState");
            }
        }

        public string ShippingZip
        {
            get
            {
                return shippingZip;
            }
            set
            {
                shippingZip = value.ToUpper();
                UpdateSummary();
                OnPropertyChanged("ShippingZip");
            }
        }

        public string ShippingPhone
        {
            get
            {
                return shippingPhone;
            }
            set
            {
                shippingPhone = value.ToUpper();
                UpdateSummary();
                OnPropertyChanged("ShippingPhone");
            }
        }

        public string ShippingEmail
        {
            get
            {
                return shippingEmail;
            }
            set
            {
                shippingEmail = value.ToUpper();
                UpdateSummary();
                OnPropertyChanged("ShippingEmail");
            }
        }

        public string ShippingType
        {
            get
            {
                return shippingType;
            }
            set
            {
                shippingType = value.ToUpper();
                UpdateSummary();
                OnPropertyChanged("ShippingType");
            }
        }

        #endregion

        private void UpdateSummary()
        {
            CustomerSummary = String.Format("Customer Info:\nBilling:\nOrder Type: {0}\n{1} {2}\n{3}\nPhone: {4}\nEmail: {5}\n", 
                OrderType, FirstName, LastName, BLHCustomer.CreateAddress(Address, Apt, City, State, Zip), Phone, Email);

            CustomerSummary += String.Format("\nShipping:\n{0} {1}\n{2}\nPhone: {3}\nEmail: {4}\nShipping Type: {5}",
                ShippingFirstName, ShippingLastName, BLHCustomer.CreateAddress(ShippingAddress, ShippingApt, ShippingCity, 
                ShippingState, ShippingZip), Phone, Email, ShippingType);
        }

        protected void OnPropertyChanged(string summary)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(summary));
            }
        }

        private string CorrectCase(string value)
        {
            value.ToLower();
            char[] values = value.ToCharArray();
            values[0]  = Char.ToUpper(values[0]);
            return new string(values);
        }
    }


}
