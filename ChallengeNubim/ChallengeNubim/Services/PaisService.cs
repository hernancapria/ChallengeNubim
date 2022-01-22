using ChallengeNubim.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ChallengeNubim.Contracts;
using ChallengeNubim.Models;
using ChallengeNubim.DataAccess;
using ChallengeNubim.Services.Base;

namespace ChallengeNubim.Services
{

    public class PaisService : BaseService<PaisModel, Pais>, IPaisService
    {
        public override Pais MapFromModel(PaisModel model)
        {
            Pais item = new Pais();
            item.id = model.id;
            item.descripcion = model.descripcion;
            return item;
        }

        public override PaisModel MapToModel(Pais item)
        {
            PaisModel model = new PaisModel();
            model.id = item.id;
            model.descripcion = item.descripcion;
            return model;
        }

    }
}