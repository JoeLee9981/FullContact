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
using System.Windows.Shapes;

namespace FullContact__
{
    /// <summary>
    /// Interaction logic for FindCustomerWindow.xaml
    /// </summary>
    public partial class FindCustomerWindow : Window
    {
        CustomerManager customerManager;
        List<BLHCustomer> customerList;
        MainWindow mainWindow;

        public FindCustomerWindow(MainWindow mw)
        {
            InitializeComponent();
            customerManager = new CustomerManager();
            mainWindow = mw;
        }

        private void DisplayCustomerList()
        {
            var displayList =
                from c in customerList
                select new { c.FirstName, c.LastName, c.Address, c.City, c.State };
            CustomerDataGrid.ColumnWidth = 90;
            CustomerDataGrid.ItemsSource = displayList.ToList();
        }
 
        #region Events
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            CustomerDataGrid.ItemsSource = new List<BLHCustomer>();


            string customerID = CustomerIDTB.Text;
            string lastName = LastNameTB.Text;
            string firstName = FirstNameTB.Text;
            string zip = ZipTB.Text;
            try
            {
                customerList = (customerManager.FindCustomer(customerID, lastName, firstName, zip).ToList<BLHCustomer>());
                DisplayCustomerList();
            }
            catch (ArgumentException ae)
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show(ae.Message, "Incorrect Search", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }


        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CustomerDataGrid.Items.IsEmpty && CustomerDataGrid.SelectedItem != null)
            {
                int index = CustomerDataGrid.SelectedIndex;
                mainWindow.ViewCustomer(customerList[index]);
                this.Close();
            }
            else
            {
                MessageBox.Show("You MUST select a customer record", "Incorrect Selection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void CustomerDataGrid_DoubleClick(object sender, MouseEventArgs e)
        {
            if (!CustomerDataGrid.Items.IsEmpty && CustomerDataGrid.SelectedItem != null)
            {
                int index = CustomerDataGrid.SelectedIndex;
                mainWindow.ViewCustomer(customerList[index]);
                this.Close();
            }
        }
        #endregion

    }
}
