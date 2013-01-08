using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullContact__
{
    public class LineItem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost
        {
            get
            {
                return Quantity * Price;
            }
        }

        public LineItem(int prodID, string prodName, decimal price, int quantity)
        {
            ProductID = prodID;
            ProductName = prodName;
            Price = price;
            Quantity = quantity;
        }

    }
}
