using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacadeLayer;
using EntityLayer;

namespace BusinessLogicLayer
{
    public class BLLOgrenci
    {
        public static int Ekle(EntityOgrenci deger)
        {
            if (deger.Ad != null && deger.Soyad != null && deger.KulupID > 0 && deger.Fotograf !=null && deger.KulupID > 0)
            {
                return FacadeOgrenci.Ekle(deger);
            }
            return -1;
        }
        public static bool Guncelle(EntityOgrenci deger)
        {
            if (deger.Ad != null && deger.Soyad != null && deger.KulupID > 0 && deger.Fotograf != null && deger.KulupID > 0 && deger.OgrencilerID > 0)
            {
                return FacadeOgrenci.Guncelle(deger);
            }
            return false;
        }
        public static bool Sil(int deger)
        {
            if (deger > 0 && deger > 1)
            {
                return FacadeOgrenci.Sil(deger);
            }
            return false;
        }
        public static List<EntityOgrenci> Listele()
        {
            return FacadeOgrenci.Listele();
        }
    }
}
