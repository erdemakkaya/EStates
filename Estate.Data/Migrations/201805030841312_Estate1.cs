namespace Estate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Estate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryFeature",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Category_Id = c.Int(),
                        Feature_Id = c.Int(),
                        PropertyFeature_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .ForeignKey("dbo.Feature", t => t.Feature_Id)
                .ForeignKey("dbo.PropertyFeature", t => t.PropertyFeature_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Feature_Id)
                .Index(t => t.PropertyFeature_Id);
            
            CreateTable(
                "dbo.Feature",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeatureName = c.String(),
                        Value = c.String(),
                        IsValid = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Mail = c.String(nullable: false),
                        Pw = c.String(),
                        UserType = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GeoLocation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lat = c.Double(nullable: false),
                        Long = c.Double(nullable: false),
                        Zoom = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Adress = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Property_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Property", t => t.Property_Id)
                .Index(t => t.Property_Id);
            
            CreateTable(
                "dbo.Property",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Title = c.String(),
                        ShortDescription = c.String(),
                        Description = c.String(),
                        Area = c.Single(nullable: false),
                        City = c.String(),
                        District = c.String(),
                        TypeOfProperty = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        Discount = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Category_Id = c.Int(),
                        User_Id = c.Int(),
                        PropertyFeature_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .ForeignKey("dbo.PropertyFeature", t => t.PropertyFeature_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.User_Id)
                .Index(t => t.PropertyFeature_Id);
            
            CreateTable(
                "dbo.PropertyFeature",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Property", "PropertyFeature_Id", "dbo.PropertyFeature");
            DropForeignKey("dbo.CategoryFeature", "PropertyFeature_Id", "dbo.PropertyFeature");
            DropForeignKey("dbo.Photo", "Property_Id", "dbo.Property");
            DropForeignKey("dbo.Property", "User_Id", "dbo.User");
            DropForeignKey("dbo.Property", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.CategoryFeature", "Feature_Id", "dbo.Feature");
            DropForeignKey("dbo.CategoryFeature", "Category_Id", "dbo.Category");
            DropIndex("dbo.Property", new[] { "PropertyFeature_Id" });
            DropIndex("dbo.Property", new[] { "User_Id" });
            DropIndex("dbo.Property", new[] { "Category_Id" });
            DropIndex("dbo.Photo", new[] { "Property_Id" });
            DropIndex("dbo.CategoryFeature", new[] { "PropertyFeature_Id" });
            DropIndex("dbo.CategoryFeature", new[] { "Feature_Id" });
            DropIndex("dbo.CategoryFeature", new[] { "Category_Id" });
            DropTable("dbo.PropertyFeature");
            DropTable("dbo.Property");
            DropTable("dbo.Photo");
            DropTable("dbo.GeoLocation");
            DropTable("dbo.User");
            DropTable("dbo.Feature");
            DropTable("dbo.CategoryFeature");
            DropTable("dbo.Category");
        }
    }
}
