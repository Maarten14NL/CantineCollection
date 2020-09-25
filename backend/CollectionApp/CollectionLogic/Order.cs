using CollectionEntities;
using CollectionFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionLogic
{
    public class Order
    {
        private readonly IOrder _OrderDal = OrderFactory.GetOrder();
        public List<OrderDTO> Read(int? id = null)
        {
            List<OrderDTO> orderList = _OrderDal.Read(id);
            return orderList;
        }
    }
}
