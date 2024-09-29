namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabaseSchema : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "Review_ReviewId", c => c.Int());
            AddColumn("dbo.Books", "Review_ReviewId", c => c.Int());
            CreateIndex("dbo.Authors", "Review_ReviewId");
            CreateIndex("dbo.Books", "Review_ReviewId");
            AddForeignKey("dbo.Authors", "Review_ReviewId", "dbo.Reviews", "ReviewId");
            AddForeignKey("dbo.Books", "Review_ReviewId", "dbo.Reviews", "ReviewId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Review_ReviewId", "dbo.Reviews");
            DropForeignKey("dbo.Authors", "Review_ReviewId", "dbo.Reviews");
            DropIndex("dbo.Books", new[] { "Review_ReviewId" });
            DropIndex("dbo.Authors", new[] { "Review_ReviewId" });
            DropColumn("dbo.Books", "Review_ReviewId");
            DropColumn("dbo.Authors", "Review_ReviewId");
        }
    }
}
