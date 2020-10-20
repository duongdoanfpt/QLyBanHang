using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBanHang;
using DAL_QLBanHang;

namespace BUS_QLBanHang
{
    public class BUS_SanPham
    {
        DAL_SanPham dalsanpham = new DAL_SanPham();
        
        //InsertDataSanPham
        public bool InsertDataSanPham(DTO_SanPham sp)
        {
            return dalsanpham.InsertHang(sp);
        }
        // Get all SP
        public DataTable GetAllSP()
        {
            return dalsanpham.GetAllSP();
        }
        //Update Hang
        public bool updateDataSanPham(DTO_SanPham sp)
        {
            return dalsanpham.updateSanPham(sp);
        }
        //Xoa KH
        public bool deleteDataSanPham(int mahang)
        {
            return dalsanpham.deleteSanPham(mahang);
        }

        public DataTable searchDataSanPham(string tenHang)
        {
            return dalsanpham.SearchSanPham(tenHang);
        }

        public DataTable ThongKeDataSP()
        {
            return dalsanpham.ThongKeHang();
        }

        public DataTable ThongKeDataTonKho()
        {
            return dalsanpham.ThongKeTonKho();
        }
    }
}
