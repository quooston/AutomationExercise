namespace XXX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Regex_Adjusted_For_FirstName_And_LastName : DbMigration
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
