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
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        public string vaitro { set; get; }
        public string matkhau { get; set; }
        public bool IsFirstLogin { get; set; }

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
                FormMain.mail = nv.NV_Email;
                DataTable dt = busNhanVien.VaiTroNhanVien(nv.NV_Email);
                vaitro = dt.Rows[0][0].ToString();
                MessageBox.Show("Đăng nhập thành công");
                FormMain.session = 1;
                FormMain.mail = txtDangNhap.Text;
                if (busnhanvien.Encryption(txtMatKhau.Text).Equals("2331542419640203562132429613354120146463"))
                {
                    IsFirstLogin = true;
                }
                this.Close();
                //CheckDangNhap = 1;
                //Visible = false;
                //ShowInTaskbar = false;
                //FormMain frmMainN = new FormMain(CheckDangNhap);
                //frmMainN.Activate();
                //frmMainN.Show();

            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu sai");
                txtDangNhap.Text = null;
                txtMatKhau.Text = null;
                txtDangNhap.Focus();
            }
        }
        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            FormMain.session = 0;
        }
        void FormDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {


        }

        //public static int CheckDangNhap=0;

        private void lbQuenMK_Click(object sender, EventArgs e)
        {

            if (txtDangNhap.Text != "")
            {
                if (busNhanVien.NhanVienQuenMatKhau(txtDangNhap.Text))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(busNhanVien.RandomString(4, true));
                    builder.Append(busNhanVien.RandomNumber(1000, 9999));
                    builder.Append(busNhanVien.RandomString(2, false));
                    MessageBox.Show(builder.ToString());

                    DTO_NhanVien nv = new DTO_NhanVien();
                    nv.NV_Email = txtDangNhap.Text;
                    nv.NV_MatKhau = busNhanVien.Encryption(builder.ToString());

                    if (busNhanVien.updateMK(nv))
                    {
                        MessageBox.Show("Thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không thành công");
                    }
                    busNhanVien.SendMail(txtDangNhap.Text, builder.ToString());
                    MessageBox.Show("Gửi thành công");
                }

            }
            else
            {
                MessageBox.Show("Email Không tồn tại");
            }
        }


    }
}
