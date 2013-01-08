using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullContact__
{
    public partial class ZipCodeTable
    {
        public static bool FindZipOrPostalCode(string zipToFind, out ZipCodeTable zipToReturn)
        {
            zipToReturn = new ZipCodeTable();
            ZipPostalCodeDbEntities ZipCodes = new ZipPostalCodeDbEntities();
            
            IEnumerable<ZipCodeTable> matchingZipCode =
                from z in ZipCodes.ZipCodeTables
                where z.ZipCode.Equals(zipToFind)
                select z;

            if (matchingZipCode.Count() > 0)
            {
                zipToReturn = matchingZipCode.First();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
