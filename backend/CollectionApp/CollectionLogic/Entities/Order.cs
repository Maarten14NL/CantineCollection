using CollectionEntities;
using CollectionFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionLogic.Entities
{
    public class Order
    {
        private readonly IProduct _ProductDal = ProductFactory.GetAssortiment();

        public int Id { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public Order OrderDTOToOrder(OrderDTO order)
        {
            return new Order()
            {
                Id = order.Id,
                Amount = order.Amount,
                Product = new Product().ProductDTOToProduct(_ProductDal.ReadAsync(1).Result)
            };
        }
        public OrderDTO OrderToOrderDTO(Order order)
        {
            return new OrderDTO()
            {
                Id = order.Id,
                Name = order.Product.Id.ToString(),
                Amount = order.Amount
            };
        }
    }
}
