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
using DTO_QLBanHang;
namespace PS11905_BAODUONG_DUANMAU
{
    public partial class FrmKhachHang : Form
    {
        public FrmKhachHang()
        {
            InitializeComponent();
        }
        
        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridView_KH();
        }

        // Hàm của DataGridView
        private void LoadGridView_KH()
        {
            BUS_KhachHang buskhachhang = new BUS_KhachHang();
            dgvKhachHang.DataSource = buskhachhang.GetAllKHang();
            dgvKhachHang.Columns[0].HeaderText = "Số Điện Thoại";
            dgvKhachHang.Columns[1].HeaderText = "Mã Nhân Viên";
            dgvKhachHang.Columns[2].HeaderText = "Tên Khách Hàng";
            dgvKhachHang.Columns[3].HeaderText = "Địa Chỉ";
            dgvKhachHang.Columns[4].HeaderText = "Giới Tính";
        }

        //Hàm Reset
        private void ResetValues()
        {
            txtDienThoai.Enabled = false;
            txtHoTen.Enabled = false;
            txtDiaChi.Enabled = false;
            txtTimKhach.Text = "Nhập số điện thoại khách hàng";
            rbNam.Enabled = false;
            rbNu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtDienThoai.Enabled = true;
            txtHoTen.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDienThoai.Text = null;
            txtHoTen.Text = null;
            txtDiaChi.Text = null;
            rbNam.Enabled = true;
            rbNu.Enabled = true;
            rbNam.Checked = false;
            rbNu.Checked = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string gioitinh = "Nữ";
            if (rbNam.Checked)
            {
                gioitinh = "Nam";
            }

            if(txtDienThoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
                return;
            }
            else if(txtHoTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);               
                return;
            }

            if(txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (rbNam.Checked == false && rbNu.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DTO_KhachHang kh = new DTO_KhachHang(txtDienThoai.Text, txtHoTen.Text, txtDiaChi.Text, gioitinh,FormMain.mail);
            BUS_KhachHang buskhachhang = new BUS_KhachHang();
            if (buskhachhang.insertDataKhachHang(kh))
            {
                MessageBox.Show("Thêm khách hàng thành công");
                ResetValues();
                LoadGridView_KH();

            }
            else
            {
                MessageBox.Show("Thêm khách hàng không thành công");
            }
        }

         void FrmKhachHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.Rows.Count > 1)
            {
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtDiaChi.Enabled = true;
                txtDienThoai.Enabled = true;
                txtHoTen.Enabled = true;
                rbNam.Enabled = true;
                rbNu.Enabled = true;
                // Show data khi chọn cell
                try
                {
                    txtDienThoai.Text = dgvKhachHang.CurrentRow.Cells["dienthoai"].Value.ToString();
                    txtHoTen.Text = dgvKhachHang.CurrentRow.Cells["tenKhach"].Value.ToString();
                    txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells["diaChi"].Value.ToString();
                    if (dgvKhachHang.CurrentRow.Cells["phai"].Value.ToString() == "Nam")
                    {
                        rbNam.Checked = true;
                    }
                    else
                    {
                        rbNu.Checked = true;
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
            string gioitinh = "Nữ";
            if (rbNam.Checked)
            {
                gioitinh = "Nam";
            }

            if (txtDienThoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
                return;
            }
            else if (txtHoTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (rbNam.Checked == false && rbNu.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DTO_KhachHang kh = new DTO_KhachHang(txtDienThoai.Text, txtHoTen.Text, txtDiaChi.Text, gioitinh, FormMain.mail);
            BUS_KhachHang buskhachhang = new BUS_KhachHang();
            if (MessageBox.Show("Bạn có chắc muốn chỉnh sửa", "Corfirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (buskhachhang.updateDataKhachHang(kh))
                {
                    MessageBox.Show("Sửa thành công");
                     ResetValues();
                     LoadGridView_KH();
                }
                else
                {
                    MessageBox.Show("Sửa không thành công");
                }
            }
            else
            {
                ResetValues();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sodienthoai = txtDienThoai.Text;
            if (MessageBox.Show("Bạn có chắc muốn xóa dữ liệu", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BUS_KhachHang buskhachhang = new BUS_KhachHang();
                if (buskhachhang.deleteDataKhachHang(sodienthoai))
                {
                    MessageBox.Show("Xóa dữ liệu thành công");
                    ResetValues();
                    LoadGridView_KH();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
            else
            {
                ResetValues();
            }
        }

        private void btnTimKhach_Click(object sender, EventArgs e)
        {
            BUS_KhachHang buskhachhang = new BUS_KhachHang();
            string sodienthoai = txtTimKhach.Text;
            DataTable ds = buskhachhang.searchKH(sodienthoai);
            if (ds.Rows.Count > 0) //Tim Kiếm True
            {
                dgvKhachHang.DataSource = ds;

            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            txtTimKhach.Text = "Nhập số điện thoại khách hàng";
            txtTimKhach.BackColor = Color.LightGray;
            ResetValues();
        }

        private void txtTimKhach_Click(object sender, EventArgs e)
        {
            txtTimKhach.Text = null;
            txtTimKhach.BackColor = Color.White;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridView_KH();
        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridView_KH();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

        // ---------- //

    }
