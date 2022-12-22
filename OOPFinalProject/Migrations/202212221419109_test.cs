namespace OOPFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ISBN = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Auther = c.String(),
                        DatePrint = c.DateTime(nullable: false),
                        Copies = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        Stock = c.Int(nullable: false),
                        Catgory = c.Int(nullable: false),
                        CatgoryJournal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ISBN);
            
            CreateTable(
                "dbo.Journals",
                c => new
                    {
                        ISBN = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Auther = c.String(),
                        DatePrint = c.DateTime(nullable: false),
                        Copies = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        Stock = c.Int(nullable: false),
                        Catgory = c.Int(nullable: false),
                        CatgoryJournal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ISBN);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Journals");
            DropTable("dbo.Books");
        }
    }
}
