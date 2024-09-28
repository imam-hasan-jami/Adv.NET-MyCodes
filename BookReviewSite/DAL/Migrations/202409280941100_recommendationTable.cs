namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recommendationTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recommendations", "UpdatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recommendations", "UpdatedDate");
        }
    }
}
