namespace Scandimex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValuefieldsCotizaciones : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CotizacionProductoes", "ValorFinal", c => c.Double(nullable: false));
            AddColumn("dbo.CotizacionServicios", "ValorFinal", c => c.Double(nullable: false));
            AlterColumn("dbo.CotizacionProductoes", "ValorUnitario", c => c.Double(nullable: false));
            AlterColumn("dbo.CotizacionProductoes", "Cantidad", c => c.Double(nullable: false));
            AlterColumn("dbo.CotizacionServicios", "HorasServicio", c => c.Double(nullable: false));
            AlterColumn("dbo.CotizacionServicios", "ValorHora", c => c.Double(nullable: false));
            DropColumn("dbo.CotizacionProductoes", "Valor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CotizacionProductoes", "Valor", c => c.Int(nullable: false));
            AlterColumn("dbo.CotizacionServicios", "ValorHora", c => c.Int(nullable: false));
            AlterColumn("dbo.CotizacionServicios", "HorasServicio", c => c.Int(nullable: false));
            AlterColumn("dbo.CotizacionProductoes", "Cantidad", c => c.Int(nullable: false));
            AlterColumn("dbo.CotizacionProductoes", "ValorUnitario", c => c.Int(nullable: false));
            DropColumn("dbo.CotizacionServicios", "ValorFinal");
            DropColumn("dbo.CotizacionProductoes", "ValorFinal");
        }
    }
}
