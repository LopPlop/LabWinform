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
        private static string connection;
        public ShopContext(string connectionStr) {
            connection = connectionStr;
        }

        public List<Shop> GetShop()
        {
            return null;
        }

        public static string GetConnection()
        {
            if (connection != null)
                return connection;
            else
                return "Nothing";
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
        public void ShopInsert(Shop shop)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string proc = "[dbo].[ShopInsert]";
                SqlCommand sqlCommand = new SqlCommand(proc, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var par1 = new SqlParameter("@name", shop.Name);
                var par2 = new SqlParameter("@price", shop.price);
                

                conn.Open();
                sqlCommand.Parameters.Add(par1);
                sqlCommand.Parameters.Add(par2);
                sqlCommand.ExecuteReader();
                conn.Close();
            }
        }
        public void ShopDelete(Shop shop)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string proc = "[dbo].[ShopDelete]";
                SqlCommand sqlCommand = new SqlCommand(proc, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var par1 = new SqlParameter("@name", shop.Name);


                conn.Open();
                sqlCommand.Parameters.Add(par1);
                sqlCommand.ExecuteReader();
                conn.Close();
            }
        }
    }
}
