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
            throw new NotImplementedException();
        }

        public bool Delete(OrderListDTO company)
        {
            throw new NotImplementedException();
        }

        public List<OrderListDTO> GetByUser(UserDTO user)
        {
            List<OrderListDTO> userOders = db.OrderLists
                       .Where(b => b.User.Id == 1)
                       .Include(b => b.Orders).ToList();
            return userOders;
        }

        public List<OrderListDTO> Read(int? id = null)
        {
            throw new NotImplementedException();
        }

        public bool Update(OrderListDTO company)
        {
            throw new NotImplementedException();
        }
    }
}
