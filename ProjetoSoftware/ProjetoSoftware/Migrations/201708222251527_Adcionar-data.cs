namespace ProjetoSoftware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adcionardata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        DataCricao = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.IdCliente);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clientes");
        }
    }
}
