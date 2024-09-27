namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetAuthorIdStartValue : DbMigration
    {
        public override void Up()
        {
            Sql("DBCC CHECKIDENT ('Authors', RESEED, 100)");
        }
        
        public override void Down()
        {
        }
    }
}
