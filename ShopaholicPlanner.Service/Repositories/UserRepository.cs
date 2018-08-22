using System.Linq;

namespace ShopaholicPlanner.Service.Repositories
{
    public class UserRepository
    {
        private ShopaholicPlannerContext _context;

        public UserRepository()
        {
            ShopaholicPlannerContext context = new ShopaholicPlannerContext();
            this._context = context;
        }

        public User LoadByUserId(string id)
        {
            User user = null;
            if (!string.IsNullOrWhiteSpace(id))
            {
                user = _context.Users
                    .Where(x => x.Id == id).FirstOrDefault();
            }

            return user;
        }
       
    }
}