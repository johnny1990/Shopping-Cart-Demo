using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceShoppingCartMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using ECommerceShoppingCartMVC.Web.Helpers;
//using System.Web.Mvc;


namespace ECommerceShoppingCartMVC.Web.Controllers
{
    //[Route("ShoppingCart")]
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingDBContext _context;

        public ShoppingCartController(ShoppingDBContext context)
        {
            _context = context;
        }

        public IActionResult Cart()
        {
            var cart = CartSessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.Cart = cart;
         
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            return View();
        }

        public async Task<IActionResult> Buy(int id)
        {
            Product productModel = new Product();
            if (CartSessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = await _context.Products.FindAsync(id), Quantity = 1 });
                CartSessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = CartSessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExisting(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = await _context.Products.FindAsync(id), Quantity = 1 });
                }
                CartSessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Cart");
        }

        public IActionResult Delete(int id)
        {

            List<Item> cart = CartSessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExisting(id);
            cart.RemoveAt(index);
            CartSessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("cart");
        }

        private int isExisting(int id)
        {
            List<Item> cart = CartSessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))//
                {
                    return i;
                }
                
            }

            return -1;
        }
    }
}