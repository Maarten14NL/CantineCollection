using CollectionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionData.Controllers;

namespace CollectionFactory
{
    public class OrderFactory
    {
        public static IOrder GetOrder()
        {
            return new OrderController();
        }
    }
}
