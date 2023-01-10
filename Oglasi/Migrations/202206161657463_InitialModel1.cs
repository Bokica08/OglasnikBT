namespace Oglasi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Oglas", "Marka", c => c.String(nullable: false));
            AlterColumn("dbo.Oglas", "Model", c => c.String(nullable: false));
            AlterColumn("dbo.Oglas", "Nasolv", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Oglas", "Nasolv", c => c.String());
            AlterColumn("dbo.Oglas", "Model", c => c.String());
            AlterColumn("dbo.Oglas", "Marka", c => c.String());
        }
    }
}
