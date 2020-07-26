using Microsoft.EntityFrameworkCore;
using ProbaHTTP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProbaHTTP.Server
{
    public class Baza : DbContext
    {

        public Microsoft.EntityFrameworkCore.DbSet<Osoba> Osobas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Osoba>().HasKey(o => o.ID);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-KUN7BOB;Initial Catalog=aaaaa;Integrated Security=True;Connect Timeout=30;
                                                Encrypt=False;TrustServerCertificate=False;
                                            ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }


    }
}
