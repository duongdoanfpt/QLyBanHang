using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
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
        // DoiMK tu mail
        public bool TaoMatKhauMoi(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TaoMatKhauMoi";
                cmd.Parameters.AddWithValue("email", nv.NV_Email);
                cmd.Parameters.AddWithValue("matkhau", nv.NV_MatKhau);

                if (cmd.ExecuteNonQuery() > 0)
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

        public DataTable VaiTroNhanVien(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LayVaiTroNV";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Connection = _conn;
                DataTable dtNhanVien = new DataTable();
                dtNhanVien.Load(cmd.ExecuteReader());
                return dtNhanVien;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Đổi MK
        public bool UpdateMatKhau(string email, string matKhauCu, string matKhauMoi)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "chgpwd";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("@opwd", matKhauCu);
                cmd.Parameters.AddWithValue("@npwd", matKhauMoi);

                if (cmd.ExecuteNonQuery() >0) 
                    return true;               
            }
            
            finally
            {
                _conn.Close();
            }
            return false;
        }

        // GET ALL DANH SÁCH NHÂN VIÊN
        public DataTable getAllNhanVien()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[DanhSachNV]";
                cmd.Connection = _conn;
                DataTable dtHang = new DataTable();
                dtHang.Load(cmd.ExecuteReader());
                return dtHang;
            }
            finally
            {
                _conn.Close();
            }
            
        }

        //Insert NhanVien
        public bool insertNhanVien(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[InsertDataIntoTblNhanVien]";
                cmd.Parameters.AddWithValue("email", nv.NV_Email);
                cmd.Parameters.AddWithValue("tennv", nv.NV_TenNV);
                cmd.Parameters.AddWithValue("diachi", nv.NV_DiaChi);
                cmd.Parameters.AddWithValue("vaitro", nv.NV_VaiTro);
                cmd.Parameters.AddWithValue("tinhtrang", nv.NV_TinhTrang);

                if(cmd.ExecuteNonQuery()>0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;          
        }

        //Update Nhân Viên
        public bool updateNhanVien(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[UpdateDataIntoTblNhanVien]";
                cmd.Parameters.AddWithValue("email", nv.NV_Email);
                cmd.Parameters.AddWithValue("tennv", nv.NV_TenNV);
                cmd.Parameters.AddWithValue("diachi", nv.NV_DiaChi);
                cmd.Parameters.AddWithValue("vaitro", nv.NV_VaiTro);
                cmd.Parameters.AddWithValue("tinhtrang", nv.NV_TinhTrang);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;

        }

        // Xóa Nhân Viên
        public bool DeleteNhanVien(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[DeleteDataFromtblNhanVien]";
                cmd.Parameters.AddWithValue("email", email);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
            
        }

        //Tìm Nhân Viên
        public DataTable SearchNhanVien(string tenNhanVien)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[SearchNhanVien]";
                cmd.Parameters.AddWithValue("tennv", tenNhanVien);
                DataTable dtNhanVien = new DataTable();
                dtNhanVien.Load(cmd.ExecuteReader());
                return dtNhanVien;
            }
            finally
            {
                _conn.Close();
            }
            
        }
           



    }
}

