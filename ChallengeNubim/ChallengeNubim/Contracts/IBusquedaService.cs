using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeNubim.Entities;

namespace ChallengeNubim.Contracts
{
    interface IBusquedaService
    {
        ResultadoBusqueda Get(string producto);

    }
}
