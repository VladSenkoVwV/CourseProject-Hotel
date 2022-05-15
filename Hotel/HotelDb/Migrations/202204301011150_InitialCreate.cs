namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        data1 = c.Int(nullable: false),
                        data2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.data1, t.data2 }, unique: true, name: "UK");
            
        }
        
        public override void Down()
        {
            //this.CreateIndex("dbo.Clients", "data1", unique)
        }
    }
}
