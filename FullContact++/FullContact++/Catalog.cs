using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullContact__
{
    public partial class Catalog
    {
        public static IEnumerable<Catalog> FindProductFromCatalog(string searcher, int option)
        {
            BLHCustomerDbEntities entities = new BLHCustomerDbEntities();


            if (option == 1 && searcher != null)
            {
                IEnumerable<Catalog> display = (from h in entities.Catalogs
                                                where h.ProductName.Contains(searcher)
                                                select h);
                return display;

            }
            if (option == 2 && searcher != null)
            {
                IEnumerable<Catalog> display = (from h in entities.Catalogs
                                                where h.Category.Contains(searcher)
                                                select h);
                return display;
            }
            if (option == 3 && searcher != null)
            {
                IEnumerable<Catalog> display = (from h in entities.Catalogs
                                                where h.FullDescription.Contains(searcher)
                                                select h);
                return display;

            }
            return null;

        }
    }
}
    