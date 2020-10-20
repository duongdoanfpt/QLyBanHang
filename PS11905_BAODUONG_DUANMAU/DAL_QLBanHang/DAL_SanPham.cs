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
    public class DAL_SanPham : DBConnect
    {
        // Insert SanPham
        public bool InsertHang(DTO_SanPham sp)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[InsertDataIntoTblHang]";
                cmd.Parameters.AddWithValue("tenHang", sp.SP_TenHang);
                cmd.Parameters.AddWithValue("soLuong", sp.SP_SoLuong);
                cmd.Parameters.AddWithValue("donGiaNhap", sp.SP_DonGiaNhap);
                cmd.Parameters.AddWithValue("donGiaBan", sp.SP_DonGiaBan);
                cmd.Parameters.AddWithValue("hinhAnh", sp.SP_HinhAnh);
                cmd.Parameters.AddWithValue("ghiChu", sp.SP_GhiChu);
                cmd.Parameters.AddWithValue("email", sp.SP_EmailNV);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public DataTable GetAllSP()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachHang";
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

        //DAL Update Hang
        public bool updateSanPham(DTO_SanPham hang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[UpdateDataIntoTblHang]";
                cmd.Parameters.AddWithValue("maHang", hang.SP_MaHang);
                cmd.Parameters.AddWithValue("tenHang", hang.SP_TenHang);
                cmd.Parameters.AddWithValue("soLuong", hang.SP_SoLuong);
                cmd.Parameters.AddWithValue("dongiaNhap", hang.SP_DonGiaNhap);
                cmd.Parameters.AddWithValue("dongiaBan", hang.SP_DonGiaBan);
                cmd.Parameters.AddWithValue("hinhAnh", hang.SP_HinhAnh);
                cmd.Parameters.AddWithValue("ghiChu", hang.SP_GhiChu);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        //DAL Delete Hang
        public bool deleteSanPham(int maHang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteDataFromtblHang";
                cmd.Parameters.AddWithValue("maHang", maHang);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public DataTable SearchSanPham(string tenHang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[SearchHang]";
                cmd.Parameters.AddWithValue("tenHang", tenHang);
                DataTable dtSP = new DataTable();
                dtSP.Load(cmd.ExecuteReader());
                return dtSP;
            }
            finally
            {
                _conn.Close();
            }
        }

        public DataTable ThongKeHang()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[ThongKeSP]";
                DataTable dtHang = new DataTable();
                dtHang.Load(cmd.ExecuteReader());
                return dtHang;
            }
            finally
            {
                _conn.Close();
            }
        }

        public DataTable ThongKeTonKho()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[ThongKeTonKho]";
                DataTable dtHang = new DataTable();
                dtHang.Load(cmd.ExecuteReader());
                return dtHang;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
