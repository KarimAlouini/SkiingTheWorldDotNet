namespace domaine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class last : DbMigration
    {
        public override void Up()
        {
            
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        Reference = c.Int(nullable: false),
                        MarquecategorieProd = c.Int(nullable: false),
                        Description = c.String(maxLength: 255, storeType: "nvarchar"),
                        Marque = c.String(maxLength: 255, storeType: "nvarchar"),
                        Modele = c.String(maxLength: 255, storeType: "nvarchar"),
                        Name = c.String(maxLength: 255, storeType: "nvarchar"),
                        Photo = c.String(maxLength: 255, storeType: "nvarchar"),
                        Quantity = c.Int(nullable: false),
                        Color = c.String(unicode: false),
                        Size = c.String(unicode: false),
                        price = c.Double(nullable: false),
                        sousCategorieProdId = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Reference)
                .ForeignKey("dbo.souscategories", t => t.sousCategorieProdId, cascadeDelete: true)
                .Index(t => t.sousCategorieProdId);
            
            
            
        }
        
        public override void Down()
        {
        }
    }
}
