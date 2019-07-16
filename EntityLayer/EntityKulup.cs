using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityKulup
    {
        int _KuluplerID;
        string _KulupAdi;
        int _Mevcut;

        public int KuluplerID { get => _KuluplerID; set => _KuluplerID = value; }
        public string KulupAdi { get => _KulupAdi; set => _KulupAdi = value; }
        public int Mevcut { get => _Mevcut; set => _Mevcut = value; }
    }
}
