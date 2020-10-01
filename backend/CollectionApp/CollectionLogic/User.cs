using CollectionEntities;
using CollectionFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionLogic
{
    public class User
    {
        private readonly IUser _UserDal = UserFactory.GetUser();

        public List<UserDTO> Read()
        {
            List<UserDTO> userList = _UserDal.Read();
            return userList;
        }

        
    }
}
