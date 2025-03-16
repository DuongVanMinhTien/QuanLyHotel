using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace QLHotel
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }
        public bool checkAccount(string ac)
        {
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{6,24}$");
        }

        public bool CheckEmail(string em)
        {
            return Regex.IsMatch(em, @"^[a-zA-Z0-9_.]{3,20}@gmail.com(.vn|)$");
        }
        Modify modify = new Modify();
        private void btnDK_Click(object sender, EventArgs e)
        {
            string tenTK = txtTenTK.Text;
            string matkhau = txtMK.Text;
            string xnmatkhau = txtXacNhanMK.Text;
            string email = txtEmail.Text;
            if(!checkAccount(tenTK)) { MessageBox.Show("Vui lòng nhập tên tài khoản dài 6 - 24 ký tự, với các ký tự chữ cái và số, chữ hoa và chữ thường!"); return;}
            if (!checkAccount(matkhau)) { MessageBox.Show("Vui lòng nhập tên mật khẩu dài 6 - 24 ký tự, với các ký tự chữ cái và số, chữ hoa và chữ thường!"); return;}
            if(!checkAccount(xnmatkhau)) { MessageBox.Show("Vui lòng xác nhận mật khẩu chính xác!"); return; }
            if(!checkAccount(email)) { MessageBox.Show("Vui lòng nhập đúng định dạng email!"); return; }
            if(modify.TaiKhoans("Select * from TaiKhoan where Email = '"+email+"'").Count !=0) { MessageBox.Show("Email này đã được đăng kí, vui lòng đăng kí email khác!"); return; }
            try
            {
                string query = "Insert into Taikhoan values ('" + tenTK + "','" + matkhau + "','" + email + "')";
                modify.Command(query);
            }
            catch
            {
                MessageBox.Show("Tên tài khoản này đã được đăng ký, vui lòng đăng kí tên tài khoản khác!");
            }
        }
    }
}
