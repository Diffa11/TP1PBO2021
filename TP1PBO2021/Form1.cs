using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1PBO2021
{
    public partial class Form1 : Form
    {
        Akun akun; //deklarasi
        public Form1()
        {
            InitializeComponent();
            this.akun = new Akun(); //inisialisasi
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //masukan
            this.akun.username = Convert.ToString(tbUsername.Text);
            this.akun.password = Convert.ToString(tbPassword.Text);

            if(this.akun.username == "")//jika usernamenya ga diisi
            {
                string Message = "Anda belum masukan username!";//tampilkan pesan
                MessageBox.Show(Message);//tampil
            }
            else if(this.akun.password != "pbo123")//jika paswordnya buka itu
            {
                string Message = "Password yang anda masukan salah!";//tampilkan pesan
                MessageBox.Show(Message);//tampil
            }
            else//jika username diisi dan passnya benar
            {
                Home tampilan1 = new Home();//ke Home
                tampilan1.Show();//tampilin
                this.Hide();//yang ini di hide
            }
        }
    }
}