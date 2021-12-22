using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeNubim.Contracts
{
    interface IUserService
    {
        List<User> GetAll();
        User Get(int id);
        void Insert(User value);
        void Update(User value);
        void Delete(int id);

    }
}
