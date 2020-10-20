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
    public partial class FormThongKe : Form
    {
        public FormThongKe()
        {
            InitializeComponent();
            LoadGridView_ThongKeHang();
            LoadGridView_ThongkeTonKho();
        }

        private void LoadGridView_ThongKeHang()
        {
            BUS_SanPham busHang = new BUS_SanPham();
            dgvNhapKho.AutoResizeColumns();
            dgvNhapKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvNhapKho.DataSource = busHang.ThongKeDataSP();
            dgvNhapKho.Columns[0].HeaderText = "Mã Nhân Viên";
            dgvNhapKho.Columns[1].HeaderText = "Tên Nhân Viên";
            dgvNhapKho.Columns[2].HeaderText = "Số Lượng Sản Phẩm Nhập";
            dgvNhapKho.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvNhapKho.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }


        private void LoadGridView_ThongkeTonKho()
        {
            BUS_SanPham busHang = new BUS_SanPham();
            dgvTonKho.AutoResizeColumns();
            dgvTonKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvTonKho.DataSource = busHang.ThongKeDataTonKho();
            dgvTonKho.Columns[0].HeaderText = "Tên Sản Phẩm";
            dgvTonKho.Columns[1].HeaderText = "Số Lượng Tồn";
            dgvTonKho.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTonKho.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
    }
}
