using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControlStock.Web.Models
{
    public class UserModel
    {
        public static bool ValidateUser(string login, string password)
        {
            var ret = false;
            using( var connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=LAPTOP-KG7DS94B\SQLEXPRESS;Initial Catalog=control-stock;User Id=admin;Password=12345";
                connection.Open();
                using(var comand = new SqlCommand())
                {
                    comand.Connection = connection;
                    comand.CommandText = string.Format(
                        "select count(*) from Users where login='{0}' and password='{1}'", login, password);
                   ret= ((int)comand.ExecuteScalar() > 0);
                }
            }
            return ret;
        }
    }
}