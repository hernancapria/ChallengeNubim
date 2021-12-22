using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeNubim.Entities;

namespace ChallengeNubim.Contracts
{
    interface IPaisService
    {
        //Task<Pais> Get(string codigo);

        Pais Get(string codigo);
    }
}
