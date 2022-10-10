namespace _2011064226_PhamAnhHao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialEmployer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 100),
                        email = c.String(),
                        phone = c.String(),
                        image = c.String(maxLength: 196),
                        birth = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employers");
        }
    }
}
