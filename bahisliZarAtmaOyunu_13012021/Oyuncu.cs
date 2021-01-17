using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bahisliZarAtmaOyunu_13012021
{
    class Oyuncu
    {
        public string Ad { get; set; }
        public Zar OyuncununZari { get; set; }
        public int AnaBakiye { get; set; }
        public int Bahis { get; set; }

        public void Oyna()
        {
            OyuncununZari.At();
        }

        public Oyuncu(string ad, int anaBakiye)
        {
            Ad = ad;
           AnaBakiye = anaBakiye;
        }

        public void BahisGir(int bahis)
        {
            Bahis = bahis;
            AnaBakiye -= bahis;
        }
    }
}
