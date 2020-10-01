using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionEntities
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
    }

    public interface IItem
    {
        List<ItemDTO> Read(int? id = null);
        bool Create(ItemDTO item);
        bool Update(ItemDTO item);
        bool Delete(ItemDTO item);

    }
}
