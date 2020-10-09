using CollectionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionData.Entities
{
    public class OrderList
    {
        public int Id { get; set; }
        public virtual ICollection<IOrder> Orders { get; set; }
        public virtual User User { get; set; }

    }
}
