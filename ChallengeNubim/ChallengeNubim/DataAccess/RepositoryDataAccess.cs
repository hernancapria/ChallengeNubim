using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeNubim.DataAccess
{
    public class RepositoryDataAccess<TEntity> where TEntity : class
    {
        public List<TEntity> GetAll()
        {
            try
            {
                var repo = new Repository<TEntity>();
                List<TEntity> list = repo.GetQuery().ToList();
                return list;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception ex = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                        ex = new InvalidOperationException(message, ex);
                    }
                }
                throw ex;
            }

            
        }


        /// <summary>
        /// Trae un registro de la bbdd por su id
        /// </summary>
        /// <param name="id">int</param>
        public TEntity GetById(int id) 
        {
            var repo = new Repository<TEntity>();
            return repo.GetById(id);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public void Insert(TEntity obj)
        {
            try 
            {
                var repo = new Repository<TEntity>();
                repo.Insert(obj);
                repo.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception ex = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                        ex = new InvalidOperationException(message, ex);
                    }
                }
                throw ex;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public void Update(TEntity obj)
        {
            try
            {
                var repo = new Repository<TEntity>();
                repo.Update<TEntity>(obj);
                repo.SaveChanges();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception ex = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                        ex = new InvalidOperationException(message, ex);
                    }
                }
                throw ex;
            }

        }

        public void Delete1(TEntity obj)
        {
            var repo = new Repository<TEntity>();
            repo.Delete<TEntity>(obj);
            repo.SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                var repo = new Repository<TEntity>();
                TEntity obj = repo.GetById(id);
                repo.Delete(obj);
                repo.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception ex = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                        ex = new InvalidOperationException(message, ex);
                    }
                }
                throw ex;
            }
        }

    }


}