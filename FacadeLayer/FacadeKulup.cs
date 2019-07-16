using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace FacadeLayer
{
    public class FacadeKulup
    {
        public static int Ekle(EntityKulup deger)
        {
            SqlCommand komut = new SqlCommand("sp_KulupEkle",SQLBaglanti.baglanti);
            komut.CommandType = CommandType.StoredProcedure;

            if (komut.Connection.State!=ConnectionState.Open)
            {
                //komutun bağlantı durumu açık değilse
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("KulupAdi", deger.KulupAdi);
            komut.Parameters.AddWithValue("Mevcut",deger.Mevcut);
            //ExecuteNonQuery zaten silme işlemi kadar sayı döndürdüğünden başarılı olup olmadığını int ile tutabiliriz.
            return komut.ExecuteNonQuery();
        }

        public static bool Sil(int deger)
        {
            SqlCommand komut = new SqlCommand("sp_KulupSil",SQLBaglanti.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("KuluplerID",deger);
            //Yani komut.execute 0dan büyükmü geliyor küçük mü, büyük geliyorsa çalışır, gelmiyorsa bişey döndürmez.
            return komut.ExecuteNonQuery() > 0;
        }

        public static bool Guncelle(EntityKulup deger)
        {
            SqlCommand komut = new SqlCommand("sp_KulupGuncelle",SQLBaglanti.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("KuluplerID",deger.KuluplerID);
            komut.Parameters.AddWithValue("Ad", deger.KulupAdi);
            komut.Parameters.AddWithValue("Mevcut",deger.Mevcut);
            return komut.ExecuteNonQuery() > 0;
        }
        public static List<EntityKulup> Listele()
        {
            List<EntityKulup> degerler = new List<EntityKulup>();
            SqlCommand komut = new SqlCommand("sp_KulupListesi",SQLBaglanti.baglanti);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                EntityKulup klp = new EntityKulup();
                klp.KuluplerID = Convert.ToInt32(dr["KuluplerID"]);
                klp.KulupAdi = dr["KulupAdi"].ToString();
                klp.Mevcut = Convert.ToInt32(dr["Mevcut"]);
                degerler.Add(klp);
            }
            dr.Close();
            return degerler;
        }
    }
}
