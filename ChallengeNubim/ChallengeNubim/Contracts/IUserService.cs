using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeNubim.Models;

namespace ChallengeNubim.Contracts
{
    interface IUserService
    {
        List<UsuarioModel> GetAll();
        UsuarioModel Get(int id);
        void Insert(UsuarioModel value);
        void Update(UsuarioModel value);
        void Delete(int id);
        User GetByEmail(string email);

    }
}
