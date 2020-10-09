using CollectionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionData.Controllers;

namespace CollectionFactory
{
    public class UserOrdersFactory
    {
        public static IUserOrders GetUserOrders()
        {
            return new UserOrdersController();
        }
    }
}
