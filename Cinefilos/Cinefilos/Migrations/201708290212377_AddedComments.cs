namespace Cinefilos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedComments : DbMigration
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
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Filmes", "Comentario_ID", c => c.Int());
            CreateIndex("dbo.Filmes", "Comentario_ID");
            AddForeignKey("dbo.Filmes", "Comentario_ID", "dbo.Comentarios", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Filmes", "Comentario_ID", "dbo.Comentarios");
            DropIndex("dbo.Filmes", new[] { "Comentario_ID" });
            DropColumn("dbo.Filmes", "Comentario_ID");
            DropTable("dbo.Comentarios");
        }
    }
}
