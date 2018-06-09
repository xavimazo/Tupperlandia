using Data;
using System.Collections.Generic;

namespace Tupperware_e_commerce.Models
{
    public class SaleViewModel
    {
        public Sale Sale;
        public IEnumerable<Stock> Stock;
        public IEnumerable<Client> Client;
        public IEnumerable<Product> Products;
        public IEnumerable<Dispatch> Dispatch;
    }
}