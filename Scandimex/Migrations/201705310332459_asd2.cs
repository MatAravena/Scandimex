namespace Scandimex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cotizaciones", "MontoCotizacion", c => c.Double());
            AlterColumn("dbo.Cotizaciones", "MontoComprado", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cotizaciones", "MontoComprado", c => c.Double(nullable: false));
            AlterColumn("dbo.Cotizaciones", "MontoCotizacion", c => c.Double(nullable: false));
        }
    }
}
