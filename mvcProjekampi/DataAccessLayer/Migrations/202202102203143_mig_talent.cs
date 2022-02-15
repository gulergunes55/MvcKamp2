namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_talent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Talents", "SkillArea_SkilAreaID", "dbo.SkilAreas");
            DropIndex("dbo.Talents", new[] { "SkillArea_SkilAreaID" });
            DropTable("dbo.SkilAreas");
            DropTable("dbo.Talents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Talents",
                c => new
                    {
                        SkilID = c.Int(nullable: false, identity: true),
                        SkilName = c.String(maxLength: 100),
                        SkilDetails = c.String(),
                        SkilLevel = c.Byte(nullable: false),
                        SkillAreaId = c.Int(),
                        SkillArea_SkilAreaID = c.Int(),
                    })
                .PrimaryKey(t => t.SkilID);
            
            CreateTable(
                "dbo.SkilAreas",
                c => new
                    {
                        SkilAreaID = c.Int(nullable: false, identity: true),
                        Area = c.String(maxLength: 100),
                        AreaDetails = c.String(),
                    })
                .PrimaryKey(t => t.SkilAreaID);
            
            CreateIndex("dbo.Talents", "SkillArea_SkilAreaID");
            AddForeignKey("dbo.Talents", "SkillArea_SkilAreaID", "dbo.SkilAreas", "SkilAreaID");
        }
    }
}
