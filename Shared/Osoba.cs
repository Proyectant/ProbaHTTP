using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace ProbaHTTP.Shared
{
    public class Osoba
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public Osoba() { }
        public Osoba(string i, string p)
        {
            Ime = i;
            Prezime = p;
        }

        public override string ToString()
        {
            return $"{Ime} - {Prezime} ";
        }
    }



}
