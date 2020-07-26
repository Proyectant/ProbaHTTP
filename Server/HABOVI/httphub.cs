using Microsoft.AspNetCore.SignalR;
using ProbaHTTP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProbaHTTP.Server.HABOVI
{
    public class httphub : Hub
    {
        public async Task UbaciOsobu(Osoba o)
        {
            Console.WriteLine("usao u dodavanje osobe");
            Baza bazanaserveru = new Baza();
            bazanaserveru.Osobas.Add(o);
            Console.WriteLine("dodao osobu");
            await bazanaserveru.SaveChangesAsync();
            Console.WriteLine("baza sacuvala");
        }

    }
}
