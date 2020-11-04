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
    public class OrderList
    {
        private readonly IUserOrders _OrderListDal = UserOrdersFactory.GetUserOrders();
        public List<OrderListEntity> ReadAll()
        {
            List<OrderListEntity> orders = new List<OrderListEntity>();

            foreach (OrderListDTO order in _OrderListDal.ReadAll())
            {
                orders.Add(new OrderListEntity().OrderListDTOToOrderList(order));
            }
            return orders;
        }

        public OrderListEntity ReadOne(int id)
        {
            return new OrderListEntity().OrderListDTOToOrderList(_OrderListDal.ReadOne(id));
        }

        public Boolean Update(OrderListEntity order)
        {
            return _OrderListDal.Update(order.OrderToOrderDTO());
        }

        public Boolean Create(OrderListEntity order)
        {
            return _OrderListDal.Create(order.OrderToOrderDTO());
        }

        public Boolean Delete(int id)
        {
            OrderListEntity order = this.ReadOne(id);
            return _OrderListDal.Delete(order.OrderToOrderDTO());
        }
    }
}
