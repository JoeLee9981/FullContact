using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;

namespace FullContact__
{
    class FileInput
    {
        public ZipPostalCodeDbEntities ZipCodes { get; private set; }
        public BLHCustomerDbEntities BLHDb { get; private set; }

        public FileInput()
        {
            ZipCodes = new ZipPostalCodeDbEntities();
            BLHDb = new BLHCustomerDbEntities();
        }

        public void ReadZipCodes(string file)
        {

            using (StreamReader reader = new StreamReader(file))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    ZipCodeTable zip = new ZipCodeTable();

                    string line = reader.ReadLine();
                    string[] splitLine = line.Split(',');

                    zip.ZipCode = splitLine[0].Substring(1, splitLine[0].Length - 2);
                    zip.State = splitLine[3].Substring(1, splitLine[3].Length - 2);
                    zip.City = splitLine[2].Substring(1, splitLine[2].Length - 2);
                    ZipCodes.ZipCodeTables.AddObject(zip);
                }
                try
                {
                    ZipCodes.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to save", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        public void ReadCustomers(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    BLHCustomer customer = CreateCustomerFromLine(reader.ReadLine());
                    BLHDb.BLHCustomers.AddObject(customer);
                }
                BLHDb.SaveChanges();
            }
        }

        public void ReadCatalog(string path)
        {
            using (StreamReader readFile = new StreamReader(path))
            {
             
                readFile.ReadLine();
                while (!readFile.EndOfStream)
                {
                    string line = readFile.ReadLine();
                    Catalog catalog = CreateCatalogFromLine(line);
                    BLHDb.Catalogs.AddObject(catalog);
                }
                BLHDb.SaveChanges();
                
            }
        }

        private Catalog CreateCatalogFromLine(string line)
        {
            string[] data = line.Split(',');

            decimal price;
            decimal.TryParse(data[4], out price);
            Catalog catalog = new Catalog();
            catalog.ProductName = data[0];
            catalog.Category = data[1];
            catalog.ShortDescription = data[2];
            catalog.FullDescription = data[3];
            catalog.Price = price;

            return catalog;

        }

        private BLHCustomer CreateCustomerFromLine(string line)
        {
            BLHCustomer customer = new BLHCustomer();
            string[] splitCustomer = line.Split(',');
            customer.FirstName = splitCustomer[0];
            customer.LastName = splitCustomer[1];
            customer.Address = splitCustomer[2];
            customer.Apt = splitCustomer[3];
            customer.City = splitCustomer[4];
            customer.State = splitCustomer[5];
            customer.Zip = splitCustomer[6];
            customer.Phone = splitCustomer[7];
            customer.Email = splitCustomer[8];
            customer.AVS = splitCustomer[9];
            customer.Birthday = splitCustomer[10];
            return customer;
        }

    }
}
