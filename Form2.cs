using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace C_RandomLig
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Random rnd = new Random();

        int bjkpuan = 0, fbpuan = 0, gspuan = 0, tspuan = 0;
        int bjka = 0, fba = 0, gsa = 0, tsa = 0;
        int bjky = 0, fby = 0, gsy = 0, tsy = 0;


        private void Form2_Load(object sender, EventArgs e)
        {
            listViewPuanDurumu.View = View.Details;
            listViewPuanDurumu.FullRowSelect = true;
            listViewPuanDurumu.GridLines = true;

            axWindowsMediaPlayer1.Visible = false;

            listViewPuanDurumu.Columns.Add("Takım", 100);
            listViewPuanDurumu.Columns.Add("Oynadığı Maç", 100);
            listViewPuanDurumu.Columns.Add("Attığı Gol", 100);
            listViewPuanDurumu.Columns.Add("Yediği Gol", 100);
            listViewPuanDurumu.Columns.Add("Averaj", 100);
            listViewPuanDurumu.Columns.Add("Puan", 100);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            int a = rnd.Next(0, 4);
            int b = rnd.Next(0, 4);
            int c = rnd.Next(0, 4);
            int d = rnd.Next(0, 4);

            label7.Text = a.ToString();
            label8.Text = b.ToString();
            label9.Text = c.ToString();
            label10.Text = d.ToString();

            SkorIsle("Beşiktaş", a, b);
            SkorIsle("Galatasaray", b, a);
            SkorIsle("Fenerbahçe", c, d);
            SkorIsle("Trabzonspor", d, c);

            PuanDurumunuGuncelle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;

            int a = rnd.Next(0, 4);
            int b = rnd.Next(0, 4);
            int c = rnd.Next(0, 4);
            int d = rnd.Next(0, 4);

            label11.Text = a.ToString();
            label12.Text = b.ToString();
            label13.Text = c.ToString();
            label14.Text = d.ToString();

            SkorIsle("Galatasaray", a, b);
            SkorIsle("Trabzonspor", b, a);
            SkorIsle("Fenerbahçe", c, d);
            SkorIsle("Beşiktaş", d, c);

            PuanDurumunuGuncelle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button4.Visible = true;

            int a = rnd.Next(0, 4);
            int b = rnd.Next(0, 4);
            int c = rnd.Next(0, 4);
            int d = rnd.Next(0, 4);

            label21.Text = a.ToString();
            label22.Text = b.ToString();
            label23.Text = c.ToString();
            label24.Text = d.ToString();

            SkorIsle("Beşiktaş", a, b);
            SkorIsle("Trabzonspor", b, a);
            SkorIsle("Galatasaray", c, d);
            SkorIsle("Fenerbahçe", d, c);

            PuanDurumunuGuncelle();
        }

        private void SkorIsle(string takim, int attigi, int yedigi)
        {
            switch (takim)
            {
                case "Beşiktaş":
                    bjka += attigi; bjky += yedigi;
                    bjkpuan += PuanHesapla(attigi, yedigi);
                    break;
                case "Fenerbahçe":
                    fba += attigi; fby += yedigi;
                    fbpuan += PuanHesapla(attigi, yedigi);
                    break;
                case "Galatasaray":
                    gsa += attigi; gsy += yedigi;
                    gspuan += PuanHesapla(attigi, yedigi);
                    break;
                case "Trabzonspor":
                    tsa += attigi; tsy += yedigi;
                    tspuan += PuanHesapla(attigi, yedigi);
                    break;
            }
        }

        private int PuanHesapla(int atilan, int yenilen)
        {
            if (atilan > yenilen) return 3;
            if (atilan == yenilen) return 1;
            return 0;
        }

        private void PuanDurumunuGuncelle()
        {
            listViewPuanDurumu.Items.Clear();

            var takimlar = new List<(string Ad, int Mac, int Attigi, int Yedigi, int Averaj, int Puan)>
    {
        ("Beşiktaş", 3, bjka, bjky, bjka - bjky, bjkpuan),
        ("Fenerbahçe", 3, fba, fby, fba - fby, fbpuan),
        ("Galatasaray", 3, gsa, gsy, gsa - gsy, gspuan),
        ("Trabzonspor", 3, tsa, tsy, tsa - tsy, tspuan)
    };

            var sirali = takimlar
                .OrderByDescending(t => t.Puan)
                .ThenByDescending(t => t.Averaj)
                .ToList();

            foreach (var t in sirali)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
            t.Ad,
            t.Mac.ToString(),
            t.Attigi.ToString(),
            t.Yedigi.ToString(),
            t.Averaj.ToString(),
            t.Puan.ToString()
                });

                listViewPuanDurumu.Items.Add(item);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Visible = true;
            label31.Visible = true;
            var takimlar = new List<(string Ad, int Puan, int Averaj)>
            {
                  ("Beşiktaş", bjkpuan, bjka - bjky),
                  ("Fenerbahçe", fbpuan, fba - fby),
                  ("Galatasaray", gspuan, gsa - gsy),
                  ("Trabzonspor", tspuan, tsa - tsy)
            };

            var siraliTakimlar = takimlar.OrderByDescending(t => t.Puan)
                                          .ThenByDescending(t => t.Averaj)
                                          .ToList();

            string sampiyon = siraliTakimlar[0].Ad;

            if (sampiyon == "Fenerbahçe")
            {
                sampiyon = sampiyon.ToUpper();
                labelşampiyon.Text = sampiyon;
                axWindowsMediaPlayer1.URL = "C:\\Users\\furkn\\OneDrive\\Masaüstü\\c# form dersleri\\Ders4\\C#RandomLig\\Dosyalar\\fb.mp3";
                pictureBox1.ImageLocation = "C:\\Users\\furkn\\OneDrive\\Masaüstü\\c# form dersleri\\Ders4\\C#RandomLig\\Dosyalar\\fb.png";
            }

            if (sampiyon == "Beşiktaş")
            {
                sampiyon = sampiyon.ToUpper();
                labelşampiyon.Text = sampiyon;
                axWindowsMediaPlayer1.URL = "C:\\Users\\furkn\\OneDrive\\Masaüstü\\c# form dersleri\\Ders4\\C#RandomLig\\Dosyalar\\bjk.mp3";
                pictureBox1.ImageLocation = "C:\\Users\\furkn\\OneDrive\\Masaüstü\\c# form dersleri\\Ders4\\C#RandomLig\\Dosyalar\\bjk.png";
            }

            if (sampiyon == "Galatasaray")
            {
                sampiyon = sampiyon.ToUpper();
                labelşampiyon.Text = sampiyon;
                axWindowsMediaPlayer1.URL = "C:\\Users\\furkn\\OneDrive\\Masaüstü\\c# form dersleri\\Ders4\\C#RandomLig\\Dosyalar\\gs.mp3";
                pictureBox1.ImageLocation = "C:\\Users\\furkn\\OneDrive\\Masaüstü\\c# form dersleri\\Ders4\\C#RandomLig\\Dosyalar\\gs.png";
            }

            if (sampiyon == "Trabzonspor")
            {
                sampiyon = sampiyon.ToUpper();
                labelşampiyon.Text = sampiyon;
                axWindowsMediaPlayer1.URL = "C:\\Users\\furkn\\OneDrive\\Masaüstü\\c# form dersleri\\Ders4\\C#RandomLig\\Dosyalar\\ts.mp3";
                pictureBox1.ImageLocation = "C:\\Users\\furkn\\OneDrive\\Masaüstü\\c# form dersleri\\Ders4\\C#RandomLig\\Dosyalar\\ts.png";
            }
        }
    }
}


