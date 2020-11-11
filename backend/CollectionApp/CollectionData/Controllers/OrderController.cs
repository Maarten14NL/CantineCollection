using CollectionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionData.Controllers
{
    public class OrderController : IOrder
    {
        CollectionDatabase db = new CollectionDatabase();
        public bool Create(OrderDTO order)
        {
            if (order != null)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(OrderDTO order)
        {
            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<OrderDTO> ReadAll()
        {
            return db.Orders.ToList();
        }

        public OrderDTO ReadOne(int id)
        {
            return db.Orders.SingleOrDefault(o => o.Id == id);
        }

        public bool Update(OrderDTO order)
        {

            OrderDTO result = db.Orders.SingleOrDefault(o => o.Id == order.Id);
            if (result != null)
            {
                result.Amount = order.Amount;
                result.Name = order.Name;

                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
