namespace WPFandEOF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Computers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.String(),
                        RamSize = c.Int(nullable: false),
                        ProcessorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Processors", t => t.ProcessorId)
                .Index(t => t.ProcessorId);
            
            CreateTable(
                "dbo.Processors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        MaxFrequency = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Computers", "ProcessorId", "dbo.Processors");
            DropIndex("dbo.Computers", new[] { "ProcessorId" });
            DropTable("dbo.Processors");
            DropTable("dbo.Computers");
        }
    }
}
