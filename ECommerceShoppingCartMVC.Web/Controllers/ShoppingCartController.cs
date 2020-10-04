using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceShoppingCartMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceShoppingCartMVC.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingDBContext _context;

        public ShoppingCartController(ShoppingDBContext context)
        {
            _context = context;
        }


        #region Is product in the cart Method
        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];

            for (int i = 0; i < cart.Count; i++)

                if (cart[i].Product.Id == id)

                    return i;

            return -1;
        }
        #endregion

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            int index = isExisting(id);

            List<Item> cart = (List<Item>)Session["cart"];

            cart.RemoveAt(index);


            Session["cart"] = cart;

            return View("Cart");
        }

        public IActionResult Add(int id)
        {

            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();

                cart.Add(new Item(_context.Products.Find(id), 1));

                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];

                int index = isExisting(id);

                if (index == -1)

                    cart.Add(new Item(_context.Products.Find(id), 1));

                else

                    cart[index].Quantity++;

                Session["cart"] = cart;
            }

            return View("Cart");
        }

        public IActionResult ConfirmationMessage()
        {
            return View();
        }
    }
}
