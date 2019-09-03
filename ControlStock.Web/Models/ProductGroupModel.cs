using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControlStock.Web.Models
{
    public class ProductGroupModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome!")]
        public string Name { get; set; }

        public bool Active { get; set; }

        public static List<ProductGroupModel> RecoverList()
        {
            var ret = new List<ProductGroupModel>();

            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                connection.Open();
                using (var comand = new SqlCommand())
                {
                    comand.Connection = connection;
                    comand.CommandText = "select * from Product_Group order by id";
                    var reader = comand.ExecuteReader();
                    while (reader.Read())
                    {
                        ret.Add(new ProductGroupModel
                        {
                            Id = (int)reader["id"],
                            Name = (string)reader["name"],
                            Active = (bool)reader["active"]
                        });
                    }
                }
            }

            return ret;
        }

        public static ProductGroupModel RecoverById(int id)
        {
            ProductGroupModel ret = null;

            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                connection.Open();
                using (var comand = new SqlCommand())
                {
                    comand.Connection = connection;
                    comand.CommandText = "select * from Product_Group where (id = @id)";
                    comand.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    var reader = comand.ExecuteReader();
                    if (reader.Read())
                    {
                        ret = new ProductGroupModel
                        {
                            Id = (int)reader["id"],
                            Name = (string)reader["name"],
                            Active = (bool)reader["active"]
                        };
                    }
                }
            }

            return ret;
        }

        public static bool RemoveById(int id)
        {
            var ret = false;

            if (RecoverById(id) != null)
            {
                using (var connection = new SqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                    connection.Open();
                    using (var comand = new SqlCommand())
                    {
                        comand.Connection = connection;

                        comand.CommandText = "delete from Product_Group where (id = @id)";
                        comand.Parameters.Add("@id", SqlDbType.Int).Value = id;

                        var reader = (comand.ExecuteNonQuery() > 0);
                    }
                }
            }

            return ret;
        }

        public int Save()
        {
            var ret = 0;

            var model = RecoverById(this.Id);

            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                connection.Open();
                using (var comand = new SqlCommand())
                {
                    comand.Connection = connection;

                    if (model == null)
                    {
                        comand.CommandText = "insert into Product_Group (name, active) values (@name, @active); select convert(int, scope_identity())";
                        comand.Parameters.Add("@name", SqlDbType.VarChar).Value = this.Name;
                        comand.Parameters.Add("@active", SqlDbType.VarChar).Value = (this.Active ? 1 : 0);

                        ret = (int)comand.ExecuteScalar();
                    }
                    else
                    {
                        comand.CommandText = "update Product_Group set name=@name, active=@active where id = @id";

                        comand.Parameters.Add("@name", SqlDbType.VarChar).Value = this.Name;
                        comand.Parameters.Add("@active", SqlDbType.VarChar).Value = (this.Active ? 1 : 0);
                        comand.Parameters.Add("@id", SqlDbType.Int).Value = this.Id;
                        
                        if (comand.ExecuteNonQuery() > 0)
                        {
                            ret = this.Id;
                        }
                    }
                }
            }
            return ret;
        }

    }
}