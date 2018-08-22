using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopaholicPlanner.Service.Repositories
{
    public class BasketRepository
    {
        private ShopaholicPlannerContext _context;

        public BasketRepository(ShopaholicPlannerContext context)
        {
            this._context = context;
        }

        public ShoppingBasket LoadById(int id)
        {
            ShoppingBasket item = null;
            if (id > 0)
            {
                item = _context.ShoppingBaskets
                    .Where(x => x.Id == id).FirstOrDefault();
            }

            return item;
        }

        //public List<ShoppingBasket> LoadByUserId(string id)
        //{
        //    List<ShoppingBasket> items = null;
        //    if (!string.IsNullOrWhiteSpace(id))
        //    {
        //        items = _context.ShoppingBaskets
        //            .Where(x => x.User.Id == id).ToList();
        //    }

        //    return items;
        //}

        public IEnumerable<ShoppingBasket> LoadByUserId(string id)
        {
            IEnumerable<ShoppingBasket> items;
            items = _context.ShoppingBaskets
                    .Where(x => x.User.Id == id); ;

            return items;
        }

        public bool InsertUpdateBasket(List<ShoppingBasket> items)
        {            
            if (items != null)
            {                
                foreach (var item in items.Where(x => x.Id > 0))
                {
                    //existing
                    item.UpdateDateUTC = DateTime.UtcNow;
                    _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }

                foreach (var item in items.Where(x => x.Id == 0))
                {
                    _context.Entry(item).State = System.Data.Entity.EntityState.Added;
                }

                _context.SaveChanges();                
            }

            return true;
        }

    }
}