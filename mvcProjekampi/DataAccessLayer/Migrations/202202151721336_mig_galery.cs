namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_galery : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageFiles", "ImagePath", c => c.String(maxLength: 400));
            DropColumn("dbo.ImageFiles", "ImagePffath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImageFiles", "ImagePffath", c => c.String(maxLength: 400));
            DropColumn("dbo.ImageFiles", "ImagePath");
        }
    }
}
