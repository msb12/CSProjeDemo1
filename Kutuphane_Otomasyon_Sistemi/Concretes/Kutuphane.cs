using Kutuphane_Otomasyon_Sistemi.Abstracts;
using Kutuphane_Otomasyon_Sistemi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyon_Sistemi.Concretes
{
    /*
    Kütüphanemizde birden fazla türde kitaplar bulunmaktadır.
    Örneğin(Bilim, Roman, Tarih, v.b.) bu kitap türleri zaman içerisinde genişletilebilir yapıda
    olmalıdır.

    Kütüphanemizde tek tip üye bulunmaktadır. Kütüphane sistemine dahil olan herkes kütüphane stoğunda
    bulunan kitaplardan ödünç alabilir. (Ödünç işlemi için şartlar sisteme dahil olmak ve kütüphane
    stoğundan yeterli sayıda kitap olmak.)


Beklenen İşlevler:

•  Bir üye kitap ödünç alabilmeli.
•  Bir üye ödünç aldığı kitabı iade edebilmeli.
•  Bir kitabın mevcut durumu güncellenebilmeli(ödünç alınabilir, ödünçte, mevcut değil).
•  Bir üyenin ödünç aldığı kitapları görüntüleyebilmeli.
•  Kütüphane durumunu (mevcut kitaplar, ödünç alınan kitaplar, üyeler vb.)
görüntüleyebilmeli.

    */



    internal class Kutuphane
    {

        public Kutuphane()
        {
            Uyeler = new List<IUye>(); // şu an içi boş olan uye listesi

            Kitaplar = new List<Kitap>();
        }

        public List<IUye> Uyeler { get; private set; } // Üye listesi

        public List<Kitap> Kitaplar { get; private set; } // Kitap listesi
        public object KitapDurumu { get; private set; }

        public void KitapDurumuGuncelle(Kitap kitap, Durum durum)
        {
            kitap.KitapDurumu = durum;
        }


        public void UyeKitaplariGoruntule(IUye uye)
        {
            Console.WriteLine($"{uye.Ad} {uye.Soyad}'ın ödünç aldığı kitaplar:");

            foreach (var kitap in uye.OduncKitaplar)
            {
                Console.WriteLine($" -> {kitap.Baslik}"); // detayy
            }
        }

        public void KutuphaneDurumunuGoruntule()
        {
            Console.WriteLine("Kütüphane Durumu:");

            Console.WriteLine($"Toplam Kitap Sayısı: {Kitaplar.Count}");

            int oduncAlinanKitapSayisi = Kitaplar.Count(k => k.KitapDurumu == Durum.Oduncte);

            Console.WriteLine($"Ödünç Alınan Kitap Sayısı: {oduncAlinanKitapSayisi}");

            Console.WriteLine($"Toplam Üye Sayısı: {Uyeler.Count}");
        }


        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
            Console.WriteLine($"{kitap.Baslik} adlı kitap kütüphaneye eklendi.");
        }

        public void UyeEkle(IUye uye)
        {
            Uyeler.Add(uye);
            Console.WriteLine($"{uye.Ad} {uye.Soyad} adlı üye kütüphaneye eklendi.");
        }

        public void KitaplariGoruntule()
        {
            Console.WriteLine("Kütüphanedeki Kitaplar:");
            foreach (var kitap in Kitaplar)
            {
                Console.WriteLine($"ISBN: {kitap.ISBN}, Başlık: {kitap.Baslik}, Yazar: {kitap.Yazar}, Yayın Yılı: {kitap.YayinYili}");
            }
        }

        public void UyeleriGoruntule()
        {
            Console.WriteLine("Kütüphanedeki Üyeler:");
            foreach (var uye in Uyeler)
            {
                Console.WriteLine($"Ad: {uye.Ad}, Soyad: {uye.Soyad}, Üye Numarası: {uye.UyeNo}");
            }
        }

        public void KitapOduncVer(Kitap kitap, IUye uye)
        {
            if (kitap.KitapDurumu == Durum.OduncAlinabilir)
            {
                uye.KitapOduncAl(kitap);
                kitap.KitapDurumu = Durum.Oduncte;
                Console.WriteLine($"{kitap.Baslik} adlı kitap {uye.Ad} {uye.Soyad} adlı üyeye ödünç verildi.");
            }
            else
            {
                Console.WriteLine($"{kitap.Baslik} adlı kitap şu anda ödünç alınamaz.");
            }
        }

        public void KitapIadeAl(Kitap kitap, IUye uye)
        {
            if (uye.OduncKitaplar.Contains(kitap))
            {
                uye.KitapIadeEt(kitap);
                kitap.KitapDurumu = Durum.OduncAlinabilir;
                Console.WriteLine($"{kitap.Baslik} adlı kitap {uye.Ad} {uye.Soyad} adlı üyeden iade alındo.");
        }
            else
            {
                Console.WriteLine($"{kitap.Baslik} adlı kitap zaten ödünçte değil.");
            }
        }




        //veya program.cs

        static void Main(string[] args)
        {
            Kutuphane kutuphane = new Kutuphane();

            // Kitap oluşturma

            KitapBilim kitap1 = new KitapBilim("ISBN-1234-5678", "Bilimin Kısa Tarihi", "Stephen Hawking", 2005, "ABC Yayınevi");
            KitapRoman kitap2 = new KitapRoman("ISBN-5678-9012", "Suç ve Ceza", "Fyodor Dostoyevski", 1866, "XYZ Yayınevi");
            KitapTarih kitap3 = new KitapTarih("ISBN-3456-5678", "Cumhuriyet`in İlk Yüzyılı 1923 - 2023", "İlber Ortaylı", 2021, "Kronik Kitap Yayınevi");

            // Kitapları kütüphaneye ekleme
            kutuphane.Kitaplar.Add(kitap1);
            kutuphane.Kitaplar.Add(kitap2);
            kutuphane.Kitaplar.Add(kitap3);

            // üye oluşturma
            IUye uye = new Uye("Ali", "Yılmaz", 1001);
            kutuphane.Uyeler.Add(uye);

            // Kitap ödünç alma ve iade
            uye.KitapOduncAl(kitap1);
            uye.KitapOduncAl(kitap2);
            kutuphane.KitapDurumuGuncelle(kitap1, Durum.Oduncte); // Kitap 1'i başka bir üye ödünç aldysaa
            uye.KitapIadeEt(kitap1);

            // Üyenin ödünç aldığı kitapları görüntüleme
            kutuphane.UyeKitaplariGoruntule(uye);

            // Kütüphane durumunu görüntüleme
            kutuphane.KutuphaneDurumunuGoruntule();

            Console.ReadLine();
        }
    }
}
