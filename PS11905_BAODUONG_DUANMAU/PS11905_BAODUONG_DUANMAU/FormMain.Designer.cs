namespace PS11905_BAODUONG_DUANMAU
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MSHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.SDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.SDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.SProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.DThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.MSDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.hàngHóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hướngDẫnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hướngDẫnSửDụngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giớiThiệuPhầnMềmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtRole = new System.Windows.Forms.Label();
            this.lbVaitro = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MSHeThong,
            this.MSDanhMuc,
            this.hướngDẫnToolStripMenuItem,
            this.thốngKêToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1061, 24);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MSHeThong
            // 
            this.MSHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SDangNhap,
            this.SDangXuat,
            this.SProfile,
            this.DThoat});
            this.MSHeThong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MSHeThong.Name = "MSHeThong";
            this.MSHeThong.Size = new System.Drawing.Size(73, 20);
            this.MSHeThong.Text = "Hệ Thống";
            // 
            // SDangNhap
            // 
            this.SDangNhap.Image = global::PS11905_BAODUONG_DUANMAU.Properties.Resources.profile_check_icon;
            this.SDangNhap.Name = "SDangNhap";
            this.SDangNhap.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.SDangNhap.Size = new System.Drawing.Size(212, 22);
            this.SDangNhap.Text = "Đăng nhập";
            this.SDangNhap.Click += new System.EventHandler(this.SDangNhap_Click);
            // 
            // SDangXuat
            // 
            this.SDangXuat.Image = global::PS11905_BAODUONG_DUANMAU.Properties.Resources.Log_out;
            this.SDangXuat.Name = "SDangXuat";
            this.SDangXuat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.SDangXuat.Size = new System.Drawing.Size(212, 22);
            this.SDangXuat.Text = "Đăng Xuất ";
            this.SDangXuat.Click += new System.EventHandler(this.SDangXuat_Click);
            // 
            // SProfile
            // 
            this.SProfile.Image = global::PS11905_BAODUONG_DUANMAU.Properties.Resources.Card_file;
            this.SProfile.Name = "SProfile";
            this.SProfile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.SProfile.Size = new System.Drawing.Size(212, 22);
            this.SProfile.Text = "Hồ Sơ Nhân Viên";
            this.SProfile.Click += new System.EventHandler(this.SProfile_Click);
            // 
            // DThoat
            // 
            this.DThoat.Image = global::PS11905_BAODUONG_DUANMAU.Properties.Resources.Unlock;
            this.DThoat.Name = "DThoat";
            this.DThoat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.DThoat.Size = new System.Drawing.Size(212, 22);
            this.DThoat.Text = "Thoát";
            this.DThoat.Click += new System.EventHandler(this.DThoat_Click);
            // 
            // MSDanhMuc
            // 
            this.MSDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hàngHóaToolStripMenuItem,
            this.nhânViênToolStripMenuItem,
            this.kháchHàngToolStripMenuItem});
            this.MSDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.MSDanhMuc.Name = "MSDanhMuc";
            this.MSDanhMuc.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.MSDanhMuc.Size = new System.Drawing.Size(75, 20);
            this.MSDanhMuc.Text = "Danh Mục";
            // 
            // hàngHóaToolStripMenuItem
            // 
            this.hàngHóaToolStripMenuItem.Image = global::PS11905_BAODUONG_DUANMAU.Properties.Resources.product_icon;
            this.hàngHóaToolStripMenuItem.Name = "hàngHóaToolStripMenuItem";
            this.hàngHóaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.hàngHóaToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.hàngHóaToolStripMenuItem.Text = "Hàng Hóa ";
            this.hàngHóaToolStripMenuItem.Click += new System.EventHandler(this.hàngHóaToolStripMenuItem_Click);
            // 
            // nhânViênToolStripMenuItem
            // 
            this.nhânViênToolStripMenuItem.Image = global::PS11905_BAODUONG_DUANMAU.Properties.Resources.Administrator_icon;
            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.nhânViênToolStripMenuItem.Text = "Nhân Viên";
            this.nhânViênToolStripMenuItem.Click += new System.EventHandler(this.nhânViênToolStripMenuItem_Click);
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Image = global::PS11905_BAODUONG_DUANMAU.Properties.Resources.customer;
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.K)));
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.kháchHàngToolStripMenuItem.Text = "Khách Hàng";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // hướngDẫnToolStripMenuItem
            // 
            this.hướngDẫnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hướngDẫnSửDụngToolStripMenuItem,
            this.giớiThiệuPhầnMềmToolStripMenuItem});
            this.hướngDẫnToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.hướngDẫnToolStripMenuItem.Name = "hướngDẫnToolStripMenuItem";
            this.hướngDẫnToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.hướngDẫnToolStripMenuItem.Text = "Hướng Dẫn";
            // 
            // hướngDẫnSửDụngToolStripMenuItem
            // 
            this.hướngDẫnSửDụngToolStripMenuItem.Image = global::PS11905_BAODUONG_DUANMAU.Properties.Resources.Slide_Show_icon;
            this.hướngDẫnSửDụngToolStripMenuItem.Name = "hướngDẫnSửDụngToolStripMenuItem";
            this.hướngDẫnSửDụngToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.H)));
            this.hướngDẫnSửDụngToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.hướngDẫnSửDụngToolStripMenuItem.Text = "Hướng Dẫn Sử Dụng";
            // 
            // giớiThiệuPhầnMềmToolStripMenuItem
            // 
            this.giớiThiệuPhầnMềmToolStripMenuItem.Image = global::PS11905_BAODUONG_DUANMAU.Properties.Resources.Stock_icon;
            this.giớiThiệuPhầnMềmToolStripMenuItem.Name = "giớiThiệuPhầnMềmToolStripMenuItem";
            this.giớiThiệuPhầnMềmToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.G)));
            this.giớiThiệuPhầnMềmToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.giớiThiệuPhầnMềmToolStripMenuItem.Text = "Giới thiệu phần mềm";
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thốngKêSảnPhẩmToolStripMenuItem});
            this.thốngKêToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.thốngKêToolStripMenuItem.Text = "Thống Kê";
            // 
            // thốngKêSảnPhẩmToolStripMenuItem
            // 
            this.thốngKêSảnPhẩmToolStripMenuItem.Image = global::PS11905_BAODUONG_DUANMAU.Properties.Resources.Group_product_icon;
            this.thốngKêSảnPhẩmToolStripMenuItem.Name = "thốngKêSảnPhẩmToolStripMenuItem";
            this.thốngKêSảnPhẩmToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.thốngKêSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.thốngKêSảnPhẩmToolStripMenuItem.Text = "Thống Kê Sản Phẩm";
            this.thốngKêSảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.thốngKêSảnPhẩmToolStripMenuItem_Click);
            // 
            // txtRole
            // 
            this.txtRole.AutoSize = true;
            this.txtRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtRole.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRole.Location = new System.Drawing.Point(842, 4);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(0, 20);
            this.txtRole.TabIndex = 1;
            // 
            // lbVaitro
            // 
            this.lbVaitro.AutoSize = true;
            this.lbVaitro.Location = new System.Drawing.Point(936, 148);
            this.lbVaitro.Name = "lbVaitro";
            this.lbVaitro.Size = new System.Drawing.Size(0, 13);
            this.lbVaitro.TabIndex = 2;
            this.lbVaitro.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.BackgroundImage = global::PS11905_BAODUONG_DUANMAU.Properties.Resources.backgroundDuanMau1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1061, 528);
            this.Controls.Add(this.lbVaitro);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "QLBH - Màn Hình Chính";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MSHeThong;
        private System.Windows.Forms.ToolStripMenuItem MSDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem SDangNhap;
        private System.Windows.Forms.ToolStripMenuItem SDangXuat;
        private System.Windows.Forms.ToolStripMenuItem SProfile;
        private System.Windows.Forms.ToolStripMenuItem DThoat;
        private System.Windows.Forms.ToolStripMenuItem hàngHóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hướngDẫnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hướngDẫnSửDụngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giớiThiệuPhầnMềmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.Label txtRole;
        private System.Windows.Forms.Label lbVaitro;
    }
}

