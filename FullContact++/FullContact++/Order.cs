using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace FullContact__
{
    public partial class Order
    {

    #region Find Order Methods
        public static IEnumerable<Order> FindOrdersByCustomer(int customerNumber)
        {
            BLHCustomerDbEntities customers = new BLHCustomerDbEntities();

            IEnumerable<Order> orderByCustomer =
                from order in customers.Orders
                where order.CustomerNumber == customerNumber
                select order;

            return orderByCustomer;
        }

        public static IEnumerable<Order> FindOrdersByLastZip(string lastName, string zip)
        {
            BLHCustomerDbEntities customers = new BLHCustomerDbEntities();

            IEnumerable<Order> orderByCustomer =
                from order in customers.Orders
                where order.LastName.Equals(lastName) && order.ZipCode.Equals(zip)
                select order;

            return orderByCustomer;
        }

        public static string GetSummary(Order order)
        {
            if (order == null)
            {
                return "";
            }
            string[] productList = order.ProductList.Split(',');
            string summary = string.Format("Order #:{0,-20}Customer #: {1,-20}\nName: {2}, {3}\nZip Code: {4}\n",
                order.OrderNumber, order.CustomerNumber, order.LastName, order.FirstName, order.ZipCode);
            summary += string.Format("{0,-35}{1,-15}{2}\n", "Product Name", "Cost", "Quantity");
            for (int i = 0; i < productList.Length - 2; i += 3)
            {
                decimal cost;
                decimal.TryParse(productList[i + 1], out cost);
                summary += string.Format("{0,-35}{1,-25:C} {2}\n", productList[i], cost, productList[i + 2]);
            }
            summary += string.Format("Shipping Cost: {0}\nTotal Cost: {1}", order.ShippingCost, order.TotalCost);
            return summary;
        }

    #endregion

    #region Place Order Methods

        public static int PlaceOrder(List<LineItem> productList, int customerNumber)
        {
            BLHCustomerDbEntities entities = new BLHCustomerDbEntities();
            CustomerManager manager = new CustomerManager();
            BLHCustomer customer = manager.FindCustomer(customerNumber);

            Order order = CreateOrder(productList, customer);
            entities.Orders.AddObject(order);
            entities.SaveChanges();
            
            return GetOrderNumber(order.CustomerNumber, order.FirstName, 
                order.LastName, order.ZipCode, order.ProductList);
        }

        private static Order CreateOrder(List<LineItem> productList, BLHCustomer customer)
        {
            Order order = new Order();
            order.CustomerNumber = customer.CustomerID;
            order.FirstName = customer.FirstName;
            order.LastName = customer.LastName;
            order.ZipCode = customer.Zip;
            string productListAsString = CreateProductList(productList);
            order.ProductList = productListAsString;
            order.ShippingCost = GetShippingCost("");
            order.TotalCost = GetProductTotals(productList) + order.ShippingCost;
            return order;
        }

        private static string CreateProductList(List<LineItem> productList)
        {
            string productListAsString = "";
            foreach (LineItem l in productList)
            {
                productListAsString += string.Format("{0},{1},{2},", l.ProductName, l.Price, l.Quantity);
            }
            return productListAsString;
        }

        private static decimal GetProductTotals(List<LineItem> productList)
        {
            decimal totalCost = 0;
            foreach (LineItem l in productList)
            {
                totalCost += l.Price;
            }
            return totalCost;
        }

        private static int GetOrderNumber(int customerNumber, string firstName, string lastName,
            string zipCode, string productList)
        {
            BLHCustomerDbEntities entities = new BLHCustomerDbEntities();

            int orderNumber = 
                (from o in entities.Orders
                where customerNumber == o.CustomerNumber && firstName.Equals(o.FirstName) &&
                    lastName.Equals(o.LastName) && zipCode.Equals(o.ZipCode) && productList.Equals(o.ProductList)
                    select o.OrderNumber).First();

            return orderNumber;
        }

        public static decimal GetShippingCost(string shippingType)
        {
            return 19.95M;
        }
    #endregion
    }

}
