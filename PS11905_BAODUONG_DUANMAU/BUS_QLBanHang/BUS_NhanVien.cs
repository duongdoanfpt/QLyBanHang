using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;
using DTO_QLBanHang;
using DAL_QLBanHang;
using System.Data;

namespace BUS_QLBanHang
{
    public class BUS_NhanVien
    {
        DAL_ThanhVien dalNhanVien = new DAL_ThanhVien();
        public bool NhanVienDangNhap(DTO_NhanVien nv)
        {
            return dalNhanVien.NhanVienDangNhap(nv);
        }

        public bool NhanVienQuenMatKhau(string email)
        {
            return dalNhanVien.NhanVienQuenMatKhau(email);
        }

        public DataTable VaiTroNhanVien(string email)
        {
            return dalNhanVien.VaiTroNhanVien(email);
        }

        public bool UpdateMatKhau(string email, string matKhauCu, string matKhauMoi)
        {
            return dalNhanVien.UpdateMatKhau(email, matKhauCu, matKhauMoi);
        }

        public DataTable getAllNhanVien()
        {
            return dalNhanVien.getAllNhanVien();
        }

        public bool inserNhanVien(DTO_NhanVien nv)
        {
            return dalNhanVien.insertNhanVien(nv);
        }

        public bool updateNhanVien(DTO_NhanVien nv)
        {
            return dalNhanVien.updateNhanVien(nv);
        }

        public bool deleteNhanVien(string tendangnhap)
        {
            return dalNhanVien.DeleteNhanVien(tendangnhap);
        }

        public DataTable searchNhanVien(string tenNhanVien)
        {
            return dalNhanVien.SearchNhanVien(tenNhanVien);
        }

        public bool updateMK(DTO_NhanVien nv)
        {
            return dalNhanVien.TaoMatKhauMoi(nv);
        }

        public string Encryption(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();

        }

        //Ham Send Mail
        public void SendMail(string email, string matkhau)
        {

            SmtpClient client = new SmtpClient("smtp.gmail.com", 25);

            NetworkCredential cred = new NetworkCredential("bellben7777@gmail.com", "Anhthu1521@@");
            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress("bellben7777@gmail.com");
            Msg.To.Add(email);
            Msg.Subject = "Ban da su dung tinh nang quen mat khau";
            Msg.Body = "Mật khẩu mới là " + matkhau;
            client.Credentials = cred;
            client.EnableSsl = true;
            client.Send(Msg);


        }

        //Tao chuoi Ngau Nhien
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
            {
                return builder.ToString().ToLower();
            }
            return builder.ToString();
        }

        //Tao so ngau nhien
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        // Tao MatKhau Moi
        //public string TaoMatKhau()
        //{

        //}
    }

}
