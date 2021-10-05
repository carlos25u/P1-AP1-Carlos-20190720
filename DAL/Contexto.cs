using Microsoft.EntityFrameworkCore;
using P1_AP1_Carlos_20190720.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_AP1_Carlos_20190720.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Aportes> Aportes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"data source = DATA\Aportes.db");
        }
    }
}
