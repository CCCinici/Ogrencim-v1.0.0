using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityOgrenci
    {
        int _OgrencilerID;
        string _Ad;
        string _Soyad;
        string _Fotograf;
        int _KulupID;
        int _Mezun;

        public int OgrencilerID { get => _OgrencilerID; set => _OgrencilerID = value; }
        public string Ad { get => _Ad; set => _Ad = value; }
        public string Soyad { get => _Soyad; set => _Soyad = value; }
        public string Fotograf { get => _Fotograf; set => _Fotograf = value; }
        public int KulupID { get => _KulupID; set => _KulupID = value; }
        public int Mezun { get => _Mezun; set => _Mezun = value; }
    }
}
