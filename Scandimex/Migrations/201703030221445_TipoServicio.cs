namespace Scandimex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class TipoServicio : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cotizaciones", "CiudadCodigo", "dbo.Ciudads");
            DropForeignKey("dbo.Cotizaciones", "IdCliente", "dbo.Clientes");
            DropIndex("dbo.Cotizaciones", new[] { "IdCliente" });
            DropIndex("dbo.Cotizaciones", new[] { "CiudadCodigo" });

            CreateTable(
                "dbo.TipoServicios",
                c => new
                    {
                        TipoServicioCodigo = c.Int(nullable: false, identity: true),
                        NombreTipoServicio = c.String(nullable: false, maxLength: 70),
                    })
                .PrimaryKey(t => t.TipoServicioCodigo);

            AddColumn("dbo.Cotizaciones", "PlazoEntregaDesde", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cotizaciones", "PlazoEntregaHasta", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Cotizaciones", "IdCliente", c => c.Int(nullable: false));
            AlterColumn("dbo.Cotizaciones", "CiudadCodigo", c => c.Int());
            CreateIndex("dbo.Cotizaciones", "IdCliente");
            CreateIndex("dbo.Cotizaciones", "CiudadCodigo");
            AddForeignKey("dbo.Cotizaciones", "CiudadCodigo", "dbo.Ciudads", "CiudadCodigo");
            AddForeignKey("dbo.Cotizaciones", "IdCliente", "dbo.Clientes", "IdCliente", cascadeDelete: true);
            DropColumn("dbo.Cotizaciones", "PlazoEntrega");


            Sql(" INSERT INTO [Scandimex].[dbo].[TipoServicios] ([NombreTipoServicio]) VALUES ('SERVICIOS DE INGENIERÍA (DIVISIÓN PROYECTOS')  ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoServicios] ([NombreTipoServicio]) VALUES ('ASESORÍAS EN INSTRUMENTACIÓN INDUSTRIAL')  ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoServicios] ([NombreTipoServicio]) VALUES ('DESARROLLO DE PROYECTOS DE INSTRUMENTACIÓN')  ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoServicios] ([NombreTipoServicio]) VALUES ('EVALUACIÓN DE SISTEMAS DE CONTROL DE PROCESOS')  ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoServicios] ([NombreTipoServicio]) VALUES ('MIGRACIÓN Y MODERNIZACIÓN DE SISTEMAS DE CONTROL')  ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoServicios] ([NombreTipoServicio]) VALUES ('DESARROLLO DE PROYECTOS ELÉCTRICOS')  ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoServicios] ([NombreTipoServicio]) VALUES ('MEDICIONES GEOELÉCTRICAS')  ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoServicios] ([NombreTipoServicio]) VALUES ('DISEÑO, CÁLCULO Y MEDICIÓN DE MALLAS DE PUESTA A TIERRA')  ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoServicios] ([NombreTipoServicio]) VALUES ('DESARROLLO DE PROYECTOS DE REDES COMPUTACIONALES')  ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoServicios] ([NombreTipoServicio]) VALUES ('INSTALACIÓN, CABLEADO Y CERTIFICACIÓN DE REDES')  ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoServicios] ([NombreTipoServicio]) VALUES ('PROYECTOS FOTOVOLTAICOS')  ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoServicios] ([NombreTipoServicio]) VALUES ('PROYECTOS EÓLICOS')  ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoServicios] ([NombreTipoServicio]) VALUES ('PROYECTOS TERMOSOLARES')  ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoServicios] ([NombreTipoServicio]) VALUES ('LEVANTAMIENTOS, CONSTRUCCIÓN DE PLANOS AS-BUILD')  ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoServicios] ([NombreTipoServicio]) VALUES ('DIAGNÓSTICOS, MEDICIONES, AUDITORÍAS TÉCNICAS')  ", true);

        }

        public override void Down()
        {
            AddColumn("dbo.Cotizaciones", "PlazoEntrega", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Cotizaciones", "IdCliente", "dbo.Clientes");
            DropForeignKey("dbo.Cotizaciones", "CiudadCodigo", "dbo.Ciudads");
            DropIndex("dbo.Cotizaciones", new[] { "CiudadCodigo" });
            DropIndex("dbo.Cotizaciones", new[] { "IdCliente" });
            AlterColumn("dbo.Cotizaciones", "CiudadCodigo", c => c.Int(nullable: false));
            AlterColumn("dbo.Cotizaciones", "IdCliente", c => c.Int());
            DropColumn("dbo.Cotizaciones", "PlazoEntregaHasta");
            DropColumn("dbo.Cotizaciones", "PlazoEntregaDesde");
            DropTable("dbo.TipoServicios");
            CreateIndex("dbo.Cotizaciones", "CiudadCodigo");
            CreateIndex("dbo.Cotizaciones", "IdCliente");
            AddForeignKey("dbo.Cotizaciones", "IdCliente", "dbo.Clientes", "IdCliente");
            AddForeignKey("dbo.Cotizaciones", "CiudadCodigo", "dbo.Ciudads", "CiudadCodigo", cascadeDelete: true);
        }
    }
}
