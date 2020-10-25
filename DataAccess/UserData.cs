using BusinessEntity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class UserData
    {
        private DbConnect db = new DbConnect();

        public User Get(int id)
        {
            User objUser = new User();
            string querySP = "GetUser";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(db.connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(querySP, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@_id", id);
                        cmd.Connection.Open();
                        using (MySqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                objUser = new User();
                                objUser.id = Convert.ToInt32(rd["id"]);
                                objUser.username = rd["username"].ToString();
                                objUser.password = rd["password"].ToString();
                                objUser.firstname = rd["firstname"].ToString();
                                objUser.lastname = rd["lastname"].ToString();
                                objUser.email = rd["email"].ToString();
                                objUser.active = Convert.ToBoolean(rd["active"]);
                                objUser.created = Convert.ToDateTime(rd["created"]);
  
                            }
                        }
                        cmd.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objUser;
        }
        public List<User> GetAll()
        {
            List<User> result = new List<User>();
            User objUser = new User();
            string querySP = "GetAllUser";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(db.connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(querySP, conn))
                    {
                        cmd.Connection.Open();
                        using (MySqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                objUser = new User();
                                objUser.id = Convert.ToInt32(rd["id"]);
                                objUser.username = rd["username"].ToString();
                                objUser.password = rd["password"].ToString();
                                objUser.firstname = rd["firstname"].ToString();
                                objUser.lastname = rd["lastname"].ToString();
                                objUser.email = rd["email"].ToString();
                                objUser.active = Convert.ToBoolean(rd["active"]);
                                objUser.created = Convert.ToDateTime(rd["created"]);
                                result.Add(objUser);

                            }
                        }
                        cmd.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return result;
        }

        public bool Insert(User objUser)
        {
            bool result = false;
            string querySP = "InsertUser";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(db.connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(querySP, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@_username", objUser.username);
                        cmd.Parameters.AddWithValue("@_password", objUser.username);
                        cmd.Parameters.AddWithValue("@_firstname", objUser.username);
                        cmd.Parameters.AddWithValue("@_lastname", objUser.username);
                        cmd.Parameters.AddWithValue("@_email", objUser.username);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
                result = true;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool Update(User objUser)
        {
            bool result = false;
            string querySP = "UpdateUser";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(db.connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(querySP, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@_id", objUser.id);
                        cmd.Parameters.AddWithValue("@_firstname", objUser.username);
                        cmd.Parameters.AddWithValue("@_lastname", objUser.username);
                        cmd.Parameters.AddWithValue("@_email", objUser.username);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
                result = true;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool ChangePassword(string username, string  password, string newpassword)
        {
            bool result = false;
            string querySP = "ChangePasswordUser";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(db.connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(querySP, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;                        
                        cmd.Parameters.AddWithValue("@_username", username);
                        cmd.Parameters.AddWithValue("@_password", password);
                        cmd.Parameters.AddWithValue("@_newpassword", newpassword);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
                result = true;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
