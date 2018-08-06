namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3b28a850-4eaf-4c8f-b929-0a383581b3a4', N'abc@def.com', 0, N'AJ/kAo9GmeWYHCorWeHJrT1ses1GjKXsGUQCtCjGnqXucc8cd8Qr+HqnZIFTerSbcA==', N'a032083f-5df0-478d-b404-f43d9f3f840a', NULL, 0, 0, NULL, 1, 0, N'abc@def.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'514b2c1a-f8ab-42a3-b17b-f64aa3f6084c', N'admin@def.com', 0, N'AEpeJanNV7lG1NW0XCkCfaBwTHxzsq3t4CrXCQnz8w6I4mfoQSyCSkGm9yy8IqqgiA==', N'ffdcc9b0-fd22-444c-9a1a-4e99e9aa2aa7', NULL, 0, 0, NULL, 1, 0, N'admin@def.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1c7358d1-ce5d-4ce3-92f9-ad4c47de2027', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'514b2c1a-f8ab-42a3-b17b-f64aa3f6084c', N'1c7358d1-ce5d-4ce3-92f9-ad4c47de2027')
");
        }
        
        public override void Down()
        {
        }
    }
}
