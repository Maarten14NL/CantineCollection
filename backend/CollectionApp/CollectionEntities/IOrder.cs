using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionEntities
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }

    public interface IOrder
    {
        List<OrderDTO> ReadAll();
        OrderDTO ReadOne(int id);
        bool Create(OrderDTO order);
        bool Update(OrderDTO order);
        bool Delete(OrderDTO order);

    }
}
