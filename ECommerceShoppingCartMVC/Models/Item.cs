using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceShoppingCartMVC.Models
{
    public class Item
    {
        private Produse produs = new Produse(); // Instantiate tblProduct class object 

        #region Properties
        public Produse Produs
        {
            get { return produs; }
            set { produs = value; }
        }
        private int cantitate;

        public int Cantitate
        {
            get { return cantitate; }
            set { cantitate = value; }
        }
        #endregion

        #region Constructors
        // Default constructor
        public Item()
        {

        }

        // Parameterised constructor
        public Item(Produse produs, int cantitate)
        {
            this.produs = produs;
            this.cantitate = cantitate;
        }
        #endregion
    }
}