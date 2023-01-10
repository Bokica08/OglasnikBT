namespace Oglasi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Oglas", "userEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Oglas", "userEmail");
        }
    }
}
