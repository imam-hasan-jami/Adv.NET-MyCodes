namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Bio = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorId)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        PublishDate = c.DateTime(nullable: false),
                        Genre = c.String(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Recommendations",
                c => new
                    {
                        RecommendationId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 10, unicode: false),
                        BookId = c.Int(nullable: false),
                        IsRecommended = c.Boolean(nullable: false),
                        RecommendationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecommendationId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Username, cascadeDelete: true)
                .Index(t => t.Username)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 10, unicode: false),
                        Password = c.String(nullable: false, maxLength: 10, unicode: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Name = c.String(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.Username)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 10, unicode: false),
                        BookId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        ReviewText = c.String(nullable: false),
                        ReviewDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Username, cascadeDelete: true)
                .Index(t => t.Username)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.ReviewVotes",
                c => new
                    {
                        ReviewVoteId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 10, unicode: false),
                        ReviewId = c.Int(nullable: false),
                        IsUpvote = c.Boolean(nullable: false),
                        VoteDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewVoteId)
                .ForeignKey("dbo.Reviews", t => t.ReviewId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Username, cascadeDelete: false)
                .Index(t => t.Username)
                .Index(t => t.ReviewId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReviewVotes", "Username", "dbo.Users");
            DropForeignKey("dbo.ReviewVotes", "ReviewId", "dbo.Reviews");
            DropForeignKey("dbo.Reviews", "Username", "dbo.Users");
            DropForeignKey("dbo.Reviews", "BookId", "dbo.Books");
            DropForeignKey("dbo.Recommendations", "Username", "dbo.Users");
            DropForeignKey("dbo.Recommendations", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.ReviewVotes", new[] { "ReviewId" });
            DropIndex("dbo.ReviewVotes", new[] { "Username" });
            DropIndex("dbo.Reviews", new[] { "BookId" });
            DropIndex("dbo.Reviews", new[] { "Username" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Recommendations", new[] { "BookId" });
            DropIndex("dbo.Recommendations", new[] { "Username" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropIndex("dbo.Authors", new[] { "Email" });
            DropTable("dbo.ReviewVotes");
            DropTable("dbo.Reviews");
            DropTable("dbo.Users");
            DropTable("dbo.Recommendations");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
