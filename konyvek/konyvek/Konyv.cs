using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvek
{
    class Konyv
    {
        public int id { get; set; }
        public string szerzo { get; set; }
        public string cim { get; set; }
        public string ev { get; set; }
        public string kiado { get; set; }
        public bool elerhetoseg { get; set; }
        public Konyv(string sor)
        {
            string[] resz = sor.Split(';');
            id = Convert.ToInt32(resz[0]);
            szerzo = resz[1];
            cim = resz[2];
            ev = resz[3];
            kiado = resz[4];
            elerhetoseg = Convert.ToBoolean(resz[5]);
        }
    }

    class Olvaso
    {
        public string olvasoID { get; set; }
        public string nev { get; set; }
        public string szulDatum { get; set; }
        public string irSzam { get; set; }
        public string telepules { get; set; }
        public string utcaHsz { get; set; }
        public Olvaso(string sor)
        {
            string[] resz = sor.Split(';');
            olvasoID = resz[0];
            nev = resz[1];
            szulDatum = resz[2];
            irSzam = resz[3];
            telepules = resz[4];
            utcaHsz = resz[5];
        }
    }
    class Kolcsonzes
    {
        public string kolcsonzesID { get; set; }
        public string olvasoID { get; set; }
        public int konyvID { get; set; }
        public string kezdet { get; set; }
        public string veg { get; set; }
        public Kolcsonzes(string sor)
        {

            string[] resz = sor.Split(';');
            kolcsonzesID = resz[0];
            olvasoID = resz[1];
            konyvID = Convert.ToInt32(resz[2]);
            kezdet = resz[3];
            veg = resz[4];

        }
    }
}
