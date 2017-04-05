namespace SampleWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Validation_For_User_Fields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 20));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 20));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String());
        }
    }
}
