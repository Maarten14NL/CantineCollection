using CollectionEntities;
using CollectionFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionLogic
{
    public class Peat
    {
        private readonly IUser _UserDal = UserFactory.GetUser();
        private readonly IUserOrders _UserOrdersDal = UserOrdersFactory.GetUserOrders();
        private readonly IOrder _OrderDal = OrderFactory.GetOrder();

        public List<Entities.User> Read()
        {
            List<UserDTO> users = _UserDal.Read();
            List<Entities.User> peatUsers = new List<Entities.User>();

            foreach (UserDTO user in users)
            {
                Entities.OrderList activeOrderList = new Entities.OrderList().OrderListDTOToOrderList(_UserOrdersDal.GetByUser(user).Last());
                peatUsers.Add(new Entities.User()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    ProfilePicture = user.ProfilePicture,
                    OrderList = activeOrderList,
                    LastOrder = activeOrderList.Orders.Last()
                });
            }


            return peatUsers;
        }

        public void updateOrder(Entities.Order order)
        {
            OrderDTO LastOrder = order.OrderToOrderDTO(order);
            Boolean test = _OrderDal.Update(LastOrder);
        }
    }
}
