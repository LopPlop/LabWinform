using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabWinForm.Model;
using Microsoft.Data.SqlClient;

namespace LabWinForm.Context
{
    class ShopContext
    {
        private string connection;
        public ShopContext(string connectionStr) {
            connection = connectionStr;
            
        }

        public List<Shop> GetShop()
        {
            return null;
        }

        public List<Shop> GetAllShop()
        {
            List<Shop> listAuthor = new List<Shop>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string proc = "[dbo].[GetAllShop]";
                SqlCommand sqlCommand = new SqlCommand(proc, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var shop = new Shop();

                    shop.Id = reader.GetInt32("id");
                    shop.Name = reader.GetString("ProductName");
                    shop.price = reader.GetDecimal("price");
                   

                    listAuthor.Add(shop);
                }
                reader.Close();
                conn.Close();
            }
            return listAuthor;
        }
    }
}
