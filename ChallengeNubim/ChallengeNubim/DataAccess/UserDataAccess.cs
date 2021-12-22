using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeNubim.DataAccess
{
    public class UserDataAccess
    {

        /// <summary>
        /// Devuelve todos los resultados
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll()
        {
            try
            {
                using (var db = new ChallengeNubimEntities())
                {
                    var result = db.User.ToList();
                    return result;
                }

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
        /// Devuelve un resultado en base a su id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        public User Get(int id)
        {
            try
            {
                using (var db = new ChallengeNubimEntities())
                {
                    var result = db.User.SingleOrDefault(x => x.id == id);
                    return result;
                }

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
        /// Inserta un registro en la bbdd
        /// </summary>
        /// <param name="user">User</param>
        public void Insert(User user)
        {
            try
            {
                using (var db = new ChallengeNubimEntities())
                {
                    db.User.Add(user);
                    db.SaveChanges();

                }
                
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                // recorrer todas las excepciones q se puedan producir para mostrarlas en el
                // mensaje de error del response (por ejemplo, maxima cantidad de caracteres excedida)
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
        /// Actualiza un registro de la bbdd
        /// </summary>
        /// <param name="user">User</param>
        public void Update(User user)
        {
            try
            {
                using (var db = new ChallengeNubimEntities())
                {
                    var result = db.User.SingleOrDefault(x => x.id == user.id);
                    if (result != null)
                    {
                        result.nombre = user.nombre;
                        result.apellido = user.apellido;
                        result.email = user.email;
                        result.password = user.password;
                        db.SaveChanges();
                    }
                }

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
        /// Elimina un registro de la bbdd
        /// </summary>
        /// <param name="id">int</param>
        public void Delete(int id)
        {
            try 
            {
                using (var db = new ChallengeNubimEntities())
                {
                    var user = new User() { id = id };
                    db.User.Attach(user);
                    db.User.Remove(user);
                    db.SaveChanges();
                }

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