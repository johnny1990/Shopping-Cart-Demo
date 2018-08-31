using ECommerceShoppingCartMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceShoppingCartMVC.Controllers
{
    public class CosCumparaturiController : Controller
    {
       private ShoppingDBEntities db = new ShoppingDBEntities(); 

        #region Is product in the cart Method
        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];

            for (int i = 0; i < cart.Count; i++)

                if (cart[i].Produs.Id == id) 

                    return i; 

            return -1; 
        }
        #endregion

        #region Delete Action
        public ActionResult Delete(int id)
        {
            int index = isExisting(id); 

            List<Item> cart = (List<Item>)Session["cart"];

            cart.RemoveAt(index); 


            Session["cart"] = cart; 

            return View("Cart");
        }
        #endregion

        #region Order Now Action
        public ActionResult Add(int id)
        {

            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();

                cart.Add(new Item(db.Produses.Find(id), 1)); 

                Session["cart"] = cart; 
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];

                int index = isExisting(id); 

                if (index == -1) 

                    cart.Add(new Item(db.Produses.Find(id), 1)); 

                else 

                    cart[index].Cantitate++; 

                Session["cart"] = cart; 
            }

            return View("Cart");
        }
        #endregion

        public ActionResult ConfirmationMessage()
        {
            return View();
        }
    }
}