using CollectionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionData.Controllers;

namespace CollectionFactory
{
    public class OrderListFactory
    {
        public static IOrderList GetOrderList()
        {
            return new OrderListController();
        }
    }
}
