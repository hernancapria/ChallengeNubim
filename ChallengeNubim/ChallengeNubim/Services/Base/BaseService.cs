using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChallengeNubim.DataAccess;

namespace ChallengeNubim.Services.Base
{
    public class BaseService<TModel, T> where T : class
    {
        public List<TModel> GetAll()
        {
            try
            {
                RepositoryDataAccess<T> repositoryDataAccess = new RepositoryDataAccess<T>();
                var modelList = MapToModelList(repositoryDataAccess.GetAll());
                return modelList;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public TModel Get(int id)
        {
            try
            {
                RepositoryDataAccess<T> repositoryDataAccess = new RepositoryDataAccess<T>();
                var item = repositoryDataAccess.GetById(id);
                var model = MapToModel(item);
                return model;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(TModel value)
        {
            try
            {
                RepositoryDataAccess<T> repositoryDataAccess = new RepositoryDataAccess<T>();
                var item = MapFromModel(value);
                repositoryDataAccess.Insert(item);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TModel value)
        {
            try
            {
                RepositoryDataAccess<T> repositoryDataAccess = new RepositoryDataAccess<T>();
                var item = MapFromModel(value);
                repositoryDataAccess.Update(item);
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
                RepositoryDataAccess<T> repositoryDataAccess = new RepositoryDataAccess<T>();
                repositoryDataAccess.Delete(id);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual List<TModel> MapToModelList(List<T> list)
        {
            List<TModel> lista = new List<TModel>();
            foreach (var item in list)
            {
                TModel model = MapToModel(item);
                lista.Add(model);
            }
            return lista;
        }

        public virtual TModel MapToModel(T item)
        {
            throw new NotImplementedException();
        }

        public virtual T MapFromModel(TModel value)
        {
            throw new NotImplementedException();
        }


    }
}