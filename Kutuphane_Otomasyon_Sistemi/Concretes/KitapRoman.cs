using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyon_Sistemi.Concretes
{
    internal class KitapRoman : Kitap
    {
        public KitapRoman(string isbn, string baslik, string yazar, int yayinYili, string yayinevi)
        : base(isbn, baslik, yazar, yayinYili, yayinevi)
        {
        }
    }
}
