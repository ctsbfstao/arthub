namespace ArtHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExhibitDataModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exhibits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(maxLength: 255),
                        Type = c.String(),
                        Image = c.String(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Exhibits");
        }
    }
}
