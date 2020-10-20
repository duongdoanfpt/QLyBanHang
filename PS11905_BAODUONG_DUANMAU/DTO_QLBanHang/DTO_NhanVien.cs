using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
    public class DTO_NhanVien
    {
        private int _NV_ID;
        private string _NV_MaNV;
        private string _NV_Email;
        private string _NV_TenNV;
        private string _NV_DiaChi;
        private int _NV_VaiTro;
        private int _NV_TinhTrang;
        private string _NV_MatKhau;

        /* ======== GETTER/SETTER ======== */
        public int NV_ID
        {
            get
            {
                return _NV_ID;
            }
            set
            {
                _NV_ID = value;
            }
        }

        public string NV_MaNV
        {
            get
            {
                return _NV_MaNV;
            }
            set
            {
                _NV_MaNV = value;
            }
        }

        public string NV_Email
        {
            get
            {
                return _NV_Email;
            }
            set
            {
                _NV_Email = value;
            }
        }

        public string NV_TenNV
        {
            get
            {
                return _NV_TenNV;
            }
            set
            {
                _NV_TenNV = value;
            }
        }

        public string NV_DiaChi
        {
            get
            {
                return _NV_DiaChi;
            }
            set
            {
                _NV_DiaChi = value;
            }
        }

        public int NV_VaiTro
        {
            get
            {
                return _NV_VaiTro;
            }
            set
            {
                _NV_VaiTro = value;
            }
        }

        public int NV_TinhTrang
        {
            get
            {
                return _NV_TinhTrang;
            }
            set
            {
                _NV_TinhTrang = value;
            }
        }

        public string NV_MatKhau
        {
            get
            {
                return _NV_MatKhau;
            }
            set
            {
                _NV_MatKhau = value;
            }
        }

            /* === Constructor === */

        public DTO_NhanVien()
        {

        }

        public DTO_NhanVien(string emailNV, string tenNV, string dchi, int vaiTro, int tinhTrang, string matKhau)
        {
            
            this.NV_Email = emailNV;
            this.NV_TenNV = tenNV;
            this.NV_DiaChi = dchi;
            this.NV_VaiTro = vaiTro;
            this.NV_TinhTrang = tinhTrang;
            this.NV_MatKhau = matKhau;

        }

        public DTO_NhanVien(string emailNV, string tenNV, string dchi, int vaiTro, int tinhTrang)
        {

            this.NV_Email = emailNV;
            this.NV_TenNV = tenNV;
            this.NV_DiaChi = dchi;
            this.NV_VaiTro = vaiTro;
            this.NV_TinhTrang = tinhTrang;
            

        }


    }
}
