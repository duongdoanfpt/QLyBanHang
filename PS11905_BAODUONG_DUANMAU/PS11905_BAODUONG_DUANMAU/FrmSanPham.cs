using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBanHang;
using DTO_QLBanHang;


namespace PS11905_BAODUONG_DUANMAU
{
    public partial class FrmSanPham : Form
    {
        private int _vaitro;
        private string PathImage = string.Empty;
        private string LastImage = string.Empty;

        public FrmSanPham()
        {
            InitializeComponent();
        }

        public FrmSanPham(int vaitro)
        {
            InitializeComponent();
            _vaitro = vaitro;
        }

        BUS_SanPham busHang = new BUS_SanPham();
        string stremail = FormMain.mail;

        //Btn Mo Hinh Anh
        private void btnMo_Click(object sender, EventArgs e)
        {
            //Check folder ton tai
            string PathImages = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            if (!File.Exists(PathImages)) //Neu ton tai
            {
                //Tao folder Images
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Images");
                Directory.CreateDirectory(path);
            }
            LastImage = txtHinh.Text;
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn hình ảnh minh họa cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pbHinh.Image = Image.FromFile(dlgOpen.FileName);
                    txtHinh.Text = dlgOpen.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            pbHinh.SizeMode = PictureBoxSizeMode.StretchImage;
            dlgOpen.Dispose();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            #region Validation data
            int intSoLuong;
            bool isInt = int.TryParse(txtSoLuong.Text.Trim().ToString(), out intSoLuong);
            float floatDonGiaNhap;
            bool isFloatNhap = float.TryParse(txtDonGiaNhap.Text.Trim().ToString(), out floatDonGiaNhap);
            float floatDonGiaBan;
            bool isFloatBan = float.TryParse(txtDonGiaBan.Text.Trim().ToString(), out floatDonGiaBan);
            if (txtTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!isInt || int.Parse(txtSoLuong.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!isFloatNhap || float.Parse(txtDonGiaNhap.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!isFloatBan || float.Parse(txtDonGiaBan.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (pbHinh.Image == null) // Kiểm tra phải nhập hình
            {
                MessageBox.Show("Bạn phải upload hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #endregion
            else
            {
                string nameImage = string.Empty;
                try
                {
                    //Get name image
                    nameImage = txtHinh.Text.Substring(txtHinh.Text.LastIndexOf('\\') + 2);
                    pbHinh.Image.Save(Path.Combine(Directory.GetCurrentDirectory(), "Images", nameImage));
                    DTO_SanPham h = new DTO_SanPham(
                        txtTenHang.Text,
                        int.Parse(txtSoLuong.Text),
                        float.Parse(txtDonGiaNhap.Text),
                        float.Parse(txtDonGiaBan.Text),
                        Path.Combine("Images", nameImage),
                        txtGhiChu.Text, stremail);
                    if (busHang.InsertDataSanPham(h))
                    {
                        MessageBox.Show("Thêm sản phẩm thành công");
                        //File.Copy(fileAddress, fileSavePath, true);
                        ResetValues();
                        LoadGridView_Hang();
                    }
                    else
                    {
                        MessageBox.Show("Thêm sản phẩm không thành công");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Hàm Load Grid View
        private void LoadGridView_Hang()
        {
            BUS_SanPham busHang = new BUS_SanPham();
            dgvSanPham.DataSource = busHang.GetAllSP();
            dgvSanPham.Columns[0].HeaderText = "Mã Hàng";
            dgvSanPham.Columns[1].HeaderText = "Mã Nhân Viên";
            dgvSanPham.Columns[2].HeaderText = "Tên Hàng";
            dgvSanPham.Columns[3].HeaderText = "Hình Ảnh";
            dgvSanPham.Columns[4].HeaderText = "Ghi Chú";
            dgvSanPham.Columns[5].HeaderText = "Giá Nhập";
            dgvSanPham.Columns[6].HeaderText = "Giá Bán";
            dgvSanPham.Columns[7].HeaderText = "Số Lượng";

        }
        // Hàm Reset
        private void ResetValues()
        {
            txtTenHang.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtDonGiaNhap.Enabled = false;
            txtGhiChu.Enabled = false;
            txtHinh.Enabled = false;
            txtSoLuong.Enabled = false;
            txtMaHang.Text = null;
            txtTenHang.Text = null;
            txtDonGiaBan.Text = null;
            txtDonGiaNhap.Text = null;
            txtGhiChu.Text = null;
            txtHinh.Text = null;
            txtSoLuong.Text = null;
            pbHinh.Image = null;
            txtTimKiem.Text = "Nhập số điện thoại khách hàng";
            if (_vaitro.Equals(0))
            {
                btnThem.Enabled = true;
                btnSua.Enabled = false;
            }
            else
            {
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = false;
                btnMo.Enabled = false;
            }
        }

        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            LoadGridView_Hang();
            ResetValues();
        }

        private void FrmSanPham_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTenHang.Enabled = true;
            txtDonGiaBan.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            txtGhiChu.Enabled = true;
            txtHinh.Enabled = true;
            txtSoLuong.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnMo.Enabled = true;
        }

        private void dgvSanPham_Click(object sender, EventArgs e)
        {
            string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            if (dgvSanPham.Rows.Count > 1)
            {
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnMo.Enabled = true;
                txtTenHang.Enabled = true;
                txtDonGiaBan.Enabled = true;
                txtDonGiaNhap.Enabled = true;
                txtGhiChu.Enabled = true;
                txtHinh.Enabled = true;
                txtSoLuong.Enabled = true;
                txtTenHang.Focus();
                // Show data khi chọn cell
                try
                {
                    txtMaHang.Text = dgvSanPham.CurrentRow.Cells["maHang"].Value.ToString();
                    txtTenHang.Text = dgvSanPham.CurrentRow.Cells["tenHang"].Value.ToString();
                    txtSoLuong.Text = dgvSanPham.CurrentRow.Cells["soLuong"].Value.ToString();
                    txtDonGiaNhap.Text = dgvSanPham.CurrentRow.Cells["donGiaNhap"].Value.ToString();
                    txtDonGiaBan.Text = dgvSanPham.CurrentRow.Cells["donGiaBan"].Value.ToString();
                    txtHinh.Text = dgvSanPham.CurrentRow.Cells["hinhAnh"].Value.ToString();
                    txtGhiChu.Text = dgvSanPham.CurrentRow.Cells["ghiChu"].Value.ToString();
                    pbHinh.Image = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory(), txtHinh.Text));
                    pbHinh.SizeMode = PictureBoxSizeMode.StretchImage;
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
            #region Validation data
            int intSoLuong;
            bool isInt = int.TryParse(txtSoLuong.Text.Trim().ToString(), out intSoLuong);
            float floatDonGiaNhap;
            bool isFloatNhap = float.TryParse(txtDonGiaNhap.Text.Trim().ToString(), out floatDonGiaNhap);
            float floatDonGiaBan;
            bool isFloatBan = float.TryParse(txtDonGiaBan.Text.Trim().ToString(), out floatDonGiaBan);
            if (txtTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!isInt || int.Parse(txtSoLuong.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!isFloatNhap || float.Parse(txtDonGiaNhap.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!isFloatBan || float.Parse(txtDonGiaBan.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (pbHinh.Image == null) // Kiểm tra phải nhập hình
            {
                MessageBox.Show("Bạn phải upload hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnMo.Focus();
                return;
            }
            #endregion
            else
            {
                string nameImage = string.Empty;
                try
                {
                    //Get name image

                    nameImage = txtHinh.Text.Substring(txtHinh.Text.LastIndexOf('\\') + 2);
                    
                    pbHinh.Image.Save(Path.Combine(Directory.GetCurrentDirectory(), "Images", nameImage));
                    DTO_SanPham h = new DTO_SanPham(int.Parse(txtMaHang.Text), txtTenHang.Text, int.Parse(txtSoLuong.Text), float.Parse(txtDonGiaNhap.Text), float.Parse(txtDonGiaBan.Text), Path.Combine("Images", nameImage), txtGhiChu.Text);
                    if (MessageBox.Show("Bạn có chắc muốn chỉnh sửa", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (busHang.updateDataSanPham(h))
                        {
                            MessageBox.Show("Sửa thành công");
                            ResetValues();
                            LoadGridView_Hang();
                            pbHinh.Image = null;
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int mahangxoa = int.Parse(txtMaHang.Text);
            if (MessageBox.Show("Bạn có chắc muốn xóa dữ liệu", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               
                BUS_SanPham busHang = new BUS_SanPham();
                if (busHang.deleteDataSanPham(mahangxoa))
                {
                    MessageBox.Show("Xóa dữ liệu thành công");
                    ResetValues();
                    LoadGridView_Hang();
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            BUS_SanPham busHang = new BUS_SanPham();
            string tenHang = txtTimKiem.Text;
            DataTable ds = busHang.searchDataSanPham(tenHang);
            if (ds.Rows.Count > 0) //Tim Kiếm True
            {
                dgvSanPham.DataSource = ds;

            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            txtTimKiem.Text = "Nhập tên sản phẩm";
            txtTimKiem.BackColor = Color.LightGray;
            ResetValues();
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = null;
            txtTimKiem.BackColor = Color.White;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridView_Hang();
        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridView_Hang();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
