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
    public class LoggedInUser
    {
        private readonly IUserOrders _UserOrdersDal = UserOrdersFactory.GetUserOrders();
        public List<OrderListEntity> GetLoggedInUserOrders()
        {
            UserDTO loggedInUser = new Auth().GetLoggedInUser();

            List<OrderListDTO> OrderListDTO = _UserOrdersDal.GetByUser(loggedInUser);

            List<OrderListEntity> myOrderLists = new List<OrderListEntity>();
            foreach (OrderListDTO item in OrderListDTO)
            {
                OrderListEntity myOrderList = new OrderListEntity().OrderListDTOToOrderList(item);
                myOrderLists.Add(myOrderList);
            }

            return myOrderLists;
        }
    }
}
