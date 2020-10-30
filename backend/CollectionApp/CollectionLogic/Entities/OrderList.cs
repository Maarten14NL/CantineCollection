using CollectionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionLogic.Entities
{
    public class OrderList
    {
        public int Id { get; set; }
        public List<Order> Orders { get; set; }

        public OrderList OrderListDTOToOrderList(OrderListDTO orderList)
        {
            OrderList newOrderList = new OrderList()
            {
                Id = orderList.Id,
                Orders = new List<Entities.Order>(),
            };

            foreach (OrderDTO order in orderList.Orders)
            {
                Entities.Order Order = new Order().OrderDTOToOrder(order);
                newOrderList.Orders.Add(Order);
            }
            return newOrderList;
        }
    }
}
