using Microsoft.EntityFrameworkCore;
using ProyectoFinal_23cv.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_23cv.Context
{
    public  class AplicationdbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("server = localhost; database= proyectofin; user = root; password=");
        }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
