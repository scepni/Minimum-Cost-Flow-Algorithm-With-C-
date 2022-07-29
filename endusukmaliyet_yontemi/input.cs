using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace endusukmaliyet_yontemi
{
    public partial class input : Form
    {
       
        
        public input()
        {

            InitializeComponent();
        }
        private void Onayla_button_Click(object sender, EventArgs e)
        {
            if (input_fabrika_tb.Text == "" || input_sehir_tb.Text == "")
            {
                MessageBox.Show("Fabrika ve Şehir Sayısını Eksiksiz Doldurunuz!");
            }
            else if (Convert.ToInt32(input_sehir_tb.Text) <= 0 || Convert.ToInt32(input_fabrika_tb.Text) <= 0)
            {
                MessageBox.Show("Fabrika Ve Şehir Sayısı 0'dan Küçük Ya Da 0'a Eşit Olamaz!");
            }
            else if (Convert.ToInt32(input_sehir_tb.Text) > 8 || Convert.ToInt32(input_fabrika_tb.Text) > 8)
            {
                MessageBox.Show("Lütfen 8'den küçük bir değer giriniz!");
            }
            else
            {
               
                Form1_Panel f1 = new Form1_Panel();
              
                f1.Show();
                
                //Fabrika Ve Şehir Sayısı Form1'e Atandı.
                f1.Fabrika_Sayisi = Convert.ToInt32(input_fabrika_tb.Text);
                f1.Sehir_Sayisi = Convert.ToInt32(input_sehir_tb.Text);
               

                this.Hide();
                //Fonksiyonlar Çağırıldı

                f1.AdimYazdir();
                f1.DynamicTbOlustur();
                f1.TemizleButtonOlustur();
                f1.HesaplaButtonOlustur();
                f1.YenidenBaslatButton();
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void sehir_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void input_Load(object sender, EventArgs e)
        {
        }
    }
}