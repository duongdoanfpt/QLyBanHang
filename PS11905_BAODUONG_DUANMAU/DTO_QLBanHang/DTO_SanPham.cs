using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
    public class DTO_SanPham
    {
        private int _SP_MaHang;
        private string _SP_MaNV;
        private string _SP_TenHang;
        private string _SP_HinhAnh;
        private string _SP_GhiChu;
        private float _SP_donGiaNhap;
        private float _SP_donGiaBan;
        private int _SP_soLuong;
        private string _SP_EmailNV;

        /* ======== GETTER/SETTER ======== */

        public int SP_MaHang
        {
            get
            {
                return _SP_MaHang;
            }
            set
            {
                _SP_MaHang = value;
            }
        }

        public string SP_MaNV
        {
            get
            {
                return _SP_MaNV;
            }
            set
            {
                _SP_MaNV = value;
            }
        }

        public string SP_TenHang
        {
            get
            {
                return _SP_TenHang;
            }
            set
            {
                _SP_TenHang = value;
            }
        }

        public string SP_HinhAnh
        {
            get
            {
                return _SP_HinhAnh;
            }
            set
            {
                _SP_HinhAnh = value;
            }
        }

        public string SP_GhiChu
        {
            get
            {
                return _SP_GhiChu;
            }
            set
            {
                _SP_GhiChu = value;
            }
        }

        public float SP_DonGiaNhap
        {
            get
            {
                return _SP_donGiaNhap;
            }
            set
            {
                _SP_donGiaNhap = value;
            }
        }

        public float SP_DonGiaBan
        {
            get
            {
                return _SP_donGiaBan;
            }
            set
            {
                _SP_donGiaBan = value;
            }
        }

        public int SP_SoLuong
        {
            get
            {
                return _SP_soLuong;
            }
            set
            {
                _SP_soLuong = value;
            }
        }

        public string SP_EmailNV
        {
            get
            {
                return _SP_EmailNV;
            }
            set
            {
                _SP_EmailNV = value;
            }
        }

        /* === Constructor === */
        public DTO_SanPham(int maHang, string tenHang, int soLuong, float donGiaNhap, float donGiaBan,string hinhAnh, string ghiChu)
        {
            this.SP_MaHang = maHang;
            this.SP_TenHang = tenHang;
            this.SP_SoLuong = soLuong;
            this.SP_DonGiaNhap = donGiaNhap;
            this.SP_DonGiaBan = donGiaBan;
            this.SP_HinhAnh = hinhAnh;
            this.SP_GhiChu = ghiChu;
        }

        public DTO_SanPham(string tenHang, int soLuong, float donGiaNhap, float donGiaBan, string hinhAnh, string ghiChu, string emailNv)
        {
            this.SP_TenHang = tenHang;
            this.SP_SoLuong = soLuong;
            this.SP_DonGiaNhap = donGiaNhap;
            this.SP_DonGiaBan = donGiaBan;
            this.SP_HinhAnh = hinhAnh;
            this.SP_GhiChu = ghiChu;
            this.SP_EmailNV = emailNv;
        }

    }
}
