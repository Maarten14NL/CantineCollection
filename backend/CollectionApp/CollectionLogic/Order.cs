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
        private readonly IProduct _ProductsDal = ProductFactory.GetAssortiment();
        public List<OrderDTO> Read(int? id = null)
        {
            throw new NotImplementedException();
            //List<OrderDTO> orderList = _UserOrdersDal.Read(id);
            //return orderList;
        }

        public List<OrderListDTO> GetLoggedInUserOrders()
        {
            UserDTO loggedInUser = new Auth().GetLoggedInUser();

            List<OrderListDTO> OrderListDTO = _UserOrdersDal.GetByUser(loggedInUser);
            foreach (OrderDTO order in OrderListDTO[0].Orders)
            {
                order.Name = _ProductsDal.Read();
            }
            return _UserOrdersDal.GetByUser(loggedInUser);
        }
    }
}
