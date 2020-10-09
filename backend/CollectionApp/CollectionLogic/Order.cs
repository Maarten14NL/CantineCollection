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
        private readonly IUserOrders _UserOrdersDal = UserOrdersFactory.GetUserOrders();
        public List<OrderDTO> Read(int? id = null)
        {
            throw new NotImplementedException();
            //List<OrderDTO> orderList = _UserOrdersDal.Read(id);
            //return orderList;
        }

        public List<OrderListDTO> GetLoggedInUserOrders()
        {
            UserDTO loggedInUser = new Auth().GetLoggedInUser();
            return _UserOrdersDal.GetByUser(loggedInUser);
        }
    }
}
