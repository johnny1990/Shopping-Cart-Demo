using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceShoppingCartMVC.Web.Models
{
    public class Item
    {
        private Product prod = new Product();

        #region Properties
        public Product Product
        {
            get { return prod; }
            set { prod = value; }
        }
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        #endregion

        #region Constructors
        public Item()
        {

        }

        public Item(Product product, int qty)
        {
            this.prod = product;
            this.quantity = qty;
        }
        #endregion
    }
}
