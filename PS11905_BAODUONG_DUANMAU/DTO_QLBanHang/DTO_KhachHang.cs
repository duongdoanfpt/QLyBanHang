using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
    public class DTO_KhachHang
    {
        private string _KH_DienThoai;
        private string _KH_MaNV;
        private string _KH_TenKhach;
        private string _KH_DiaChi;
        private string _KH_Phai;
        private string _KH_EmailNhanVien;

        /* ======== GETTER/SETTER ======== */
        public string KH_DienThoai
        {
            get
            {
                return _KH_DienThoai;
            }
            set
            {
                _KH_DienThoai = value;
            }
        }

        public string KH_MaNV
        {
            get
            {
                return _KH_MaNV;
            }
            set
            {
                _KH_MaNV = value;
            }
        }

        public string KH_TenKhach
        {
            get
            {
                return _KH_TenKhach;
            }
            set
            {
                _KH_TenKhach = value;
            }
        }

        public string KH_DiaChi
        {
            get
            {
                return _KH_DiaChi;
            }
            set
            {
                _KH_DiaChi = value;
            }
        }

        public string KH_Phai
        {
            get
            {
                return _KH_Phai;
            }
            set
            {
                _KH_Phai = value;
            }
        }

        public string KH_EmailNhanVien
        {
            get
            {
                return _KH_EmailNhanVien;
            }
            set
            {
                _KH_EmailNhanVien = value;
            }
        }

        /* === Constructor === */

        public DTO_KhachHang(string dienThoai, string tenKH, string diaChi, string gioiTinh, string email = null)
        {
            this.KH_DienThoai = dienThoai;
            this.KH_TenKhach = tenKH;
            this.KH_DiaChi = diaChi;
            this.KH_Phai = gioiTinh;
            this.KH_EmailNhanVien = email;
        }

        public DTO_KhachHang()
        {

        }
    }
}
