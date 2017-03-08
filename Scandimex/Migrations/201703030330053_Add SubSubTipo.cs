namespace Scandimex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubSubTipo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CotizacionProductoes", "SubProductoCodigo", c => c.Int(nullable: false));
            CreateIndex("dbo.CotizacionProductoes", "SubProductoCodigo");
            AddForeignKey("dbo.CotizacionProductoes", "SubProductoCodigo", "dbo.TipoProductoSubs", "SubProductoCodigo", cascadeDelete: true);
            DropColumn("dbo.CotizacionProductoes", "Categoría");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CotizacionProductoes", "Categoría", c => c.String(nullable: false, maxLength: 70));
            DropForeignKey("dbo.CotizacionProductoes", "SubProductoCodigo", "dbo.TipoProductoSubs");
            DropIndex("dbo.CotizacionProductoes", new[] { "SubProductoCodigo" });
            DropColumn("dbo.CotizacionProductoes", "SubProductoCodigo");
        }
    }
}
