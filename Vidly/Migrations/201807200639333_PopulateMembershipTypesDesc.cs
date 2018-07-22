namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypesDesc : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipTypeDesc = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET MembershipTypeDesc = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET MembershipTypeDesc = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET MembershipTypeDesc = 'Annual' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
