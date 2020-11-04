using CollectionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionLogic.Entities
{
    public class OrderListEntity
    {
        public int Id { get; set; }
        public List<OrderEntity> Orders { get; set; }
        public UserEntitiy User { get; set; }

        public OrderListEntity OrderListDTOToOrderList(OrderListDTO orderList)
        {
            OrderListEntity newOrderList = new OrderListEntity()
            {
                Id = orderList.Id,
                Orders = new List<OrderEntity>(),
            };

            foreach (OrderDTO order in orderList.Orders)
            {
                Entities.OrderEntity Order = new OrderEntity().OrderDTOToOrder(order);
                newOrderList.Orders.Add(Order);
            }
            return newOrderList;
        }

        public OrderListDTO OrderToOrderDTO()
        {
            List<OrderDTO> orders = new List<OrderDTO>();
            foreach (OrderEntity order in this.Orders)
            {
                orders.Add(order.OrderToOrderDTO());
            }
            return new OrderListDTO()
            {
                Id = this.Id,
                User = new UserDTO(),
                Orders = orders
            };
        }
    }
}
