namespace Cinefilos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateTimeToComentario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Texto = c.String(),
                        Email = c.String(),
                        Date = c.DateTime(nullable: false),
                        Filme_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Filmes", t => t.Filme_ID)
                .Index(t => t.Filme_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentarios", "Filme_ID", "dbo.Filmes");
            DropIndex("dbo.Comentarios", new[] { "Filme_ID" });
            DropTable("dbo.Comentarios");
        }
    }
}
