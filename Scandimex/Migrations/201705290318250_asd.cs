namespace Scandimex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cotizaciones", "CiudadCodigo", "dbo.Ciudads");
            DropIndex("dbo.Cotizaciones", new[] { "CiudadCodigo" });
            AlterColumn("dbo.Cotizaciones", "CiudadCodigo", c => c.Int(nullable: false));
            CreateIndex("dbo.Cotizaciones", "CiudadCodigo");
            AddForeignKey("dbo.Cotizaciones", "CiudadCodigo", "dbo.Ciudads", "CiudadCodigo", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cotizaciones", "CiudadCodigo", "dbo.Ciudads");
            DropIndex("dbo.Cotizaciones", new[] { "CiudadCodigo" });
            AlterColumn("dbo.Cotizaciones", "CiudadCodigo", c => c.Int());
            CreateIndex("dbo.Cotizaciones", "CiudadCodigo");
            AddForeignKey("dbo.Cotizaciones", "CiudadCodigo", "dbo.Ciudads", "CiudadCodigo");
        }
    }
}
