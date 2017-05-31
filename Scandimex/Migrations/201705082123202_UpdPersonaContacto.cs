namespace Scandimex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdPersonaContacto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonaContactoes", "PhoneExtra", c => c.String());
            AddColumn("dbo.PersonaContactoes", "Email2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonaContactoes", "Email2");
            DropColumn("dbo.PersonaContactoes", "PhoneExtra");
        }
    }
}
