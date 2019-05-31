namespace WPFandEOF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Computers");
            DropColumn("dbo.Computers", "Id");
            AddColumn("dbo.Computers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Computers", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Computers");
            AlterColumn("dbo.Computers", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Computers", "Id");
        }
    }
}
