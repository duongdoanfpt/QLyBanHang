using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS11905_BAODUONG_DUANMAU
{
    static class Program
    {
        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            int CheckDangNhap = 0;
            Application.Run(new FormMain(CheckDangNhap));
            //Application.Run(new FormDangNhap());
            //Application.Run(new FrmSanPham());
            //Application.Run(new FrmNhanVien());
            //Application.Run(new FrmKhachHang());
            
        }
    }
}
