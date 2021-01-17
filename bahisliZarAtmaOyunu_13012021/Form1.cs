using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bahisliZarAtmaOyunu_13012021
{
    public partial class BahisliZarAtmaOyunu : Form
    {
        public BahisliZarAtmaOyunu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
         * Bu oyunda iki oyuncu vardır.
         * Her oyuncunun bir zarı vardır.
         * Her oyuncunun hesabına tanımlı 100 lira bakiye vardır.
         * Her oyuncu oyuna başlamadan önce bahis için bakiyenin bir miktarını ortaya koyar.
         * Bahis için oynanan miktar oyuncuların bakiyesinden düşülür.
         * Oyuncular zar atar.
         * Zarlar karşılaştırılır.
         * Büyük atan kazanır.
         * Bahis oynanan miktar kazananın bakiyesine eklenir.
         * Bakiyesi sıfırlanan ya da eksiye düşen iflas eder.
         * Nesneler: oyun, oyuncu, zar
         */
        }

        Oyun zarOyunu = new Oyun();

        private void buttonOyuncu1Ad_Click(object sender, EventArgs e)
        {
            if(textBoxAnaBakiye1.Text.Trim() == "")
            {
                MessageBox.Show("Lütfen ana1 bakiye giriniz!");
            }
            else
            {
                textBoxAnaBakiye1.Text.Trim();
            }
            zarOyunu.BirinciOyuncu = new Oyuncu(textBoxAd1.Text, Convert.ToInt32(textBoxAnaBakiye1.Text));
            zarOyunu.BirinciOyuncu.OyuncununZari = new Zar();
            labelOyuncu1Ad.Text = zarOyunu.BirinciOyuncu.Ad;
            textBoxOyuncu1BahisGir.Enabled = true;
        }

        private void buttonOyuncu2Ad_Click(object sender, EventArgs e)
        {
            if (textBoxAnaBakiye2.Text.Trim() == "")
            {
                MessageBox.Show("Lütfen ana bakiye2 giriniz!");
            }
            else
            {
                textBoxAnaBakiye2.Text.Trim();
            }
            zarOyunu.IkinciOyuncu = new Oyuncu(textBoxAd2.Text, Convert.ToInt32(textBoxAnaBakiye2.Text));
            zarOyunu.IkinciOyuncu.OyuncununZari = new Zar();
            labelOyuncu2Ad.Text = zarOyunu.IkinciOyuncu.Ad;
            textBoxOyuncu2BahisGir.Enabled = true;
        }

        private void buttonOyuncu1ZarAt_Click(object sender, EventArgs e)
        {
            zarOyunu.IlkOyuncuZarAt();
            labelOyuncu1Zar.Text = zarOyunu.BirinciOyuncu.OyuncununZari.Deger.ToString();
            buttonOyuncu2ZarAt.Enabled = true;

        }

        private void buttonOyuncu2ZarAt_Click(object sender, EventArgs e)
        {
            zarOyunu.IkınciOyuncuZarAt();
            labelOyuncu2Zar.Text = zarOyunu.IkinciOyuncu.OyuncununZari.Deger.ToString();

            Oyuncu kazanan = zarOyunu.Karsilastir();
            if (kazanan != null)
            {
                labelKazanan.Text = $"{kazanan.Ad}, {kazanan.OyuncununZari.Deger} atarak oyunu kazandı.";
                labelOyuncu1Bakiye.Text = zarOyunu.BirinciOyuncu.AnaBakiye.ToString();
                labelOyuncu2Bakiye.Text = zarOyunu.IkinciOyuncu.AnaBakiye.ToString();
            }
            else
            {
                labelKazanan.Text = "Berabere!!!";
            }
           
            int bakiye1 = Convert.ToInt32(zarOyunu.BirinciOyuncu.AnaBakiye.ToString());
            int bakiye2 = Convert.ToInt32(zarOyunu.IkinciOyuncu.AnaBakiye.ToString());
            if (bakiye1 < 0 || bakiye1 == 0)
            {
                 DialogResult bitti = MessageBox.Show($"{zarOyunu.BirinciOyuncu.Ad} iflas etti. Oyunu {zarOyunu.IkinciOyuncu.Ad} kazandı. ");
                 if (bitti == DialogResult.OK)
                 {
                    Application.Exit();
                 }
            }
            else if (bakiye2 < 0 || bakiye2 == 0)
            {
                 DialogResult bitti = MessageBox.Show($"{zarOyunu.IkinciOyuncu.Ad} iflas etti. Oyunu {zarOyunu.BirinciOyuncu.Ad} kazandı. ");
                  if (bitti == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            
        }

        private void buttonOyuncu1Bahis_Click(object sender, EventArgs e)
        {
            zarOyunu.BirinciOyuncu.BahisGir(Convert.ToInt32(textBoxOyuncu1BahisGir.Text));
            textBoxOyuncu1BahisGir.Text = zarOyunu.BirinciOyuncu.Bahis.ToString();
        }

        private void buttonOyuncu2Bahis_Click(object sender, EventArgs e)
        {
            zarOyunu.IkinciOyuncu.BahisGir(Convert.ToInt32(textBoxOyuncu2BahisGir.Text));
            textBoxOyuncu2BahisGir.Text = zarOyunu.IkinciOyuncu.Bahis.ToString();
        }
    }
}
