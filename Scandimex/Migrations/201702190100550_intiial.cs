namespace Scandimex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class intiial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ciudads",
                c => new
                    {
                        CiudadCodigo = c.Int(nullable: false, identity: true),
                        CiudadNombre = c.String(nullable: false, maxLength: 70),
                        PaisAbreviacion = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.CiudadCodigo)
                .ForeignKey("dbo.Pais", t => t.PaisAbreviacion, true)
                .Index(t => t.PaisAbreviacion);

            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        PaisAbreviacion = c.String(nullable: false, maxLength: 3),
                        PaisNombre = c.String(nullable: false, maxLength: 50),
                        PaisOrden = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaisAbreviacion);

            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        NombreCompañia = c.String(nullable: false, maxLength: 70),
                        Rut = c.String(),
                        Direccion = c.String(),
                        CódigoPostal = c.Int(),
                        LandLinePhone = c.String(),
                        PhoneMovil = c.String(),
                        Fax = c.String(),
                        PaisAbreviacion = c.String(maxLength: 3),
                        CiudadCodigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCliente)
                .ForeignKey("dbo.Ciudads", t => t.CiudadCodigo, false)
                .ForeignKey("dbo.Pais", t => t.PaisAbreviacion, false)
                .Index(t => t.PaisAbreviacion)
                .Index(t => t.CiudadCodigo);

            CreateTable(
                "dbo.PersonaContactoes",
                c => new
                    {
                        PersonaContactoId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 70),
                        LastName = c.String(),
                        Position = c.String(),
                        LandLinePhone = c.String(),
                        PhoneMovil = c.String(),
                        Email = c.String(),
                        IdCliente = c.Int(),
                    })
                .PrimaryKey(t => t.PersonaContactoId)
                .ForeignKey("dbo.Clientes", t => t.IdCliente, false)
                .Index(t => t.IdCliente);

            CreateTable(
                "dbo.Cotizaciones",
                c => new
                    {
                        CotizacionId = c.Int(nullable: false, identity: true),
                        CodigoInterno = c.String(nullable: false),
                        FechaCotizacion = c.DateTime(nullable: false),
                        IdCliente = c.Int(),
                        Requerido = c.String(),
                        Descripcion = c.String(),
                        PlazoEntrega = c.DateTime(nullable: false),
                        Garantia = c.String(maxLength: 500),
                        CondicionesPago = c.String(maxLength: 500),
                        PaisAbreviacion = c.String(maxLength: 3),
                        CiudadCodigo = c.Int(nullable: false),
                        Direccion = c.String(maxLength: 500),
                        Validez = c.String(maxLength: 50),
                        Aceptacion = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CotizacionId)
                .ForeignKey("dbo.Ciudads", t => t.CiudadCodigo, false)
                .ForeignKey("dbo.Clientes", t => t.IdCliente, false)
                .ForeignKey("dbo.Pais", t => t.PaisAbreviacion, false)
                .Index(t => t.IdCliente)
                .Index(t => t.PaisAbreviacion)
                .Index(t => t.CiudadCodigo);

            CreateTable(
                "dbo.CotizacionProductoes",
                c => new
                    {
                        CotProdId = c.Int(nullable: false, identity: true),
                        CotizacionId = c.Int(nullable: false),
                        TipoProductoCodigo = c.Int(nullable: false),
                        Categoría = c.String(nullable: false, maxLength: 70),
                        SubCategoría = c.String(nullable: false, maxLength: 70),
                        Descripcion = c.String(nullable: false),
                        ValorUnitario = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Valor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CotProdId)
                .ForeignKey("dbo.Cotizaciones", t => t.CotizacionId, true)
                .ForeignKey("dbo.TipoProductos", t => t.TipoProductoCodigo, false)
                .Index(t => t.CotizacionId)
                .Index(t => t.TipoProductoCodigo);

            CreateTable(
                "dbo.TipoProductos",
                c => new
                    {
                        TipoProductoCodigo = c.Int(nullable: false, identity: true),
                        NombreTipoProducto = c.String(nullable: false, maxLength: 70),
                    })
                .PrimaryKey(t => t.TipoProductoCodigo);

            CreateTable(
                "dbo.CotizacionServicios",
                c => new
                    {
                        CotServId = c.Int(nullable: false, identity: true),
                        CotizacionId = c.Int(nullable: false),
                        Categoría = c.String(nullable: false, maxLength: 70),
                        SubCategoría = c.String(nullable: false, maxLength: 70),
                        Descripcion = c.String(nullable: false),
                        HorasServicio = c.Int(nullable: false),
                        ValorHora = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CotServId)
                .ForeignKey("dbo.Cotizaciones", t => t.CotizacionId, true)
                .Index(t => t.CotizacionId);

            CreateTable(
                "dbo.TiposClientes",
                c => new
                    {
                        IDTipoCliente = c.Int(nullable: false, identity: true),
                        NombreCategoría = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDTipoCliente);

            CreateTable(
                "dbo.TipoPagoes",
                c => new
                    {
                        TipoPagoId = c.Int(nullable: false, identity: true),
                        TipoPAgo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TipoPagoId);


            Sql(" INSERT INTO [Scandimex].[dbo].[Pais]([PaisAbreviacion],[PaisNombre],[PaisOrden]) VALUES ('FR', 'France',2)	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Pais]([PaisAbreviacion],[PaisNombre],[PaisOrden]) VALUES ('DE', 'Germany',2)	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Pais]([PaisAbreviacion],[PaisNombre],[PaisOrden]) VALUES ('SE', 'Sweden',2)	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Pais]([PaisAbreviacion],[PaisNombre],[PaisOrden]) VALUES ('ES', 'Spain',2)	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Pais]([PaisAbreviacion],[PaisNombre],[PaisOrden]) VALUES ('GB', 'United Kingdom',2)	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Pais]([PaisAbreviacion],[PaisNombre],[PaisOrden]) VALUES ('NL', 'Netherlands',2)	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Pais]([PaisAbreviacion],[PaisNombre],[PaisOrden]) VALUES ('BE', 'Belgium',2)	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Pais]([PaisAbreviacion],[PaisNombre],[PaisOrden]) VALUES ('DK', 'Denmark',2)	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Pais]([PaisAbreviacion],[PaisNombre],[PaisOrden]) VALUES ('NO', 'Norway',2)	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Pais]([PaisAbreviacion],[PaisNombre],[PaisOrden]) VALUES ('AR', 'Argentina',2)	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Pais]([PaisAbreviacion],[PaisNombre],[PaisOrden]) VALUES ('PE', 'Peru',2)	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Pais]([PaisAbreviacion],[PaisNombre],[PaisOrden]) VALUES ('CO', 'Colombia',2)	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Pais]([PaisAbreviacion],[PaisNombre],[PaisOrden]) VALUES ('VE', 'Venezuela',2)	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Pais]([PaisAbreviacion],[PaisNombre],[PaisOrden]) VALUES ('CL', 'Chile',1)	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Pais]([PaisAbreviacion],[PaisNombre],[PaisOrden]) VALUES ('EC', 'Ecuador',2)	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Pais]([PaisAbreviacion],[PaisNombre],[PaisOrden]) VALUES ('BO', 'Bolivia',2)	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Pais]([PaisAbreviacion],[PaisNombre],[PaisOrden]) VALUES ('UY', 'Uruguay',2)	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Pais]([PaisAbreviacion],[PaisNombre],[PaisOrden]) VALUES ('PY', 'Paraguay',2)	", true);

            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('FR', 'Paris')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('DE', 'Berlin')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('NO', 'Oslo')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('SE', 'Stockholm')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('ES', 'Barcelona')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('ES', 'Madrid')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('GB', 'London')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('NL', 'Amsterdam')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('BE', 'Brussels')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('DK', 'Copenhagen')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('AR', 'Buenos Aires')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('PE', 'Lima')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('BO', 'La Paz')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('CO', 'Bogotá')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('VE', 'Caracas')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('CL', 'Santiago')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('CL', 'Arica')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('CL', 'Antofagasta')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('CL', 'Iquique')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('CL', 'Copiapo')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('CL', 'La Serena')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('CL', 'Valparaiso')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('CL', 'Viña del Mar')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('CL', 'Temuco')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('CL', 'Punta Arenas')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('CL', 'Valdivia')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('CL', 'Ancud')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('CL', 'Coyhaique')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('CL', 'Concepcion')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('EC', 'Quito')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('UY', 'Ciudad De Montevideo')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[Ciudads] ([PaisAbreviacion],[CiudadNombre]) VALUES ('PY', 'Asunción')	", true);


            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductos] ([NombreTipoProducto]) VALUES ('Instrumentación Industrial')	", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductos] ([NombreTipoProducto]) VALUES ('Energía Renovable')	", true);

        }

        public override void Down()
        {
            DropForeignKey("dbo.CotizacionServicios", "CotizacionId", "dbo.Cotizaciones");
            DropForeignKey("dbo.CotizacionProductoes", "TipoProductoCodigo", "dbo.TipoProductos");
            DropForeignKey("dbo.CotizacionProductoes", "CotizacionId", "dbo.Cotizaciones");
            DropForeignKey("dbo.Cotizaciones", "PaisAbreviacion", "dbo.Pais");
            DropForeignKey("dbo.Cotizaciones", "IdCliente", "dbo.Clientes");
            DropForeignKey("dbo.Cotizaciones", "CiudadCodigo", "dbo.Ciudads");
            DropForeignKey("dbo.Clientes", "PaisAbreviacion", "dbo.Pais");
            DropForeignKey("dbo.PersonaContactoes", "IdCliente", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "CiudadCodigo", "dbo.Ciudads");
            DropForeignKey("dbo.Ciudads", "PaisAbreviacion", "dbo.Pais");
            DropIndex("dbo.CotizacionServicios", new[] { "CotizacionId" });
            DropIndex("dbo.CotizacionProductoes", new[] { "TipoProductoCodigo" });
            DropIndex("dbo.CotizacionProductoes", new[] { "CotizacionId" });
            DropIndex("dbo.Cotizaciones", new[] { "CiudadCodigo" });
            DropIndex("dbo.Cotizaciones", new[] { "PaisAbreviacion" });
            DropIndex("dbo.Cotizaciones", new[] { "IdCliente" });
            DropIndex("dbo.PersonaContactoes", new[] { "IdCliente" });
            DropIndex("dbo.Clientes", new[] { "CiudadCodigo" });
            DropIndex("dbo.Clientes", new[] { "PaisAbreviacion" });
            DropIndex("dbo.Ciudads", new[] { "PaisAbreviacion" });
            DropTable("dbo.TipoPagoes");
            DropTable("dbo.TiposClientes");
            DropTable("dbo.CotizacionServicios");
            DropTable("dbo.TipoProductos");
            DropTable("dbo.CotizacionProductoes");
            DropTable("dbo.Cotizaciones");
            DropTable("dbo.PersonaContactoes");
            DropTable("dbo.Clientes");
            DropTable("dbo.Pais");
            DropTable("dbo.Ciudads");
        }
    }
}
