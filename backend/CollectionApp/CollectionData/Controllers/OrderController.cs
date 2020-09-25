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
        public bool Create(OrderDTO company)
        {
            throw new NotImplementedException();
        }

        public bool Delete(OrderDTO company)
        {
            throw new NotImplementedException();
        }

        public List<OrderDTO> Read(int? id = null)
        {
            //throw new NotImplementedException();
            var query = from b in db.Orders
                        orderby b.Name
                        select b;

            List<OrderDTO> orders = db.Orders.ToList();
            return orders;
        }

        public bool Update(OrderDTO company)
        {
            throw new NotImplementedException();
        }
    }
}
