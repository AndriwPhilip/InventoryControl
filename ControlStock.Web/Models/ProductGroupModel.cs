using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
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
                    comand.CommandText = "select * from Product_Group order by name";
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
                    comand.CommandText = string.Format("select * from Product_Group where (id ={0})", id);
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
                        comand.CommandText = string.Format("delete from Product_Group where (id ={0})", id);
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
                        comand.CommandText = string.Format("insert into Product_Group (name, active) values('{0}', {1}); select convert(int, scope_identity())", this.Name, this.Active ? 1 : 0);
                        ret = (int)comand.ExecuteScalar();
                    }
                    else
                    {
                        comand.CommandText = string.Format(
                            "update Product_Group set name='{1}', active={2} where id ={0}",
                            this.Id, this.Name, this.Active ? 1 : 0);
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