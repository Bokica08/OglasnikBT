namespace Oglasi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Oglas", "ime", c => c.String(nullable: false));
            AddColumn("dbo.Oglas", "telefon", c => c.String(nullable: false));
            AlterColumn("dbo.Oglas", "Boja", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Oglas", "Boja", c => c.String());
            DropColumn("dbo.Oglas", "telefon");
            DropColumn("dbo.Oglas", "ime");
        }
    }
}
