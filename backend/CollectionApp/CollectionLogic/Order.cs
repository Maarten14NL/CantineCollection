using CollectionEntities;
using CollectionFactory;
using CollectionLogic.Entities;
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
        public List<OrderEntity> ReadAll()
        {
            List<OrderEntity> orders = new List<OrderEntity>();

            foreach (OrderDTO order in _OrderDal.ReadAll())
            {
                orders.Add(new OrderEntity().OrderDTOToOrder(order));
            }
            return orders;
        }

        public OrderEntity ReadOne(int id)
        {
            return new OrderEntity().OrderDTOToOrder(_OrderDal.ReadOne(id));
        }

        public Boolean Update(OrderEntity order)
        {
            return _OrderDal.Update(order.OrderToOrderDTO());
        }

        public Boolean Create(OrderEntity order)
        {
            return _OrderDal.Create(order.OrderToOrderDTO());
        }

        public Boolean Delete(int id)
        {
            OrderEntity order = this.ReadOne(id);
            return _OrderDal.Delete(order.OrderToOrderDTO());
        }
    }
}
