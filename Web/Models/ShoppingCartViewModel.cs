using Data;
using System.Collections.Generic;

namespace Tupperware_e_commerce.Models
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart;

        public IEnumerable<Stock> Stock;
        //public IEnumerable<Client> Client;
        public IEnumerable<Client> Clients;
        public IEnumerable<Dispatch> Dispatch;
    }
}