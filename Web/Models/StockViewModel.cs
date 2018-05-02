using Data;
using System.Collections.Generic;

namespace Tupperware_e_commerce.Models
{
    public class StockViewModel
    {
        public Stock Stock;
        public IEnumerable<Discount> Discounts;
        public IEnumerable<PublicationStatus> PublicationStatus;        
        public IEnumerable<Product> Products;
    }
}