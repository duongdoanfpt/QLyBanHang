using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBanHang;

namespace DAL_QLBanHang
{
    public class DAL_KhachHang : DBConnect
    {
        // GET Danh Sách KH

        public DataTable getAllKhachHang()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[DanhSachKhach]";
                cmd.Connection = _conn;
                DataTable dtKhach = new DataTable();
                dtKhach.Load(cmd.ExecuteReader());
                return dtKhach;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Insert KhachHang
        public bool InsertKhachHang(DTO_KhachHang kh)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[InsertDataIntoTblKhach]";
                cmd.Parameters.AddWithValue("dienThoai", kh.KH_DienThoai);
                cmd.Parameters.AddWithValue("tenkhach", kh.KH_TenKhach);
                cmd.Parameters.AddWithValue("diaChi", kh.KH_DiaChi);
                cmd.Parameters.AddWithValue("phai", kh.KH_Phai);
                cmd.Parameters.AddWithValue("email", kh.KH_EmailNhanVien);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        //Update KhachHang
        public bool updateKhachHang(DTO_KhachHang kh)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[UpdateDataIntoTblKhach]";
                cmd.Parameters.AddWithValue("dienThoai", kh.KH_DienThoai);
                cmd.Parameters.AddWithValue("tenKhach", kh.KH_TenKhach);
                cmd.Parameters.AddWithValue("diaChi", kh.KH_DiaChi);
                cmd.Parameters.AddWithValue("phai", kh.KH_Phai);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;

        }

        //Delete KhachHang
        public bool deleteKhachHang(string soDT)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[DeleteDataFromtblKhach]";
                cmd.Parameters.AddWithValue("dienthoai", soDT);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        //Search KH
        public DataTable SearchKhachHang(string soDT)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[SearchKhach]";
                cmd.Parameters.AddWithValue("dienthoai", soDT);
                DataTable dtKhach = new DataTable();
                dtKhach.Load(cmd.ExecuteReader());
                return dtKhach;
            }
            finally
            {
                _conn.Close();
            }

        }
    }
}
