using CollectionData.Entities;
using CollectionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionData.Controllers
{
    public class ItemController : IItem
    {
        CollectionDatabase db = new CollectionDatabase();
        public bool Create(ItemDTO company)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ItemDTO company)
        {
            throw new NotImplementedException();
        }

        public List<ItemDTO> Read(int? id = null)
        {
            //throw new NotImplementedException();
            var query = from b in db.Orders
                        orderby b.Name
                        select b;

            List<ItemDTO> items = db.Items.ToList();
            return items;
        }

        public bool Update(ItemDTO company)
        {
            throw new NotImplementedException();
        }
    }
}
