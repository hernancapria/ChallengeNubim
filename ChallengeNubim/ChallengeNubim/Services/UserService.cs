using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChallengeNubim.DataAccess;
using ChallengeNubim.Contracts;
using ChallengeNubim.Models;
using ChallengeNubim.Services.Base;

namespace ChallengeNubim.Services
{
    public class UserService : BaseService<UsuarioModel, User>, IUserService
    {

        public User GetByEmail(string email)
        {
            UserDataAccess<User> userDataAccess = new UserDataAccess<User>();
            return userDataAccess.GetByEmail(email);

        }


        //public override List<UsuarioModel> MapToModelList(List<User> list)
        //{
        //    List<UsuarioModel> lista = new List<UsuarioModel>();
        //    foreach (var item in list)
        //    {
        //        UsuarioModel model = MapToModel(item);
        //        lista.Add(model);
        //    }
        //    return lista;
        //}

        public override UsuarioModel MapToModel(User item)
        {
            UsuarioModel model = new UsuarioModel();
            model.id = item.id;
            model.nombre = item.nombre;
            model.apellido = item.apellido;
            model.email = item.email;
            model.password = item.password;
            model.id_pais = item.id_pais;
            model.descripcionPais = item.Pais == null ? string.Empty : item.Pais.descripcion;
            model.fecha_ingreso = item.fecha_ingreso;
            return model;
        }

        public override User MapFromModel(UsuarioModel model)
        {
            User item = new User();
            item.id = model.id;
            item.nombre = model.nombre;
            item.apellido = model.apellido;
            item.email = model.email;
            item.password = model.password;
            item.id_pais = model.id_pais;
            item.fecha_ingreso = model.fecha_ingreso;
            return item;
        }

    }

}