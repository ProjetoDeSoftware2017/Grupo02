namespace ProjetoSoftware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LongitueADd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Longitudes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Longiteude = c.String(unicode: false),
                        Latitude = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Longitudes");
        }
    }
}
