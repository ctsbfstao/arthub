namespace ArtHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExhibitForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exhibits", "Type_Id", "dbo.ExhibitTypes");
            DropIndex("dbo.Exhibits", new[] { "Type_Id" });
            RenameColumn(table: "dbo.Exhibits", name: "Type_Id", newName: "TypeId");
            AlterColumn("dbo.Exhibits", "TypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Exhibits", "TypeId");
            AddForeignKey("dbo.Exhibits", "TypeId", "dbo.ExhibitTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exhibits", "TypeId", "dbo.ExhibitTypes");
            DropIndex("dbo.Exhibits", new[] { "TypeId" });
            AlterColumn("dbo.Exhibits", "TypeId", c => c.Byte());
            RenameColumn(table: "dbo.Exhibits", name: "TypeId", newName: "Type_Id");
            CreateIndex("dbo.Exhibits", "Type_Id");
            AddForeignKey("dbo.Exhibits", "Type_Id", "dbo.ExhibitTypes", "Id");
        }
    }
}
