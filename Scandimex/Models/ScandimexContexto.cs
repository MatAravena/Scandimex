using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Scandimex.Migrations;

namespace Scandimex.Models
{
    public class ScandimexContexto : DbContext
    {
        public ScandimexContexto()
        {
            Database.SetInitializer<ScandimexContexto>
                (new MigrateDatabaseToLatestVersion<ScandimexContexto, Scandimex.Migrations.Configuration>());
        }

        public DbSet<Pais> Paises { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<PersonaContacto> PersonasContactos { get; set; }
        public DbSet<Cotizaciones> Cotizacion { get; set; }
        public DbSet<CotizacionServicio> CotizacionServicio { get; set; }
        public DbSet<CotizacionProducto> CotizacionProducto { get; set; }
        public DbSet<TiposCliente> TipoClientes { get; set; }
        public DbSet<TipoPago> TipoPago { get; set; }
        public DbSet<TipoProductos> TipoProducto { get; set; }
        public DbSet<TipoServicio> TipoServicio { get; set; }
        public DbSet<TipoProductoSub> TipoProductoSub { get; set; }
        



    }
}