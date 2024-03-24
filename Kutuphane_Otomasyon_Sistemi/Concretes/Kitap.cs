using Kutuphane_Otomasyon_Sistemi.Abstracts;
using Kutuphane_Otomasyon_Sistemi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyon_Sistemi.Concretes
{
    public abstract class Kitap
    {

        //public List<KitapBilim> BilimKitaplari { get; set; } // BilimKitaplari listesi
        //public List<KitapRoman> RomanKitaplari { get; set; } // RomanKitaplari listesi
        //public List<KitapTarih> TarihKitaplari { get; set; } // TarihKitaplari listesi

        public string ISBN { get; set; } // ISBN-1234-5678 gibi.
        public string Baslik { get; set; }
        public string Yazar { get; set; }
        public string Yayinevi { get; set; }
        public int YayinYili { get; set; } // datetime -> yayın tarihi yapılablir

        //public double Stok { get; set; }
        public Durum KitapDurumu { get; set; }


        public Kitap(string isbn, string baslik, string yazar, int yayinYili, string yayinevi)
        {
            ISBN = isbn;
            Baslik = baslik;
            Yazar = yazar;
            YayinYili = yayinYili;
            KitapDurumu = Durum.MevcutDegil; // Yeni kitaplar varsayılan olarak mevcut değil ?
            Yayinevi = yayinevi;
        }

    }
}
