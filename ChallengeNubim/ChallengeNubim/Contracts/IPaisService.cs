using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeNubim.Models;

namespace ChallengeNubim.Contracts
{
    interface IPaisService
    {
        List<PaisModel> GetAll();
        PaisModel Get(int id);
        void Insert(PaisModel value);
        void Update(PaisModel value);
        void Delete(int id);
    }
}
