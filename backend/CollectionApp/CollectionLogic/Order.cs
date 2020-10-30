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
        private readonly IUserOrders _UserOrdersDal = UserOrdersFactory.GetUserOrders();
        private readonly IProduct _ProductDal = ProductFactory.GetAssortiment();
        public List<OrderDTO> Read(int? id = null)
        {
            throw new NotImplementedException();
            //List<OrderDTO> orderList = _UserOrdersDal.Read(id);
            //return orderList;
        }

        public List<OrderList> GetLoggedInUserOrders()
        {
            UserDTO loggedInUser = new Auth().GetLoggedInUser();

            List<OrderListDTO> OrderListDTO = _UserOrdersDal.GetByUser(loggedInUser);

            List <OrderList> myOrderLists= new List<OrderList>();
            foreach (OrderListDTO item in OrderListDTO)
            {
                OrderList myOrderList = new OrderList().OrderListDTOToOrderList(item);
                myOrderLists.Add(myOrderList);
            }

            return myOrderLists;
        }
    }
}
