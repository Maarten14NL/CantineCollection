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

        public List<Entities.UserEntitiy> Read()
        {
            List<UserDTO> users = _UserDal.Read();
            List<Entities.UserEntitiy> peatUsers = new List<Entities.UserEntitiy>();

            foreach (UserDTO user in users)
            {
                Entities.OrderListEntity activeOrderList = new Entities.OrderListEntity().OrderListDTOToOrderList(_UserOrdersDal.GetByUser(user).Last());
                peatUsers.Add(new Entities.UserEntitiy()
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

        public void updateOrder(Entities.OrderEntity order)
        {
            OrderDTO LastOrder = order.OrderToOrderDTO();
            Boolean test = _OrderDal.Update(LastOrder);
        }
    }
}
