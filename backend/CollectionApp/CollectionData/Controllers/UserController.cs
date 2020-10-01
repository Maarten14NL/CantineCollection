using CollectionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionData.Controllers
{
    public class UserController : IUser
    {
        CollectionDatabase db = new CollectionDatabase();

        bool IUser.Create(UserDTO user)
        {
            throw new NotImplementedException();
        }

        bool IUser.Delete(UserDTO user)
        {
            throw new NotImplementedException();
        }

        List<UserDTO> IUser.Read()
        {
            List<UserDTO> users = db.Users.ToList();
            return users;
        }

        UserDTO IUser.ById(int id)
        {
            UserDTO users = db.Users.Find(id);
            return users;
        }

        bool IUser.Update(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
