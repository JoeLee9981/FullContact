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
    /// Interaction logic for AddItemWindow.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {

        public Catalog Product { get; private set; }
        public MainWindow mw;

        public AddItemWindow(Catalog prod, MainWindow mw)
        {
            InitializeComponent();
            Product = prod;
            this.mw = mw;
            ProductNameLb.Content = prod.ProductName;
            ItemDescriptionTb.Text = prod.FullDescription;
        }

        private void AddToOrderButton_Click(object sender, RoutedEventArgs e)
        {
            int quantity;
            if (int.TryParse(QuanityValue.Text, out quantity))
            {
                LineItem item = new LineItem(Product.ProductID, Product.ProductName, (decimal)Product.Price, quantity);
                mw.ListOfProducts.Add(item);
                List<LineItem> list = mw.ListOfProducts;
                mw.ProductListDg.ItemsSource = new List<LineItem>();
                mw.ProductListDg.ItemsSource = list;
                mw.UpdateOrderTotal();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid quantity entered");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
