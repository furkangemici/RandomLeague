using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_RandomLig
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "oyuncu" && textBox2.Text == "1234")
            {
                Form2 oyun = new Form2();
                oyun.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı giriş yaptınız", "Hata", MessageBoxButtons.OK , MessageBoxIcon.Warning);
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)  
            {
                Form2 oyun = new Form2();
                oyun.Show();
                this.Hide();
            }
        }
    }
}
