namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reviewVoteTableUpdatedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReviewVotes", "UpdatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReviewVotes", "UpdatedDate");
        }
    }
}
