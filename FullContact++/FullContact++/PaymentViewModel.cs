using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;

namespace FullContact__
{
    class PaymentViewModel : INotifyPropertyChanged
    {

        private string expDate, paymentNumber, cvv, paymentType;

        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties
        public string PaymentType
        {
            get
            {
                return paymentType;
            }
            set
            {

                paymentType = value;
            }
        }

        public string PaymentNumber
        {
            get
            {
                return paymentNumber;
            }
            set
            {
                if (!ValidatePaymentNumber(value))
                {
                    MessageBox.Show("The number you have entered is invalid", "An error has occurred",
                        MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                paymentNumber = value;
            }
        }

        public string ExpDate
        {
            get
            {
                return expDate;
            }
            set
            {
                if (!IsValidExpDate(value))
                {
                    MessageBox.Show("Invalid Expiration date, format: (mm/yy)", "An error has occurred",
                        MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                expDate = value;
            }
        }

        public string Cvv
        {
            get
            {
                return cvv;
            }
            set
            {
                if (!IsValidCvv(value))
                {
                    MessageBox.Show("Invalid CVV, please check and try again", "An error has occurred",
                        MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                cvv = value;
            }
        }
        #endregion

        protected void OnPropertyChanged(string summary)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(summary));
            }
        }

        #region Validation Methods
        public bool ValidatePaymentNumber(string value)
        {
            long number;
            bool numbersOnly = long.TryParse(value, out number);
            if(!numbersOnly)
            {
                return false;
            }
            switch (PaymentType)
            {
                case "Check / Money Order":
                    return true;
                case "Visa":
                    return value[0].Equals('4') && IsValidCCNumber(value) && value.Length == 16;
                case "Master Card":
                    return value[0].Equals('5') && IsValidCCNumber(value) && value.Length == 16;
                case "Discover":
                    return value.Substring(0, 4).Equals("6011") && IsValidCCNumber(value) && value.Length == 16;
                case "American Express":
                    return value[0].Equals('3') && IsValidCCNumber(value) && value.Length == 15;
                default:
                    return false;
            }

        }

        private bool IsValidCCNumber(string creditCardNum)
        {
            string cardNumberReversed = new string(creditCardNum.Reverse().ToArray());
            // Run through each single digit to create a new string. Even digits
            // are multiplied by two, odd digits are left alone.

            string cardNumModified = "";
            for (int i = 0; i < cardNumberReversed.Length; i++)
            {
                int digit; 
                int.TryParse(cardNumberReversed[i].ToString(), out digit);
                if (i % 2 != 0)
                {
                    digit *= 2;
                }
                cardNumModified += digit;
            }

            //add up all the single digits in this string
            int sum = 0;
            for(int i=0; i < cardNumModified.Length; i++)
            {
                int digit;
                int.TryParse(cardNumModified[i].ToString(), out digit);
                sum += digit;
            }
            // If the resulting sum is an even multiple of ten (but not zero), the
            // card number is good.
            return (sum != 0 && sum % 10 == 0);

        }

        public bool IsValidExpDate(string expDate)
        {
            string[] splitDate = expDate.Split('/');
            //verify exactly 2 fields, month and year
            if (splitDate.Length != 2)
            {
                return false;
            }
            //make sure date is past current
            DateTime dateToTest;
            if (!DateTime.TryParse(string.Format("{0}/{1}/{2}", splitDate[0], 28, splitDate[1]), out dateToTest))
            {
                return false;
            }
            if(dateToTest.CompareTo(DateTime.Today) < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
                
        }

        public bool IsValidCvv(string cvv)
        {
            int parsedCvv;
            if(!int.TryParse(cvv, out parsedCvv))
            {
                return false;
            }
            if(PaymentType.Equals("American Express"))
            {
                return cvv.Length == 4;
            }
            else
            {
                return cvv.Length == 3;
            }
        }

        #endregion
    }
}
