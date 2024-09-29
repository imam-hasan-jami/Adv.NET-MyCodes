namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDBSchema : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Review_ReviewId", c => c.Int());
            CreateIndex("dbo.Users", "Review_ReviewId");
            AddForeignKey("dbo.Users", "Review_ReviewId", "dbo.Reviews", "ReviewId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Review_ReviewId", "dbo.Reviews");
            DropIndex("dbo.Users", new[] { "Review_ReviewId" });
            DropColumn("dbo.Users", "Review_ReviewId");
        }
    }
}
