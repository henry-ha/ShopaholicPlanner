using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopaholicPlanner.Models;
using ShopaholicPlanner.Service.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ShopaholicPlanner.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private static string userId = string.Empty;

        public ActionResult Index()
        {
            ShoppingBasketCollectionModel model = new ShoppingBasketCollectionModel();
            model.ShoppingBasketItems = new List<ShoppingBasketModel>();

            //get basket items for user
            BasketRepository br = new BasketRepository();
            
            var user = UserManager.FindByEmail(this.User.Identity.Name);            
            if (user != null)
            {
                userId = user.Id;
                model.IsLoggedIn = true;
            } else
            {
                userId = "";
                model.IsLoggedIn = false;
            }
           
            var items = br.LoadByUserId(userId).ToList();
            
            foreach (var item in items.Where(x => x.ArchiveDateUTC == null))
            {
                var m = new ShoppingBasketModel();
                m.Id = item.Id;
                m.Name = item.Name;
                m.Description = item.Description;
                m.Currency = item.Currency;
                m.Price = item.Price;
                m.Quantity = item.Quantity;
                m.Url = item.Url;
                model.ShoppingBasketItems.Add(m);
            }

            return View(model);
        }

        public ActionResult BasketItemRow()
        {
            return PartialView("BasketItemEditor");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Shopaholic? - Shopping addict! ;-)";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult InsertUpdateBasket(List<ShoppingBasketModel> items)
        {
            BasketRepository br = new BasketRepository();

            var user = UserManager.FindByEmail(this.User.Identity.Name);
            if (user != null)
            {
                userId = user.Id;
            }
            var userBasket = br.LoadByUserId(userId).ToList();
            if (userBasket == null) { userBasket = new List<ShoppingBasket>(); }

            userBasket = userBasket.Where(x => x.ArchiveDateUTC == null).ToList();

            foreach (var item in items.Where(x => x.Id > 0))
            {
                //updates
                ShoppingBasket m = userBasket.Where(y => y.Id == item.Id).FirstOrDefault();
                m.Name = item.Name;
                m.Description = item.Description;
                m.Currency = item.Currency;
                m.Price = item.Price;
                m.Quantity = item.Quantity;
                m.Url = item.Url;
            }
            
            foreach (var item in items.Where(x => x.Id == 0))
            {
                //inserts
                var m = new ShoppingBasket();
                m.Id = (item.Id > 0 ? item.Id : 0);
                m.Name = item.Name;
                m.Description = item.Description;
                m.Currency = item.Currency;
                m.Price = item.Price;
                m.Quantity = item.Quantity;
                m.Url = item.Url;
                m.UserId = userId;
                userBasket.Add(m);
            }

            br.InsertUpdateBasket(userBasket);

            return Json(true);
        }

        public ActionResult RemoveFromBasket(int id)
        {
            BasketRepository br = new BasketRepository();

            var user = UserManager.FindByEmail(this.User.Identity.Name);
            if (user != null)
            {
                userId = user.Id;
            }

            if (!string.IsNullOrWhiteSpace(userId))
            {                               
                var item = br.LoadById(id);                
                if (item.UserId == userId)
                {
                    //valid user, allow delete
                    item.ArchiveDateUTC = DateTime.UtcNow;
                    br.RemoveFromBasket(item);
                }                
            }

            return View();
        }

    }
}