namespace domaine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categorie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.souscategories", "MarquecategorieProd", c => c.Int(nullable: false));
            DropColumn("dbo.products", "MarquecategorieProd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.products", "MarquecategorieProd", c => c.Int(nullable: false));
            DropColumn("dbo.souscategories", "MarquecategorieProd");
        }
    }
}
