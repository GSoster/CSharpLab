namespace Cinefilos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNota : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Filmes", "NotaTemp", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Filmes", "NotaTemp");
        }
    }
}
