using ChallengeNubim.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ChallengeNubim.DataAccess
{
    public class UserDataAccessOld
    {
        public List<User> GetAll()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ChallengeNubim"].ToString();
            var list = new List<User>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from [User]", conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.id = Convert.ToInt32(reader["id"]);
                        user.apellido = reader["apellido"].ToString();
                        user.nombre = reader["nombre"].ToString();
                        user.email = reader["email"].ToString();
                        user.password = reader["password"].ToString();
                        list.Add(user);
                    }

                    conn.Close();
                }
            }
            return list;

        }

        public User Get(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ChallengeNubim"].ToString();
            User user = new User();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from [User] WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.id = Convert.ToInt32(reader["id"]);
                        user.apellido = reader["apellido"].ToString();
                        user.nombre = reader["nombre"].ToString();
                        user.email = reader["email"].ToString();
                        user.password = reader["password"].ToString();

                    }

                    conn.Close();
                }
            }
            return user;

        }

        public void Insert(User user)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ChallengeNubim"].ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT into [User] (nombre,apellido,email,password) VALUES (@nombre,@apellido,@email,@password)";

                using (SqlCommand comm = new SqlCommand(query))
                {
                    comm.Connection = conn;
                    comm.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 50).Value = user.nombre;
                    comm.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar, 50).Value = user.apellido;
                    comm.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 100).Value = user.email;
                    comm.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 50).Value = user.password;

                    conn.Open();

                    comm.ExecuteNonQuery();
                }
            }
        }

        public void Update(User user)
        {
            using (SqlConnection conn = new SqlConnection("ChallengeNubim"))
            {
                string query = "UPDATE [User] SET nombre=@nombre,apellido=@apellido,email=@email,password=@password WHERE id=@id";

                using (SqlCommand comm = new SqlCommand(query))
                {
                    comm.Connection = conn;
                    comm.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = user.id;
                    comm.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 50).Value = user.nombre;
                    comm.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar, 50).Value = user.apellido;
                    comm.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 100).Value = user.email;
                    comm.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 50).Value = user.password;

                    conn.Open();

                    comm.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {

        }


    }
}