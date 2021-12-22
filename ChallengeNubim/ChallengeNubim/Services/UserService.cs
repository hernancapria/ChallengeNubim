using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChallengeNubim.DataAccess;
using ChallengeNubim.Contracts;

namespace ChallengeNubim.Services
{
    public class UserService : IUserService
    {
        public List<User> GetAll()
        {
            try
            {
                UserDataAccess userDataAccess = new UserDataAccess();
                return userDataAccess.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public User Get(int id)
        {
            try
            {
                UserDataAccess userDataAccess = new UserDataAccess();
                return userDataAccess.Get(id);
            }
                
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(User value)
        {
            try
            {
                UserDataAccess userDataAccess = new UserDataAccess();
                userDataAccess.Insert(value);
            }
            
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(User value)
        {
            try
            {
                UserDataAccess userDataAccess = new UserDataAccess();
                userDataAccess.Update(value);
            }
            
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                UserDataAccess userDataAccess = new UserDataAccess();
                userDataAccess.Delete(id);
            }
            
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}