namespace ArtHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExhibitTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExhibitTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Exhibits", "Type_Id", c => c.Byte());
            CreateIndex("dbo.Exhibits", "Type_Id");
            AddForeignKey("dbo.Exhibits", "Type_Id", "dbo.ExhibitTypes", "Id");
            DropColumn("dbo.Exhibits", "Type");

            Sql("INSERT INTO ExhibitTypes (Id, Name) VALUES (1, 'Watercolor')");
            Sql("INSERT INTO ExhibitTypes (Id, Name) VALUES (2, 'OilOnCanvas')");
            Sql("INSERT INTO ExhibitTypes (Id, Name) VALUES (3, 'WildlifePhotography')");
            Sql("INSERT INTO ExhibitTypes (Id, Name) VALUES (4, 'Antiques')");

        }

        public override void Down()
        {
            AddColumn("dbo.Exhibits", "Type", c => c.String());
            DropForeignKey("dbo.Exhibits", "Type_Id", "dbo.ExhibitTypes");
            DropIndex("dbo.Exhibits", new[] { "Type_Id" });
            DropColumn("dbo.Exhibits", "Type_Id");
            DropTable("dbo.ExhibitTypes");

            Sql("DELETE FROM ExhibitTypes WHERE Id IN (1, 2, 3, 4)");
        }
    }
}
