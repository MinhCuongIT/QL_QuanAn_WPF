using QL_QuanAn_3Layer_1Tier.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanAn_3Layer_1Tier.DAO
{
    public class QuanAnDAO
    {
        /// <summary>
        /// Chuỗi kết nối tới database
        /// </summary>
        private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=QL_QuanAn;Integrated Security=True";

        /// <summary>
        /// Tải dữ liệu từ DB
        /// </summary>
        /// <returns>Dataset chứa dữ liệu tải được từ DB</returns>
        public DataSet LoadData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string sql = "SELECT * FROM QuanAn";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                connection.Close();

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Thực hiện thêm một quán ăn trong database
        /// </summary>
        /// <param name="quanAn">Quán ăn cần thêm</param>
        /// <returns>true nếu thành công, ngược lại</returns>
        public bool Insert(QuanAn quanAn)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string sql = "INSERT INTO QuanAn(Name, Owner, Address, Phone, IsOpen) VALUES(@name, @owner, @address, @phone, @isOpen)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@name", quanAn.Name);
                command.Parameters.AddWithValue("@owner", quanAn.Owner);
                command.Parameters.AddWithValue("@address", quanAn.Address);
                command.Parameters.AddWithValue("@phone", quanAn.Phone);
                command.Parameters.AddWithValue("@isOpen", quanAn.IsOpen);
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                connection.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// Thực hiện cập nhật một quán ăn trong database
        /// </summary>
        /// <param name="quanAn">Quán ăn cần cập nhật</param>
        /// <returns>true nếu thành công, ngược lại</returns>
        public bool Update(QuanAn quanAn)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string sql = "UPDATE QuanAn SET Name = @name, Owner = @owner, Address = @address, Phone = @phone, IsOpen = @isOpen WHERE Id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@name", quanAn.Name);
                command.Parameters.AddWithValue("@owner", quanAn.Owner);
                command.Parameters.AddWithValue("@address", quanAn.Address);
                command.Parameters.AddWithValue("@phone", quanAn.Phone);
                command.Parameters.AddWithValue("@isOpen", quanAn.IsOpen);
                command.Parameters.AddWithValue("@id", quanAn.Id);
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                connection.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// Thực hiện xóa một quán ăn trong database
        /// </summary>
        /// <param name="quanAn">Quán ăn cần xóa</param>
        /// <returns>true nếu thành công, ngược lại</returns>
        public bool Delete(QuanAn quanAn)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string sql = "DELETE FROM QuanAn  WHERE Id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", quanAn.Id);
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                connection.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra một quán ăn có tồn tại trong hệ thống hay chưa
        /// </summary>
        /// <param name="maQuanAn">Mã Quán Ăn</param>
        /// <returns>true nếu tồn tại, ngược lại</returns>
        public bool IsExisted(int maQuanAn)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string sql = "SELECT * FROM QuanAn WHERE Id = @id";
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@id", maQuanAn);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                connection.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
    }
}
