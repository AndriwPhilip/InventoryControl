using ControlStock.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                connection.Open();
                using(var comand = new SqlCommand())
                {
                   comand.Connection = connection;
                    /* comand.CommandText = string.Format(
                        "select count(*) from Users where login='{0}' and password='{1}'",
                        login, CriptoHelper.HashMD5(password));*/

                    comand.CommandText = "select count(*) from Users where login=@login and password=@password";

                    comand.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                    comand.Parameters.Add("@password", SqlDbType.VarChar).Value = CriptoHelper.HashMD5(password);

                    ret = ((int)comand.ExecuteScalar() > 0);
                }
            }
            return ret;
        }
    }
}