using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QLBanHang;
using BUS_QLBanHang;

namespace PS11905_BAODUONG_DUANMAU
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }
        BUS_NhanVien busnhanvien = new BUS_NhanVien();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            DTO_NhanVien nv = new DTO_NhanVien();
            nv.NV_Email = txtDangNhap.Text;
            nv.NV_MatKhau = busnhanvien.Encryption(txtMatKhau.Text);
            if (busnhanvien.NhanVienDangNhap(nv))
            {
                MessageBox.Show("Đăng nhập thành công");
                CheckDangNhap = 1;
                Visible = false;
                ShowInTaskbar = false;
                FormMain frmMainN = new FormMain(CheckDangNhap);
                frmMainN.Activate();
                frmMainN.Show();
                
               
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu sai");
                txtDangNhap.Text = null;
                txtMatKhau.Text = null;
                txtDangNhap.Focus();
            }
        }

        private void FormDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        public static int CheckDangNhap=0;

        private void lbQuenMK_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    busnhanvien.SendMail(txtDangNhap.Text, (busnhanvien.RandomString(5, false) + busnhanvien.RandomNumber(0, 9)));
            //    MessageBox.Show("Gui thanh cong");
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Gui khong thanh cong");
            //}

            if (txtDangNhap.Text !="")
            {
                if (busnhanvien.NhanVienQuenMatKhau(txtDangNhap.Text))
                {
                    //StringBuilder builder = new StringBuilder();
                    //builder.Append(busnhanvien.RandomString(4, true));
                    //builder.Append(busnhanvien.RandomNumber(1000, 9999));
                    //builder.Append(busnhanvien.RandomString(2, false));
                    //string matkhaumoi = busnhanvien.Encryption(builder.ToString());
                    //busnhanvien.TaoMatKhau(txtDangNhap.Text, matkhaumoi);
                    //busnhanvien.SendMail(txtDangNhap.Text, builder.ToString());
                    busnhanvien.SendMail(txtDangNhap.Text, (busnhanvien.RandomString(5, false) + busnhanvien.RandomNumber(0, 9)));
                     MessageBox.Show("Gui thanh cong");
                }
                else
                {
                    MessageBox.Show("Email không tồn tại, vui lòng nhập lại email");
                }
            }
            else
            {
                MessageBox.Show("Bạn cần nhập email để phục hồi mật khẩu");
                txtDangNhap.Focus();
            }
        }
    }
}
