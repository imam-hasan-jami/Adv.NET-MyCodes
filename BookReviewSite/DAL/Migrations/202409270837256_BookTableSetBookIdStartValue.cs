namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookTableSetBookIdStartValue : DbMigration
    {
        public override void Up()
        {
            Sql("DBCC CHECKIDENT ('Books', RESEED, 1100)");
        }
        
        public override void Down()
        {
        }
    }
}
