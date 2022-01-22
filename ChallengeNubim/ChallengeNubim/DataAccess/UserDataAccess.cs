using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeNubim.DataAccess
{
    public class UserDataAccess<TEntity> : RepositoryDataAccess<User>
    {
        
        public User GetByEmail(string email) {
            var repo = new Repository<User>();
            return repo.Find(p => p.email == email).ToList().FirstOrDefault();
        }



    }
}