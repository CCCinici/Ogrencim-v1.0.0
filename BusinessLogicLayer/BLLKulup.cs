using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using FacadeLayer;

namespace BusinessLogicLayer
{
    public class BLLKulup
    {
        public static int Ekle(EntityKulup deger)
        {
            if (deger.KulupAdi != null)
            {
                return FacadeKulup.Ekle(deger);
            }
            return -1;
        }
        public static bool Guncelle(EntityKulup deger)
        {
            if (deger.KulupAdi != null && deger.KuluplerID != null && deger.Mevcut != null)
            {
                return FacadeKulup.Guncelle(deger);
            }
            return false;
        }
        public static bool Sil(int deger)
        {
            if (deger != null)
            {
                return FacadeKulup.Sil(deger);
            }
            return false;
        }
        public static List<EntityKulup> Listele()
        {
            return FacadeKulup.Listele();
        }
    }
}
