namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieTypeIdInMovieModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Movies", name: "MovieType_Id", newName: "MovieTypeId");
            RenameIndex(table: "dbo.Movies", name: "IX_MovieType_Id", newName: "IX_MovieTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Movies", name: "IX_MovieTypeId", newName: "IX_MovieType_Id");
            RenameColumn(table: "dbo.Movies", name: "MovieTypeId", newName: "MovieType_Id");
        }
    }
}
