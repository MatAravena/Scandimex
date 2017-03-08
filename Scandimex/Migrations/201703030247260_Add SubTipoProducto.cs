namespace Scandimex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubTipoProducto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoProductoSubs",
                c => new
                    {
                        SubProductoCodigo = c.Int(nullable: false, identity: true),
                        NombreSubCategoria = c.String(nullable: false, maxLength: 70),
                        TipoProductoCodigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubProductoCodigo)
                .ForeignKey("dbo.TipoProductos", t => t.TipoProductoCodigo, cascadeDelete: true)
                .Index(t => t.TipoProductoCodigo);
            
            AddColumn("dbo.CotizacionServicios", "TipoServicioCodigo", c => c.Int(nullable: false));
            CreateIndex("dbo.CotizacionServicios", "TipoServicioCodigo");
            AddForeignKey("dbo.CotizacionServicios", "TipoServicioCodigo", "dbo.TipoServicios", "TipoServicioCodigo", cascadeDelete: true);
            DropColumn("dbo.CotizacionServicios", "Categoría");

            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Transmisores' ,1) ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Indicadores' ,1) ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Medidores' ,1) ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Sensores' ,1) ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Switches' ,1) ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Válvulas' ,1) ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Flujo' ,1) ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Presión' ,1) ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Temperatura' ,1) ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Nivel' ,1) ", true);

            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Aerogeneradores' ,2) ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Paneles fotovoltaicos' ,2) ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Paneles termosolares' ,2) ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Reguladores de carga' ,2) ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Inversores' ,2) ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Bombas solares' ,2) ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Baterías' ,2) ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Luminarias de nueva tecnología' ,2) ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Postes solares' ,2) ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Postes eólicos' ,2) ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Postes combinados' ,2) ", true);
            Sql(" INSERT INTO [Scandimex].[dbo].[TipoProductoSubs] ([NombreSubCategoria] ,[TipoProductoCodigo]) VALUES ('Proyectos e instalaciones' ,2) ", true);

        }
        
        public override void Down()
        {
            AddColumn("dbo.CotizacionServicios", "Categoría", c => c.String(nullable: false, maxLength: 70));
            DropForeignKey("dbo.TipoProductoSubs", "TipoProductoCodigo", "dbo.TipoProductos");
            DropForeignKey("dbo.CotizacionServicios", "TipoServicioCodigo", "dbo.TipoServicios");
            DropIndex("dbo.TipoProductoSubs", new[] { "TipoProductoCodigo" });
            DropIndex("dbo.CotizacionServicios", new[] { "TipoServicioCodigo" });
            DropColumn("dbo.CotizacionServicios", "TipoServicioCodigo");
            DropTable("dbo.TipoProductoSubs");
        }
    }
}
