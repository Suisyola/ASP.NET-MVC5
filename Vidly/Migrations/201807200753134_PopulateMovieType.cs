namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieTypes (Name) VALUES ('Comedy')");
            Sql("INSERT INTO MovieTypes (Name) VALUES ('Action')");
            Sql("INSERT INTO MovieTypes (Name) VALUES ('Family')");
            Sql("INSERT INTO MovieTypes (Name) VALUES ('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
