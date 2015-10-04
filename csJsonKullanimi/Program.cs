using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System;

namespace csJsonKullanimi
{
    public class Ogrenciler
    {
        public string isim { get; set; }
    }

    public class UniversiteOgrencileri
    {
        public string universite { get; set; }
        public IList<Ogrenciler> ogrenciler { get; set; }
    }

    public class StreamClass
    {
        public bool success { get; set; }
        public string lowest_price { get; set; }
        public string volume { get; set; }
        public string median_price { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //{\"universite\":\"Mersin\",\"ogrenciler\":[{\"isim\":\"Şafak\"},{\"isim\":\"Dilara\"},{\"isim\":\"Can\"}]}
            JsonCreate();

            JsonRead();
        }

        private static void JsonCreate()
        {
            //{\"universite\":\"Mersin\",\"ogrenciler\":[{\"isim\":\"Şafak\"},{\"isim\":\"Dilara\"},{\"isim\":\"Can\"}]}
            UniversiteOgrencileri universiteOgrencileri = new UniversiteOgrencileri();
            universiteOgrencileri.universite = "Mersin";

            List<Ogrenciler> p = new List<Ogrenciler>();
            Ogrenciler ogrenci1 = new Ogrenciler { isim = "Şafak" };
            Ogrenciler ogrenci2 = new Ogrenciler { isim = "Dilara" };
            Ogrenciler ogrenci3 = new Ogrenciler { isim = "Can" };

            p.Add(ogrenci1);
            p.Add(ogrenci2);
            p.Add(ogrenci3);
            universiteOgrencileri.ogrenciler = p;
            string json = JsonConvert.SerializeObject(universiteOgrencileri);
            System.Console.WriteLine(json);
        }
        private static void JsonRead()
        {
            //{\"universite\":\"Mersin\",\"ogrenciler\":[{\"isim\":\"Şafak\"},{\"isim\":\"Dilara\"},{\"isim\":\"Can\"}]}
            string url = @"http://www.exampleweb.com/example.json";
            string jsonVerisi = "";
            using (WebClient response = new WebClient())
            {
                jsonVerisi = response.DownloadString(url);
            }
            UniversiteOgrencileri account = JsonConvert.DeserializeObject<UniversiteOgrencileri>(jsonVerisi);

            foreach (var ogrenci in account.ogrenciler)
            {
                System.Console.WriteLine(ogrenci.ToString());
            }
        }
    }
}