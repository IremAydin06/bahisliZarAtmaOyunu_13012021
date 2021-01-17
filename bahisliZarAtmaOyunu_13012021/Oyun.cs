using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bahisliZarAtmaOyunu_13012021
{
    class Oyun
    {
        public Oyuncu BirinciOyuncu { get; set; }
        public Oyuncu IkinciOyuncu { get; set; }

        public void IlkOyuncuZarAt()
        {
            BirinciOyuncu.Oyna();
        }

        public void IkınciOyuncuZarAt()
        {
            IkinciOyuncu.Oyna();
        }

        public Oyuncu Karsilastir()
        {
            if (BirinciOyuncu.OyuncununZari.Deger > IkinciOyuncu.OyuncununZari.Deger)
            {
                BirinciOyuncu.AnaBakiye += BirinciOyuncu.Bahis + IkinciOyuncu.Bahis;
                return BirinciOyuncu;
            }
            else if (BirinciOyuncu.OyuncununZari.Deger < IkinciOyuncu.OyuncununZari.Deger)
            {
                IkinciOyuncu.AnaBakiye += BirinciOyuncu.Bahis + IkinciOyuncu.Bahis;
                return IkinciOyuncu;
            }
            else
            {
                return null;
            }

        }
    }
}
