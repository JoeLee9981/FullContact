using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace FullContact__
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private CustomerManager manager;
        public List<LineItem> ListOfProducts { get; private set; }

        //Constructor
        public MainWindow()
        {
            InitializeComponent();
            manager = new CustomerManager();
            ListOfProducts = new List<LineItem>();
            AddToolTips();
        }

    #region Display Control Methods
        public void ViewCustomer(BLHCustomer customer)
        {
            CustomerIDTb.Text = customer.CustomerID.ToString();
            FirstNameTb.Text = customer.FirstName;
            LastNameTb.Text = customer.LastName;
            AddressTb.Text = customer.Address;
            AptTb.Text = customer.Apt;
            CityTb.Text = customer.City;
            StateTb.Text = customer.State;
            ZipCodeTb.Text = customer.Zip;
            PhoneTb.Text = customer.Phone;
            EmailTb.Text = customer.Email;
            AVSTb.Text = customer.AVS;
            BirthdayTb.Text = customer.Birthday;
            List<Order> orderHistory = Order.FindOrdersByCustomer(customer.CustomerID).ToList();
            OrderHistoryDg.ItemsSource = orderHistory;
        }

        private void SameAsBilling_Checked(object sender, RoutedEventArgs e)
        {
            ShippingFirstNameTb.Text = FirstNameTb.Text;
            ShippingLastNameTb.Text = LastNameTb.Text;
            ShippingAddressTb.Text = AddressTb.Text;
            ShippingAptTb.Text = AptTb.Text;
            ShippingCityTb.Text = CityTb.Text;
            ShippingStateTb.Text = StateTb.Text;
            ShippingZipCodeTb.Text = ZipCodeTb.Text;
            ShippingPhoneTb.Text = PhoneTb.Text;
            ShippingEmailTb.Text = EmailTb.Text;
        }

        private void AddCustomer()
        {
            BLHCustomer newCustomer = new BLHCustomer();
            newCustomer.FirstName = FirstNameTb.Text;
            newCustomer.LastName = LastNameTb.Text;
            newCustomer.Address = AddressTb.Text;
            newCustomer.Apt = AptTb.Text;
            newCustomer.City = CityTb.Text;
            newCustomer.State = StateTb.Text;
            newCustomer.Zip = ZipCodeTb.Text;
            newCustomer.Phone = PhoneTb.Text;
            newCustomer.Email = EmailTb.Text;
            newCustomer.AVS = AVSTb.Text;
            newCustomer.Birthday = BirthdayTb.Text;
            manager.AddCustomer(newCustomer);
        }

        private void enablePayment(string method)
        {
            switch (method)
            {
                case "Check / Money Order":
                    PaymentNumberTb.IsEnabled = true;
                    ExpDateTb.IsEnabled = false;
                    CCVTb.IsEnabled = false;
                    PaymentToolTip("Check");
                    break;
                case "Visa":
                    PaymentNumberTb.IsEnabled = true;
                    ExpDateTb.IsEnabled = true;
                    CCVTb.IsEnabled = true;
                    PaymentToolTip("Credit");
                    break;
                case "Master Card":
                    PaymentNumberTb.IsEnabled = true;
                    ExpDateTb.IsEnabled = true;
                    CCVTb.IsEnabled = true;
                    PaymentToolTip("Credit");
                    break;
                case "Discover":
                    PaymentNumberTb.IsEnabled = true;
                    ExpDateTb.IsEnabled = true;
                    CCVTb.IsEnabled = true;
                    PaymentToolTip("Credit");
                    break;
                case "American Express":
                    PaymentNumberTb.IsEnabled = true;
                    ExpDateTb.IsEnabled = true;
                    CCVTb.IsEnabled = true;
                    PaymentToolTip("AMEX");
                    break;
            }

        }

        private void Search(string searcher, int option)
        {
            ListViewDg.ItemsSource = new List<Catalog>();
            ListViewDg.ItemsSource = Catalog.FindProductFromCatalog(searcher, option);
            ListViewDg.MaxColumnWidth = 300;
        }

        public void UpdateOrderTotal()
        {
            decimal total = 0;
            foreach (LineItem l in ListOfProducts)
            {
                total += l.Price;
            }
            total += Order.GetShippingCost(ShippingTypeCb.Text);
            OrderTotalLb.Content = string.Format("{0:C}", total);
        }

        private void ClearSession()
        {
            CustomerIDTb.Text = string.Empty;
            FirstNameTb.Clear();
            LastNameTb.Clear();
            AddressTb.Clear();
            AptTb.Clear();
            ZipCodeTb.Clear();
            CityTb.Clear();
            StateTb.Clear();
            EmailTb.Clear();
            PhoneTb.Clear();
            SavingsCodeTb.Clear();
            AVSTb.Clear();
            BirthdayTb.Clear();
            DiscountCodeTb.Clear();
            ShippingAddressTb.Clear();
            ShippingAptTb.Clear();
            ShippingEmailTb.Clear();
            ShippingFirstNameTb.Clear();
            ShippingLastNameTb.Clear();
            ShippingPhoneTb.Clear();
            ShippingStateTb.Clear();
            ShippingZipCodeTb.Clear();
            ShippingTypeCb.SelectedValue = null;
            GiftMessage.Clear();
            ListOfProducts = new List<LineItem>();
            UpdateOrderTotal();
            ListViewDg.ItemsSource = null;
            OrderHistoryDg.ItemsSource = null;
            ProductListDg.ItemsSource = null;
            ShippingCityTb.Clear();
            PaymentCb.SelectedValue = null;
            PaymentNumberTb.Clear();
            ExpDateTb.Clear();
            CCVTb.Clear();
            OrderSummaryTb.Text = "Order Summary";
        }

    #endregion

    #region ToolTip
        private void AddToolTips()
        {
            FirstNameTb.ToolTip = "As it appears on the credit card";
            LastNameTb.ToolTip = "As it appears on the credit card";
            AddressTb.ToolTip = "As it appears on the credit card";
            AptTb.ToolTip = "Apartment / suite / box or Address cont";
            ZipCodeTb.ToolTip = "As it appears on the credit card";
            CityTb.ToolTip = "As it appears on the credit card";
            StateTb.ToolTip = "As it appears on the credit card";
            PhoneTb.ToolTip = "If customer refuses, assure them it will only be used to" +
                                "\ncontact them in case there is a problem with the order";
            EmailTb.ToolTip = "Email address is used to send customer \nshipping confirmation and tracking information";
            SavingsCodeTb.ToolTip = "Savings code can be found on the back of the catalog," +
                                "\nimmediately above the customer's name on the mailing label";
            DiscountCodeTb.ToolTip = "Do not ask customer for this, only enter when " +
                                    "\nthe customer provides it on their own";
            BirthdayTb.ToolTip = "Prompt: \"We send out 40% discount coupons for all of our customers on" +
                                "\ntheir birthday, we need only the month and day, we don't need the full birthday,\"" +
                                "\nIf customer refuses request just the month only (example: 10/12 or 10)";
            AVSTb.ToolTip = "This will be the first set of numbers on the address," +
                            "\nfor example 123 United way it would be 123, in case of" +
                            "\na PO Box it would be the number of the PO Box, for exmaple" +
                            "\nPO Box 4480 it would be 4480";
        }

        private void PaymentToolTip(string method)
        {
            switch (method)
            {
                case "Check":
                    PaymentNumberTb.ToolTip = "Enter the Check or Money Order #";
                    break;
                case "AMEX":
                    PaymentNumberTb.ToolTip = "15 digit credit card #";
                    ExpDateTb.ToolTip = "Month and year of expiration (10/10)";
                    CCVTb.ToolTip = "This is found on the back of the card" +
                                    "\nabove the signature, it is the last" +
                                    "\nthree digits following the four digit" +
                                    "\nnumber that is the same as the card #";
                    break;
                case "Credit":
                    PaymentNumberTb.ToolTip = "16 digit credit card #";
                    ExpDateTb.ToolTip = "Month and year of expiration (10/10)";
                    CCVTb.ToolTip = "This is the four digit code on the front" +
                                    "of the card, it is usually in a box above" +
                                    "the sixteen digit card #";
                    break;
            }
        }
    #endregion

    #region Events
        private void OrderTypeCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)OrderTypeCb.SelectedItem;

            string text = "";
            if (cbi.Content != null)
            {
                text = cbi.Content.ToString();
            }
            if (text.Equals("Mail"))
            {
                PaymentCb.Items.Clear();
                PaymentCb.Items.Add("Check / Money Order");
                PaymentCb.Items.Add("Visa");
                PaymentCb.Items.Add("Master Card");
                PaymentCb.Items.Add("American Express");
                PaymentCb.Items.Add("Discover");
            }
            if (text.Equals("Phone"))
            {
                PaymentCb.Items.Clear();
                PaymentCb.Items.Add("Visa");
                PaymentCb.Items.Add("Master Card");
                PaymentCb.Items.Add("American Express");
                PaymentCb.Items.Add("Discover");
            }
        }

        #region DataGrid, ListBox, ComboBox

        private void PaymentCb_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            enablePayment(cb.Text);
        }

        private void OrderHistoryDg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            if (!dg.Items.IsEmpty && dg.SelectedItem != null)
            {
                OrderSummaryTb.Text = Order.GetSummary((Order)dg.SelectedItem);
            }
        }

        private void CategoryListLb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem selectedBox = CategoryListLb.SelectedItem as ListBoxItem;
            Search(selectedBox.Content.ToString(), 2);
            ProductTypeTb.Text = string.Empty;
        }

        private void ListViewDg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!ListViewDg.Items.IsEmpty && ListViewDg.SelectedItem != null)
            {
                DataGrid dg = sender as DataGrid;
                AddItemWindow window = new AddItemWindow((Catalog)dg.SelectedValue, this);
                window.Show();
            }
        }

        private void ListViewDg_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ProductID")
            {
                e.Column.Header = "ID";
            }
            if (e.Column.Header.ToString() == "ProductName")
            {
                e.Column.Header = "Name";
            }
            if (e.Column.Header.ToString() == "ShortDescription")
            {
                e.Column.Header = "Description";
            }
            if (e.Column.Header.ToString() == "FullDescription")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "EntityKey")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "EntityState")
            {
                e.Cancel = true;
            }
        }

        private void OrderHistoryDg_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "OrderNumber")
            {
                e.Column.Header = "Order #";
            }
            if (e.Column.Header.ToString() == "CustomerNumber")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "FirstName")
            {
                e.Column.Header = "First Name";
            }
            if (e.Column.Header.ToString() == "LastName")
            {
                e.Column.Header = "Last Name";
            }
            if (e.Column.Header.ToString() == "ZipCode")
            {
                e.Column.Header = "Zip Code";
            }
            if (e.Column.Header.ToString() == "ProductList")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "ShippingCost")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "TotalCost")
            {
                e.Column.Header = "Cost";
            }
            if (e.Column.Header.ToString() == "EntityKey")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "EntityState")
            {
                e.Cancel = true;
            }
        }

        private void ProductListDg_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ProductID")
            {
                e.Column.Header = "ID";
            }
            if (e.Column.Header.ToString() == "ProductName")
            {
                e.Column.Header = "Name";
            }
            if (e.Column.Header.ToString() == "ShortDescription")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "FullDescription")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "EntityKey")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "EntityState")
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region TextBoxes

        private void NameSearchBox(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            Search(tb.Text, 1);
            ProductNameTb.Text = string.Empty;
        }

        private void TypeSearchBox(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            Search(tb.Text, 2);
            ProductTypeTb.Text = string.Empty;
        }

        private void KeywordSearchBox(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            Search(tb.Text, 3);
            KeyWordsTb.Text = string.Empty;
        }

        private void LostFocus_ZipCodeTb(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            ZipCodeTable zip;
            if (ZipCodeTable.FindZipOrPostalCode(tb.Text, out zip))
            {
                CityTb.Text = zip.City;
                StateTb.Text = zip.State;
            }
        }

        #endregion

        #region Menus

        private void ImportZipMi_Click(object sender, RoutedEventArgs e)
        {
            FileInput input = new FileInput();
            OpenFileDialog dialog = new OpenFileDialog();
            try
            {
                if (dialog.ShowDialog() != false)
                {
                    input.ReadZipCodes(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void ImportCustomerMi_Click(object sender, RoutedEventArgs e)
        {
            FileInput input = new FileInput();
            OpenFileDialog dialog = new OpenFileDialog();
            try
            {
                if (dialog.ShowDialog() != false)
                {
                    input.ReadCustomers(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void ImportCatalogMi_Click(Object sender, EventArgs e)
        {
            FileInput input = new FileInput();
            OpenFileDialog dialog = new OpenFileDialog();
            try
            {
                if (dialog.ShowDialog() != false)
                {
                    input.ReadCatalog(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        #endregion

        #region Buttons

        private void FindCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            FindCustomerWindow findWindow = new FindCustomerWindow(this);
            findWindow.Visibility = Visibility.Visible;
        }

        private void PlaceOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsOrderComplete())
            {
                int orderNumber;
                if (CustomerIDTb.Text == "" || CustomerIDTb == null)
                {
                    AddCustomer();
                    int customerID = manager.FindCustomerNumber(FirstNameTb.Text, LastNameTb.Text,
                        AddressTb.Text, ZipCodeTb.Text);
                    orderNumber = Order.PlaceOrder(ListOfProducts, customerID);
                }
                else
                {
                    int customerID;
                    int.TryParse(CustomerIDTb.Text, out customerID);
                    orderNumber = Order.PlaceOrder(ListOfProducts, customerID);
                }
                MessageBox.Show(string.Format("Order has been processed. Order: {0}", orderNumber));
                ClearSession();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

            if (ProductNameTb.Text != "")
            {
                Search(ProductNameTb.Text, 1);
            }
            if (ProductTypeTb.Text != "")
            {
                Search(ProductTypeTb.Text, 2);
            }
            if (KeyWordsTb.Text != "")
            {
                Search(KeyWordsTb.Text, 3);
            }


        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ProductNameTb.Text = "";
            ProductTypeTb.Text = "";
            KeyWordsTb.Text = "";
            ListViewDg.ItemsSource = new List<Catalog>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClearSession();
        }

        #endregion

    #endregion

    #region Validation Methods

        private bool IsOrderComplete()
        {
            if (!IsBillingComplete())
            {
                MessageBox.Show("Please complete the billing information");
                return false;
            }         
            if (!IsShippingComplete())
            {
                MessageBox.Show("Please complete the shipping information");
                return false;
            }
            if (ListOfProducts.Count() == 0)
            {
                MessageBox.Show("You must add at least one item to the order");
                return false;
            }
            if (!IsPaymentComplete())
            {
                MessageBox.Show("Please verify the payment information");
                return false;
            }
            return true;
        }

        private bool IsBillingComplete()
        {
            if (FirstNameTb.Text == "" || FirstNameTb.Text == null)
            {
                return false;
            }
            if (LastNameTb.Text == "" || LastNameTb.Text == null)
            {
                return false;
            }
            if (AddressTb.Text == "" || AddressTb.Text == null)
            {
                return false;
            }
            if (CityTb.Text == "" || CityTb.Text == null)
            {
                return false;
            }
            if (StateTb.Text == "" || StateTb.Text == null)
            {
                return false;
            }
            if (ZipCodeTb.Text == "" || ZipCodeTb.Text == null)
            {
                return false;
            }
            if (PhoneTb.Text == "" || PhoneTb.Text == null)
            {
                return false;
            }
            if (SavingsCodeTb.Text == "" || SavingsCodeTb.Text == null)
            {
                return false;
            }
            if (AVSTb.Text == "" || AVSTb.Text == null)
            {
                return false;
            }
            return true;
        }

        private bool IsShippingComplete()
        {
            if (ShippingFirstNameTb.Text == "" || ShippingFirstNameTb.Text == null)
            {
                return false;
            }
            if (ShippingLastNameTb.Text == "" || ShippingLastNameTb.Text == null)
            {
                return false;
            }
            if (ShippingAddressTb.Text == "" || ShippingAddressTb.Text == null)
            {
                return false;
            }
            if (ShippingCityTb.Text == "" || ShippingCityTb.Text == null)
            {
                return false;
            }
            if (ShippingStateTb.Text == "" || ShippingStateTb.Text == null)
            {
                return false;
            }
            if (ShippingZipCodeTb.Text == "" || ShippingZipCodeTb.Text == null)
            {
                return false;
            }
            if (ShippingPhoneTb.Text == "" || ShippingPhoneTb.Text == null)
            {
                return false;
            }
            if (ShippingTypeCb.Text == "" || ShippingTypeCb.Text == null)
            {
                return false;
            }
            return true;
        }

        private bool IsPaymentComplete()
        {
            PaymentViewModel pvm = new PaymentViewModel();
            pvm.PaymentType = PaymentCb.Text;
            if (!pvm.ValidatePaymentNumber(PaymentNumberTb.Text))
            {
                return false;
            }
            if(!pvm.IsValidExpDate(ExpDateTb.Text))
            {
                return false;
            }
            if(!pvm.IsValidCvv(CCVTb.Text))
            {
                return false;
            }
            return true;
        }

    #endregion

        //private void OutPutDatabases()
        //{
        //    BLHCustomerDbEntities entites = new BLHCustomerDbEntities();
        //    using (StreamWriter writer = new StreamWriter("customers.csv"))
        //    {
        //        foreach( BLHCustomer c in entites.BLHCustomers)
        //        {
        //            writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},", 
        //                c.FirstName, c.LastName, c.Address, c.Apt, c.City, c.State, c.Zip, 
        //                c.Phone, c.Email, c.AVS, c.Birthday);
        //        }
        //    }
        //    using (StreamWriter writer = new StreamWriter("orders.csv"))
        //    {
        //        foreach( Order o in entites.Orders)
        //        {
        //            writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},",
        //                o.CustomerNumber, o.FirstName, o.LastName, o.ZipCode, o.ProductList, o.ShippingCost, o.TotalCost);
        //        }
        //    }
        //}

    }
}
