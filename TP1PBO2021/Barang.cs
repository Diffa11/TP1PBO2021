using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1PBO2021
{
    class Barang
    {
        //membuat setter dan getter barang yang akan ditampilkan
        public int id { get; set; }//idnya
        public string nama { get; set; }//namanya
        public string jenis { get; set; }//jenisnya
        public int harga { get; set; }//harganya
        public string foto { get; set; }//fotonya
        public Barang() { }//inisialisasi
        public Barang(int id, string nama, string jenis, int harga, string foto)
        {
            this.id = id;
            this.nama = nama;
            this.jenis = jenis;
            this.harga = harga;
            this.foto = foto;
        }
    }
}