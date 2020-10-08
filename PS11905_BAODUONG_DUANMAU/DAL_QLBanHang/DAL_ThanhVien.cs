using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBanHang;



namespace DAL_QLBanHang
{
     public class DAL_ThanhVien : DBConnect
    {
        // Phan DangNhap
        public bool NhanVienDangNhap(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DangNhap";
                cmd.Parameters.AddWithValue("email", nv.NV_Email);
                cmd.Parameters.AddWithValue("matKhau", nv.NV_MatKhau);

                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                return true;
            }
            catch (Exception)
            {

               
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        //Phan Quen Mat Khau
        public bool NhanVienQuenMatKhau(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "QuenMatKhau";
                cmd.Parameters.AddWithValue("email", email);

                if (Convert.ToInt16(cmd.ExecuteScalar())>0)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        

        

    }
}

