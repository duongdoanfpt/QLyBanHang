using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using DAL_QLBanHang;
using DTO_QLBanHang;

namespace BUS_QLBanHang
{
    public class BUS_KhachHang
    {
        DAL_KhachHang dalKhachHang = new DAL_KhachHang();
        public DataTable GetAllKHang()
        {
            return dalKhachHang.getAllKhachHang();
        }

        public bool insertDataKhachHang(DTO_KhachHang kh)
        {
            return dalKhachHang.InsertKhachHang(kh);
        }

        public bool updateDataKhachHang(DTO_KhachHang kh)
        {
            return dalKhachHang.updateKhachHang(kh);
        }

        public bool deleteDataKhachHang(string sodienthoai)
        {
            return dalKhachHang.deleteKhachHang(sodienthoai);
        }

        public DataTable searchKH(string sodienthoai)
        {
            return dalKhachHang.SearchKhachHang(sodienthoai);
        }
    }
}
