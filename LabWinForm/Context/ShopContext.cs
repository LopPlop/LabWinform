using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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

        public List<Shop> GetMoreThenAVGShop()
        {
            List<Shop> listAuthor = new List<Shop>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string proc = "[dbo].[GetMoreThenAVGShop]";
                SqlCommand sqlCommand = new SqlCommand(proc, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var shop = new Shop();

                    shop.Id = reader.GetInt32("id");
                    shop.Name = reader.GetString("Name");
                    shop.price = reader.GetDecimal("price");


                    listAuthor.Add(shop);
                }
                reader.Close();
                conn.Close();
            }
            return listAuthor;
        }

        public List<Shop> GetMinShop()
        {
            List<Shop> listAuthor = new List<Shop>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string proc = "[dbo].[GetMinShop]";
                SqlCommand sqlCommand = new SqlCommand(proc, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var shop = new Shop();

                    shop.Id = reader.GetInt32("id");
                    shop.Name = reader.GetString("Name");
                    shop.price = reader.GetDecimal("price");


                    listAuthor.Add(shop);
                }
                reader.Close();
                conn.Close();
            }
            return listAuthor;
        }

        public List<Shop> GetMaxShop()
        {
            List<Shop> listAuthor = new List<Shop>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string proc = "[dbo].[GetMaxShop]";
                SqlCommand sqlCommand = new SqlCommand(proc, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var shop = new Shop();

                    shop.Id = reader.GetInt32("id");
                    shop.Name = reader.GetString("Name");
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

        public void ShopUpdateName(int id, string name)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string proc = "[dbo].[ShopUpdateName]";
                SqlCommand sqlCommand = new SqlCommand(proc, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var par1 = new SqlParameter("@id", id);
                var par2 = new SqlParameter("@name", name);


                conn.Open();
                sqlCommand.Parameters.Add(par1);
                sqlCommand.Parameters.Add(par2);
                sqlCommand.ExecuteReader();
                conn.Close();
            }
        }

        public void ShopUpdatePrice(int id, decimal price)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string proc = "[dbo].[ShopUpdatePrice]";
                SqlCommand sqlCommand = new SqlCommand(proc, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var par1 = new SqlParameter("@id", id);
                var par2 = new SqlParameter("@price", price);


                conn.Open();
                sqlCommand.Parameters.Add(par1);
                sqlCommand.Parameters.Add(par2);
                sqlCommand.ExecuteReader();
                conn.Close();
            }
        }

        public void ShopUpdate(Shop shop)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string proc = "[dbo].[ShopUpdate]";
                SqlCommand sqlCommand = new SqlCommand(proc, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var par1 = new SqlParameter("@id", shop.Id);
                var par2 = new SqlParameter("@price", shop.price);
                var par3 = new SqlParameter("@name", shop.Name);


                conn.Open();
                sqlCommand.Parameters.Add(par1);
                sqlCommand.Parameters.Add(par3);
                sqlCommand.Parameters.Add(par2);
                sqlCommand.ExecuteReader();
                conn.Close();
            }
        }


        public List<string> GetDataBases()
        {
            List<string> listDB = new List<string>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string proc = "[dbo].[GetAllDB]";
                SqlCommand sqlCommand = new SqlCommand(proc, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString("name");
                    listDB.Add(name);
                }
                reader.Close();
                conn.Close();
            }
            return listDB;
        }

        public List<string> GetAllTablesByDB(string dbName)
        {
            List<string> listTables = new List<string>();

            var connect = $@"Server=.\SQLEXPRESS; Database={dbName}; Integrated Security=true; Encrypt=false;";

            using (SqlConnection conn = new SqlConnection(connect))
            {
                string proc = "select TABLE_NAME from information_schema.tables";
                SqlCommand sqlCommand = new SqlCommand(proc, conn);

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString("TABLE_NAME");
                    listTables.Add(name);
                }
                reader.Close();
                conn.Close();
            }
            return listTables;
        }

        public void MakeDBBackup(string backupName)
        {
            var connect = $@"Server=.\SQLEXPRESS; Database=master; Integrated Security=true; Encrypt=false;";
            using (SqlConnection conn = new SqlConnection(connect))
            {
                string proc = $"BACKUP DATABASE LabWinForms TO DISK = '{backupName}'";
                SqlCommand sqlCommand = new SqlCommand(proc, conn);

                conn.Open();
                sqlCommand.ExecuteReader();
                conn.Close();
            }
        }

        public void DropDB(string dbName)
        {
            var connect = $@"Server=.\SQLEXPRESS; Database=master; Integrated Security=true; Encrypt=false;";
            using (SqlConnection conn = new SqlConnection(connect))
            {
                string proc = $"DROP DATABASE {dbName}";
                string proc1 = $"ALTER DATABASE {dbName} SET OFFLINE WITH ROLLBACK IMMEDIATE";

                SqlCommand sqlCommand = new SqlCommand(proc, conn);
                SqlCommand sqlCommand1 = new SqlCommand(proc1, conn);

                conn.Open();
                sqlCommand1.ExecuteNonQuery();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void LoadDBBackup(string backupName)
        {
            var connect = $@"Server=.\SQLEXPRESS; Database=master; Integrated Security=true; Encrypt=false;";
            using (SqlConnection conn = new SqlConnection(connect))
            {
                string proc = @$"RESTORE DATABASE LabWinForms FROM DISK = '{backupName}' WITH REPLACE";

                SqlCommand sqlCommand = new SqlCommand(proc, conn);

                conn.Open();
                sqlCommand.ExecuteReader();
                conn.Close();
            }
        }
    }
}
