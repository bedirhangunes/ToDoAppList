namespace ToDoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigrationName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        IsDone = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TodoTeams", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TodoTeams", new[] { "User_Id" });
            DropTable("dbo.TodoTeams");
        }
    }
}
