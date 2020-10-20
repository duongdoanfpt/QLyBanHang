using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using BUS_QLBanHang;
using DTO_QLBanHang;


namespace PS11905_BAODUONG_DUANMAU
{
    public partial class FrmNhanVien : Form
    {
        public FrmNhanVien()
        {
            InitializeComponent();
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            BUS_NhanVien busnhanvien = new BUS_NhanVien();
            resetValues();
            dataGridView_NhanVien.DataSource = busnhanvien.getAllNhanVien();
            
        }

        //Hàm Reset 

        private void resetValues()
        {
            txtTimKiem.Text = "Nhập tên nhân viên";
            txtEmail.Text = null;
            txtTenNV.Text = null;
            txtDiaChi.Text = null;
            txtEmail.Enabled = false;
            txtTenNV.Enabled = false;
            txtDiaChi.Enabled = false;
            rbNhanVien.Enabled = false;
            rbQuanTri.Enabled = false;
            rbHoatDong.Enabled = false;
            rbNgungHD.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;

        }

        //Check Rule Email
        public bool Isvaild(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;

            }
            catch (FormatException)
            {

                return false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtEmail.Text = null;
            txtTenNV.Text = null;
            txtDiaChi.Text = null;
            txtEmail.Enabled = true;
            txtTenNV.Enabled = true;
            txtDiaChi.Enabled = true;
            rbNhanVien.Enabled = true;
            rbQuanTri.Enabled = true;
            rbHoatDong.Enabled = true;
            rbNgungHD.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            rbNhanVien.Checked = false;
            rbNgungHD.Checked = false;
            rbQuanTri.Checked = false;
            rbHoatDong.Checked = false;
            txtEmail.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int role = 0; //Vai trò của nhân viên
            if (rbQuanTri.Checked)
                role = 1; // Quản trị
            int tinhtrang = 0; //Trạng thái nhưng HĐ
            if (rbHoatDong.Checked)
                tinhtrang = 1; // Hoạt động

            if (txtEmail.Text.Trim().Length == 0) //Check Email Null
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }
            else if (!Isvaild(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Email bạn nhập sai, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }

            if(txtTenNV.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if(txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(rbQuanTri.Checked == false && rbNhanVien.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn quyền của nhân viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(rbHoatDong.Checked == false && rbNgungHD.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn trạng thái của nhân viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                BUS_NhanVien busnhanvien = new BUS_NhanVien();
                DTO_NhanVien nv = new DTO_NhanVien(txtEmail.Text, txtTenNV.Text, txtDiaChi.Text, role, tinhtrang);
                if (busnhanvien.inserNhanVien(nv))
                {
                    MessageBox.Show("Thêm nhân viên thành công");
                    resetValues();
                    dataGridView_NhanVien.DataSource = busnhanvien.getAllNhanVien();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên không thành công");
                }
            }
        }

        private void dataGridView_NhanVien_Click(object sender, EventArgs e)
        {
            if (dataGridView_NhanVien.Rows.Count > 1)
            {
                btnLuu.Enabled = false;
                txtTenNV.Enabled = true;
                txtDiaChi.Enabled = true;
                rbQuanTri.Enabled = true;
                rbNhanVien.Enabled = true;
                rbHoatDong.Enabled = true;
                rbNgungHD.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                // Show data khi chọn cell
                try
                {
                    txtEmail.Text = dataGridView_NhanVien.CurrentRow.Cells["email"].Value.ToString();
                    txtTenNV.Text = dataGridView_NhanVien.CurrentRow.Cells["tenNv"].Value.ToString();
                    txtDiaChi.Text = dataGridView_NhanVien.CurrentRow.Cells["diachi"].Value.ToString();
                    if (int.Parse(dataGridView_NhanVien.CurrentRow.Cells["vaitro"].Value.ToString()) == 1)
                    {
                        rbQuanTri.Checked = true;
                    }
                    else
                    {
                        rbNhanVien.Checked = true;
                    }

                    if (int.Parse(dataGridView_NhanVien.CurrentRow.Cells["tinhtrang"].Value.ToString()) == 1)
                    {
                        rbHoatDong.Checked = true;
                    }
                    else
                    {
                        rbNgungHD.Checked = true;
                    }
                }
                catch (Exception)
                {

                    
                }
                

            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                int role = 0; //Vaitro nhanvien
                if (rbQuanTri.Checked)
                {
                    role = 1;
                }
                int tinhtrang = 0;
                if (rbHoatDong.Checked)
                {
                    tinhtrang = 1;
                }
                DTO_NhanVien nv = new DTO_NhanVien(txtEmail.Text, txtTenNV.Text, txtDiaChi.Text, role, tinhtrang);
                BUS_NhanVien busnhanvien = new BUS_NhanVien();
                if (MessageBox.Show("Bạn có chắc muốn chỉnh sửa","Corfirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busnhanvien.updateNhanVien(nv))
                    {
                        MessageBox.Show("Sửa thành công");
                        resetValues();
                        dataGridView_NhanVien.DataSource = busnhanvien.getAllNhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công");
                    }
                }
                else
                {
                    resetValues();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            if(MessageBox.Show("Bạn có chắc muốn xóa dữ liệu","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
                BUS_NhanVien busnhanvien = new BUS_NhanVien();
                if (busnhanvien.deleteNhanVien(email))
                {
                    MessageBox.Show("Xóa dữ liệu thành công");
                    resetValues();
                    dataGridView_NhanVien.DataSource = busnhanvien.getAllNhanVien();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
            else
            {
                resetValues();
            }
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = null;
            txtTimKiem.BackColor = Color.White;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            BUS_NhanVien busnhanvien = new BUS_NhanVien();
            string tenNhanVien = txtTimKiem.Text;
            DataTable ds = busnhanvien.searchNhanVien(tenNhanVien);
            if(ds.Rows.Count>0) //Tim Kiếm True
            {
                dataGridView_NhanVien.DataSource = ds;

            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            txtTimKiem.Text = "Nhập tên nhân viên";
            txtTimKiem.BackColor = Color.LightGray;
            resetValues();
        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            BUS_NhanVien busnhanvien = new BUS_NhanVien();
            resetValues();
            dataGridView_NhanVien.DataSource = busnhanvien.getAllNhanVien();

        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            BUS_NhanVien busnhanvien = new BUS_NhanVien();
            resetValues();
            dataGridView_NhanVien.DataSource = busnhanvien.getAllNhanVien();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        // ------------- //
    }
}
