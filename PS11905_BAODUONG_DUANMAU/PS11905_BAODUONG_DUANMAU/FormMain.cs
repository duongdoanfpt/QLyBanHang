using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS11905_BAODUONG_DUANMAU
{
    public partial class FormMain : Form
    {
        public FormMain(int CheckDangNhap)
        {
            InitializeComponent();
            if(CheckDangNhap == 1)
            {
                SDangNhap.Enabled = false;
                SDangXuat.Enabled = true;
                DHSNhanVien.Enabled = true;
            }
            else
            {
                SDangXuat.Enabled = false;
                DHSNhanVien.Enabled = false;
                

            }
        }

        private void SDangNhap_Click(object sender, EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
            FormDangNhap frmDangNhapN = new FormDangNhap();
            frmDangNhapN.Activate();
            frmDangNhapN.Show();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       

        
    }
}
