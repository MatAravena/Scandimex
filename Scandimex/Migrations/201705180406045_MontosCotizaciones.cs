namespace Scandimex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MontosCotizaciones : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cotizaciones", "MontoCotizacion", c => c.Double(nullable: false));
            AddColumn("dbo.Cotizaciones", "MontoComprado", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cotizaciones", "MontoComprado");
            DropColumn("dbo.Cotizaciones", "MontoCotizacion");
        }
    }
}
