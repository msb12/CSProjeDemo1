using Kutuphane_Otomasyon_Sistemi.Abstracts;
using Kutuphane_Otomasyon_Sistemi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyon_Sistemi.Concretes
{
    internal class Uye : IUye
    {

        //private string TcKimlikNo { get; set; }
        public long UyeNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public List<Kitap> OduncKitaplar { get; set; } //üyenin ödünç aldıkları


        /*
        public void KitapOduncAl(Kitap kitap)
        {
            OduncKitaplar.Add(kitap);
            kitap.KitapDurumu = Durum.Oduncte;
        }

        public void KitapIadeEt(Kitap kitap)
        {
            OduncKitaplar.Remove(kitap);
            kitap.KitapDurumu = Durum.OduncAlinabilir;
        }
        */


        public Uye(string ad, string soyad, long uyeNo)
        {
            Ad = ad;
            Soyad = soyad;
            UyeNo = uyeNo;
            OduncKitaplar = new List<Kitap>();
        }


        public void KitapOduncAl(Kitap kitap)
        {
            if (kitap.KitapDurumu == Durum.MevcutDegil)
            {
                Console.WriteLine("Üzgünüz, bu kitap şu anda mevcut değil.");
                return;
            }

            kitap.KitapDurumu = Durum.Oduncte;
            OduncKitaplar.Add(kitap);
            Console.WriteLine($"{kitap.Baslik} kitabı ödünç alındı.");
        }

        public void KitapIadeEt(Kitap kitap)
        {
            if (!OduncKitaplar.Contains(kitap))
            {
                Console.WriteLine("Bu kitabı siz ödünç almamışsınız.");
                return;
            }

            kitap.KitapDurumu = Durum.OduncAlinabilir;
            OduncKitaplar.Remove(kitap);
            Console.WriteLine($"{kitap.Baslik} kitabı iade edildi.");
        }

    }
}
