using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBanHang;

namespace PS11905_BAODUONG_DUANMAU
{
    public partial class FormQuenMatKhau : Form
    {
        public FormQuenMatKhau(string email)
        {
            InitializeComponent();
            txtEmail.Text = email;
        }
        
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            
            if (txtMatKhauCu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauCu.Focus();
                return;
            }
            BUS_NhanVien busNhanVien = new BUS_NhanVien();
            string matkhaumoi = busNhanVien.Encryption(txtMatKhauMoi.Text);
            string matkhaucu = busNhanVien.Encryption(txtMatKhauCu.Text);
            if (busNhanVien.UpdateMatKhau(txtEmail.Text, matkhaucu, matkhaumoi))
            {
                FormMain.profile = 1; //Cập nhật pass thành công
                FormMain.session = 0; //Đưa về tình trạng chưa đăng nhập
                MessageBox.Show("Cập nhật mật khẩu thành công, bạn cần phải đăng nhập lại");
                this.Close();
            }
        }

         void FormQuenMatKhau_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
