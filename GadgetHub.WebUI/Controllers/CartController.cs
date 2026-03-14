using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Entites;
using GadgetHub.Domain.Entities;
using GadgetHub.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GadgetHub.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IGadgetRepository repository;
        public CartController(IGadgetRepository repo)
        {
            repository = repo;
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public RedirectToRouteResult AddToCart(int gadgetID, string returnUrl)
        {
            Gadget gadget = repository.Gadgets.FirstOrDefault
                                               (g => g.GadgetID == gadgetID);
            if (gadget != null)
            {
                GetCart().AddItem(gadget, 1);
            }
            return RedirectToAction("Index", new {returnUrl});

        }

        public RedirectToRouteResult RemoveFromCart(int gadgetID, string returnUrl)
        {
            Gadget gadget = repository.Gadgets.FirstOrDefault
                                               (g => g.GadgetID == gadgetID);
            if (gadget != null)
            {
                GetCart().RemoveLine(gadget);
            }

            return RedirectToAction("Index", new {returnUrl});
        
        }

    }
}