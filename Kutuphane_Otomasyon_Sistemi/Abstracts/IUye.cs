using Kutuphane_Otomasyon_Sistemi.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyon_Sistemi.Abstracts
{
    internal interface IUye
    {
        //event HaberTipi KutuphaneBenGeldim;

        public long UyeNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        List<Kitap> OduncKitaplar { get; set; }

        void KitapOduncAl(Kitap kitap);
        void KitapIadeEt(Kitap kitap);


    }


}
