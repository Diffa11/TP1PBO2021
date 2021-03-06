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
    public partial class Home : Form
    {
        List<Barang> dataBarang = new List<Barang>();
        private int rangeHargaMin = 0;//harga maksimal
        private int rangeHargaMax = 0;//harga minimal
        private string jenisBarang = null;//combox jenis barang
        public static string idBeli;//button beli
        private string simpenJenisBarang = null;//temp tampungan
        public Home()
        {
            InitializeComponent();//dijalanin 1x waktu tampl aja 
            setBarang();//ngeset barang yang mau ditampilakn
            nampilinBarang();//nampilin barang yang sudah diset
        }
        
        void setBarang()
        {
            //set semua barang dengan indesk,nama,jenis,harga,foto
            this.dataBarang.Add(new Barang(0,"Mesin Cuci", "Elektronik", 200000, "Mesin-Cuci-Front-Loading-F2720SVTV"));
            this.dataBarang.Add(new Barang(1,"Pisang Ambon", "Makanan", 100000, "pis"));
            this.dataBarang.Add(new Barang(2,"Baju Bayi", "Pakaian", 300000, "Peter Parker"));
            this.dataBarang.Add(new Barang(3,"Burger", "Makanan", 400000, "bur"));
            this.dataBarang.Add(new Barang(4,"HP Samsung", "Elektronik", 700000, "sams"));
        }
        void nampilinBarang()
        {
            //melakukan perulangan sebanyak data barang
            flowlayout.Controls.Clear();//kosongin panel layar
            foreach (var data in this.dataBarang)
            {
                if (data.jenis == this.jenisBarang)//jika data jenisnya sama dengan jenis barang
                {
                    if (this.rangeHargaMin <= data.harga && this.rangeHargaMax >= data.harga)//jika harga min lebih kecil dari data dan max lebih dari data
                    {
                        flowlayout.Controls.Add(NampilinKotak(data.nama, data.id, data.harga, data.foto));//cetak
                    }
                    else if (this.rangeHargaMin == 0)//jika tidak
                    {
                        flowlayout.Controls.Add(NampilinKotak(data.nama, data.id, data.harga, data.foto));//cetak
                    }
                }
                else if (this.jenisBarang == null)//jika null
                {
                    if(this.rangeHargaMin <= data.harga && this.rangeHargaMax >= data.harga)//jika harga min lebih kecil dari data dan max lebih dari data
                    {
                        flowlayout.Controls.Add(NampilinKotak(data.nama, data.id, data.harga, data.foto));//cetak
                    }
                    else if(this.rangeHargaMin == 0)//jika tidak
                    {
                        flowlayout.Controls.Add(NampilinKotak(data.nama, data.id, data.harga, data.foto));//cetak
                    }
                }
            }
        }
        private void btnKembali_Click(object sender, EventArgs e)//untuk logout
        {
            Form1 login = new Form1();//ke login
            login.Show();//loginnya ditampilkan
            this.Hide();//home di hide
        }

        private void btnWeb_Click(object sender, EventArgs e)//untuk web
        {
            System.Diagnostics.Process.Start("Chrome", "https://www.tokopedia.com/");//ngelik ke web tokped
        }

        private void cbJenis_SelectedIndexChanged(object sender, EventArgs e)//untuk combobox jenis
        {
            this.jenisBarang = (sender as ComboBox).SelectedItem.ToString();//cbJenis = namacb
            if (this.jenisBarang == "All")//jika milih ALL
            {
                this.jenisBarang = null;//dinullkan
            }
        }

        private void cbHarga_SelectedIndexChanged(object sender, EventArgs e)//untuk combobox harga
        {
            string price = (sender as ComboBox).SelectedItem.ToString();

            if (price == "100.000 - 200.000")//jika memilih harga 100k - 200k
            {
                this.rangeHargaMin = 100000;//minnya 100k
                this.rangeHargaMax = 200000;//maksnya 100k
            }
            else if (price == "200.000 - 500.000")//jika milih harga 200k - 500k
            {
                this.rangeHargaMin = 200000;//min 200k
                this.rangeHargaMax = 500000;//mak 500
            }
            else if (price == "500.000 - 1.000.000")//jika memilih harga 500k - 1jt
            {
                this.rangeHargaMin = 500000;//min 500k
                this.rangeHargaMax = 1000000;//mak 1jt
            }
            else if (price == "All")//jika memilih all
            {
                this.rangeHargaMin = 0;//default nilai
                this.rangeHargaMax = 0;//default milai
            }
        }

        private void btnCari_Click(object sender, EventArgs e)//untuk button cari
        {
            nampilinBarang();//tampilin barangnya
        }

        private void flowlayout_Paint(object sender, PaintEventArgs e)
        {

        }

        /*public string nama;
        public int harga;
        public string foto;*/

        //============================================================================
        //untuk kotak gede sebelah kanan

        public Panel NampilinKotak(string nama, int id, int harga, string foto)//untuk menampilakn panel yang besar menampilkan semua barang"nya
        {
            return createKotakkecil(nama, id, harga, foto);
        }

        Panel createKotakkecil(string nama, int id, int harga, string foto)//untuk menampilkan barang" yang tersedia
        {
            Panel panel3 = new Panel();//kotak yang kecil 

            //inisialisasi dulu baru ambil yang bawahnya
            PictureBox gambar = createFotoBarang(foto);//untuk foto barang
            panel3.Controls.Add(gambar);

            Label lbnama = createNama(nama);//untuk nama barang
            panel3.Controls.Add(lbnama);

            Label lbharga = createHarga(harga);//untuk harga barang
            panel3.Controls.Add(lbharga);

            Button btnbeli = createBeli(id);//untuk but beli
            panel3.Controls.Add(btnbeli);

            //kotak kecil buat barang
            panel3.Location = new System.Drawing.Point(30, 32);
            panel3.Margin = new System.Windows.Forms.Padding(30, 32, 8, 8);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(112, 194);
            panel3.TabIndex = 0;

            return panel3;//return
        }

        PictureBox createFotoBarang(string foto)//membuat kotak foto
        {
            PictureBox pictureBox1 = new PictureBox();//inisialisasi
            //diambil dari home.Designers
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject(foto);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.Location = new System.Drawing.Point(10, 11);
            pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(93, 117);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            return pictureBox1;//return
        }

        Label createNama(string nama)//membuat nama barang
        {
            Label lbBarang = new Label();//inisialisasi
            //diambil dari home.Designers
            lbBarang.AutoSize = true;
            lbBarang.Location = new System.Drawing.Point(26, 130);
            lbBarang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lbBarang.Name = "lbBarang";
            lbBarang.Size = new System.Drawing.Size(28, 13);
            lbBarang.TabIndex = 0;
            lbBarang.Text = nama;//sudah string
            return lbBarang;//return
        }

        Label createHarga(int harga)//membuat harga barang
        {
            Label lbHarga = new Label();//inisialisasi
            lbHarga.AutoSize = true;
            lbHarga.Location = new System.Drawing.Point(26, 144);
            lbHarga.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lbHarga.Name = "lbHarga";
            lbHarga.Size = new System.Drawing.Size(66, 13);
            lbHarga.TabIndex = 1;
            lbHarga.Text = harga.ToString();//buat harganya jadi dinamis. Asalnya int => string karna mo d tampilin bentuk text
            return lbHarga;//return
        }

        Button createBeli(int id)
        {
            Button btnBeli = new Button();//inisialisasi
            btnBeli.Location = new System.Drawing.Point(26, 160);
            btnBeli.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            btnBeli.Name = id.ToString();
            btnBeli.Size = new System.Drawing.Size(56, 19);
            btnBeli.TabIndex = 2;
            btnBeli.Text = "Beli";
            btnBeli.UseVisualStyleBackColor = true;
            btnBeli.Click += new EventHandler(btnBeli_Click);
            return btnBeli;//return
        }

        //============================================================================
        //untuk kotak besar detail

        private void btnBeli_Click(object sender, EventArgs e)//untuk button beli yg di klik nantinya
        {
            string id_btn;//inisialisasi
            id_btn = (sender as Button).Name;//ngambil dari prosedur createBeli

            foreach (var dt in this.dataBarang)//loop sebanyak data barang
            {
                if (dt.id.ToString() == id_btn)
                {
                    rangeHargaMin = dt.harga;
                    rangeHargaMax = dt.harga;
                    jenisBarang = dt.jenis;
                }
            }

            panelCari.Controls.Clear();//dibersihkan

            Button btn = createBtnBack();
            panelCari.Controls.Add(btn);

            nampilinBarang();//ditampilkan
        }

        Button createBtnBack()//untuk button kembali
        {
            Button btnBack = new Button();//inisialisasi
            //diambil dari home.designer
            btnBack.Location = new System.Drawing.Point(49, 70);
            btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new System.Drawing.Size(62, 28);
            btnBack.TabIndex = 0;
            btnBack.Text = "Kembali";
            btnBack.UseVisualStyleBackColor = true;

            btnBack.Click += new EventHandler(Home_Click);//apabila di klik but kembali
            return btnBack;//return
        }

        private void Home_Click(object sender, EventArgs e)//prosedur home_click
        {
            this.jenisBarang = null;//jenisnya dinullkan
            this.rangeHargaMax = 0;//maxnya di 0 kan
            this.rangeHargaMin = 0;//minnya di 0 kan
            tampilCari();//tampilkan
            nampilinBarang();//nampilkan
        }

        private void Home_Load(object sender, EventArgs e)//untuk home
        {
            tampilCari();//tampilkan
        }

        void tampilCari()//prosedu tampil
        {
            //Panel panelCari = new Panel();
            panelCari.Controls.Clear();//di bersihkan
            ComboBox jenis = createcbJenis();//lalu panggil cb jenis
            panelCari.Controls.Add(jenis);

            ComboBox harga = createcbHarga();//lalu panggil cb harga
            panelCari.Controls.Add(harga);

            Button cari = createbtnCari();//lalu panggil btn cari
            panelCari.Controls.Add(cari);
        }

        ComboBox createcbJenis()//membuat combo box jenis
        {
            ComboBox cbJenis = new ComboBox();//inisialisasi
            //diambil dari Home.Designer
            cbJenis.FormattingEnabled = true;
            cbJenis.Items.AddRange(new object[] {
            "Elektronik",
            "Pakaian",
            "Makanan",
            "All"});
            cbJenis.Location = new System.Drawing.Point(31, 33);
            cbJenis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cbJenis.Name = "cbJenis";
            cbJenis.Size = new System.Drawing.Size(130, 24);
            cbJenis.TabIndex = 3;
            cbJenis.Text = "Jenis Barang";
            cbJenis.SelectedIndexChanged += new System.EventHandler(cbJenis_SelectedIndexChanged);
            return cbJenis;//return
        }
        ComboBox createcbHarga()
        {
            ComboBox cbHarga = new ComboBox();//inisiaslisasi
            //diambil dari Home.Designer
            cbHarga.FormattingEnabled = true;
            cbHarga.Items.AddRange(new object[] {
            "100.000 - 200.000",
            "200.000 - 500.000",
            "500.000 - 1.000.000",
            "All"});
            cbHarga.Location = new System.Drawing.Point(31, 86);
            cbHarga.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cbHarga.Name = "cbHarga";
            cbHarga.Size = new System.Drawing.Size(130, 24);
            cbHarga.TabIndex = 4;
            cbHarga.Text = "Harga";
            cbHarga.SelectedIndexChanged += new System.EventHandler(cbHarga_SelectedIndexChanged);
            return cbHarga;//return
        }
        Button createbtnCari()//membuat butn cari
        {
            Button btnCari = new Button();//inisialisasi
            //diambil dari Home.Designer
            btnCari.Location = new System.Drawing.Point(31, 146);
            btnCari.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnCari.Name = "btnCari";
            btnCari.Size = new System.Drawing.Size(67, 27);
            btnCari.TabIndex = 5;
            btnCari.Text = "Cari";
            btnCari.UseVisualStyleBackColor = true;
            btnCari.Click += new System.EventHandler(btnCari_Click);
            return btnCari;//return
        }
    }
}
