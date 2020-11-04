using CollectionEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionData.Controllers
{
    public class UserOrdersController : IUserOrders
    {
        readonly CollectionDatabase db = new CollectionDatabase();

        public bool Create(OrderListDTO company)
        {
            if (company != null)
            {
                db.OrderLists.Add(company);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(OrderListDTO company)
        {
            if (company != null)
            {
                db.OrderLists.Remove(company);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<OrderListDTO> ReadAll()
        {
            return db.OrderLists.ToList();
        }

        public OrderListDTO ReadOne(int id)
        {
            return db.OrderLists.SingleOrDefault(o => o.Id == id);
        }

        public bool Update(OrderListDTO company)
        {
            OrderListDTO result = db.OrderLists.SingleOrDefault(o => o.Id == company.Id);
            if (result != null)
            {
                result.Orders = company.Orders;
                result.User = company.User;

                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<OrderListDTO> GetByUser(UserDTO user)
        {
            List<OrderListDTO> userOders = db.OrderLists
                       .Where(b => b.User.Id == 1)
                       .Include(b => b.Orders).ToList();
            return userOders;
        }
    }
}
