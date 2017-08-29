namespace ProjetoSoftware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Naufragos",
                c => new
                    {
                        IdNaufrago = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, unicode: false),
                        Estado = c.String(nullable: false, unicode: false),
                        DataOcorrido = c.DateTime(nullable: false, precision: 0),
                        Pais = c.String(nullable: false, unicode: false),
                        Local = c.String(unicode: false),
                        Motivo = c.String(unicode: false),
                        Obs = c.String(unicode: false),
                        Latitude = c.String(unicode: false),
                        Longitude = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.IdNaufrago);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Naufragos");
        }
    }
}
