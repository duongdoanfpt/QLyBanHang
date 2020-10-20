using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS11905_BAODUONG_DUANMAU
{
    public partial class FormMain : Form
    {
        public static int session = 0;
        public static int profile = 0;
        public static string mail;

        FormDangNhap dn;
        public FormMain()
        {
            InitializeComponent();
        }

        private void SDangNhap_Click(object sender, EventArgs e)
        {
            //Visible = false;
            //ShowInTaskbar = false;
            //FormDangNhap frmDangNhapN = new FormDangNhap();
            //frmDangNhapN.Activate();
            //frmDangNhapN.Show();
            dn = new FormDangNhap();
            if (!CheckExitsForm("FormDangNhap"))
            {

                dn.MdiParent = this;
                dn.Show();
                dn.FormClosed += new FormClosedEventHandler(FormDangNhap_FormClosed);
            }
            else
            {
                ActiveChildForm("FormDangNhap");
            }

        }
        // Form Dang Nhap
        void FormDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormMain_Load(sender, e);
        }

        //Form KH
        void FrmKhachHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormMain_Load(sender, e);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Resetvalue();
            if (profile == 1)
            {
                txtRole.Text = null;
                profile = 0;
            }
            this.IsMdiContainer = true;
        }

        //CheckExitsForm
        private bool CheckExitsForm(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }

        //ActiveChildForm
        private void ActiveChildForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }

        //Thiết Lập phân quyền khi Load FormMain
        private void Resetvalue()
        {
            if (session == 1)  // Này là thành công 
            {
                txtRole.Text = "Chào " + FormMain.mail;
                if (string.IsNullOrEmpty(lbVaitro.Text))
                    lbVaitro.Text = dn.vaitro;
                SProfile.Visible = true;
                MSDanhMuc.Visible = true;
                SDangXuat.Enabled = true;
                SDangNhap.Visible = true;
                thốngKêToolStripMenuItem.Visible = true;
                thốngKêSảnPhẩmToolStripMenuItem.Visible = true;
                SDangNhap.Enabled = false;
                if (lbVaitro.Text != null)
                {
                    if (int.Parse(lbVaitro.Text) == 0)
                    {
                        nhânViênToolStripMenuItem.Visible = false;
                        thốngKêToolStripMenuItem.Visible = false;
                    }
                    else if (int.Parse(lbVaitro.Text) == 1)
                    {
                        nhânViênToolStripMenuItem.Visible = true;
                        thốngKêSảnPhẩmToolStripMenuItem.Visible = true;
                    }
                }
                else
                {
                    nhânViênToolStripMenuItem.Visible = false;
                    thốngKêToolStripMenuItem.Visible = false;
                }

                if (dn != null)
                {
                    if (dn.IsFirstLogin)
                    {
                        MessageBox.Show("Bạn cần phải đổi mật khẩu");
                        SProfile.PerformClick();
                    }
                }
            }
            else // Này là ko thành công
            {
                SProfile.Visible = false;
                MSDanhMuc.Visible = false;
                SDangXuat.Enabled = false;
                thốngKêToolStripMenuItem.Visible = false;
                thốngKêSảnPhẩmToolStripMenuItem.Visible = false;
                SDangNhap.Enabled = true;
            }

        }

        private void SProfile_Click(object sender, EventArgs e)
        {
            dn = new FormDangNhap();
            if (!CheckExitsForm("FormQuenMatKhau"))
            {
                FormQuenMatKhau profileNV = new FormQuenMatKhau(FormMain.mail);
                profileNV.MdiParent = this;
                profileNV.FormClosed += new FormClosedEventHandler(FormQuenMatKhau_FormClosed);
                profileNV.Show();
            }
            else
            {
                ActiveChildForm("FormQuenMatKhau");
            }
        }

        //Form DoiMK
        void FormQuenMatKhau_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
            FormMain_Load(sender, e);
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //ShowInTaskbar = false;
            FrmKhachHang frmKH = new FrmKhachHang();
            frmKH.Activate();
            frmKH.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Visible = false;
            //ShowInTaskbar = false;
            FrmNhanVien frmNV = new FrmNhanVien();
            frmNV.Activate();
            frmNV.Show();
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Visible = false;
            //ShowInTaskbar = false;
            FrmSanPham frmSP = new FrmSanPham(Convert.ToInt32(lbVaitro.Text));
            frmSP.Activate();
            frmSP.Show();
        }

        private void thốngKêSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormThongKe frmThongKe = new FormThongKe();
            frmThongKe.Activate();
            frmThongKe.Show();
        }

        private void SDangXuat_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                session = 0;
                Resetvalue();
                lbVaitro.Text = string.Empty;
                txtRole.Text = string.Empty;
                this.Refresh();
            }
        }

        private void DThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
