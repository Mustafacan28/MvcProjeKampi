namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my_about : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutMes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MyName = c.String(maxLength: 30),
                        MyLastName = c.String(maxLength: 30),
                        MyUniversity = c.String(maxLength: 30),
                        propertyone = c.String(maxLength: 30),
                        propertytwo = c.String(maxLength: 30),
                        propertythree = c.String(maxLength: 30),
                        propertyfour = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AboutMes");
        }
    }
}
