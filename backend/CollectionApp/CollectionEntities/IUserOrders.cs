using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionEntities
{
    public class OrderListDTO
    {
        public int Id { get; set; }
        public List<OrderDTO> Orders { get; set; }
        public UserDTO User { get; set; }
    }

    public interface IUserOrders
    {
        List<OrderListDTO> ReadAll();
        OrderListDTO ReadOne(int id);
        bool Create(OrderListDTO company);
        bool Update(OrderListDTO company);
        bool Delete(OrderListDTO company);

        List<OrderListDTO> GetByUser(UserDTO user);

    }
}
