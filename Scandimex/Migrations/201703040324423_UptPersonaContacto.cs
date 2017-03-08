namespace Scandimex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptPersonaContacto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonaContactoes", "IdCliente", "dbo.Clientes");
            DropIndex("dbo.PersonaContactoes", new[] { "IdCliente" });
            AlterColumn("dbo.PersonaContactoes", "IdCliente", c => c.Int(nullable: false));
            CreateIndex("dbo.PersonaContactoes", "IdCliente");
            AddForeignKey("dbo.PersonaContactoes", "IdCliente", "dbo.Clientes", "IdCliente", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonaContactoes", "IdCliente", "dbo.Clientes");
            DropIndex("dbo.PersonaContactoes", new[] { "IdCliente" });
            AlterColumn("dbo.PersonaContactoes", "IdCliente", c => c.Int());
            CreateIndex("dbo.PersonaContactoes", "IdCliente");
            AddForeignKey("dbo.PersonaContactoes", "IdCliente", "dbo.Clientes", "IdCliente");
        }
    }
}
