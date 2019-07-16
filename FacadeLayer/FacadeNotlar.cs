using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EntityLayer;

namespace FacadeLayer
{
    public class FacadeNotlar
    {
        public static bool Guncelle(EntityNotlar deger)
        {
            SqlCommand komut = new SqlCommand("sp_NotGuncelle",SQLBaglanti.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("OgrenciID",deger.OgrenciID);
            komut.Parameters.AddWithValue("Sinav1",deger.Sinav1);
            komut.Parameters.AddWithValue("Sinav2", deger.Sinav2);
            komut.Parameters.AddWithValue("Sinav3", deger.Sinav3);
            komut.Parameters.AddWithValue("Proje", deger.Proje);
            komut.Parameters.AddWithValue("Ortalama", deger.Ortalama);
            komut.Parameters.AddWithValue("Durum", deger.Durum);
            return komut.ExecuteNonQuery() > 0;
        }

        public static List<EntityNotlar> Listele()
        {
            List<EntityNotlar> degerler = new List<EntityNotlar>();
            SqlCommand komut = new SqlCommand("sp_NotListele",SQLBaglanti.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                EntityNotlar not = new EntityNotlar();
                not.OgrenciID = Convert.ToInt32(dr["OgrenciID"]);
                not.Ad = dr["Ad"].ToString();
                not.Soyad = dr["Soyad"].ToString();
                not.Sinav1 = Convert.ToInt32(dr["Sinav1"]);
                not.Sinav2 = Convert.ToInt32(dr["Sinav2"]);
                not.Sinav3 = Convert.ToInt32(dr["Sinav3"]);
                not.Proje = Convert.ToInt32(dr["Proje"]);
                not.Ortalama = Convert.ToDouble(dr["Ortalama"]);
                not.Durum = dr["Durum"].ToString();
                degerler.Add(not);
            }
            dr.Close();
            return degerler;


        } 
    }
}
