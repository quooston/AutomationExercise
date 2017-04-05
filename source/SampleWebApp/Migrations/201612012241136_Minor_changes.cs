namespace SampleWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Minor_changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 30));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 20));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 20));
        }
    }
}
