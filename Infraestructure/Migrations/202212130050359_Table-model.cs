namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tablemodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        lastName = c.String(),
                        cellPhone = c.Int(nullable: false),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.ClientID);
            
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        ReceiptID = c.Int(nullable: false, identity: true),
                        Total = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        PayOff = c.Boolean(nullable: false),
                        Client_ClientID = c.Int(),
                    })
                .PrimaryKey(t => t.ReceiptID)
                .ForeignKey("dbo.Clients", t => t.Client_ClientID)
                .Index(t => t.Client_ClientID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        SellPrice = c.Double(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        ExpirationDate = c.String(),
                        IGV = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.Productv2",
                c => new
                    {
                        Productv2ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Productv2ID);
            
            CreateTable(
                "dbo.ReceiptDetails",
                c => new
                    {
                        ReceiptDetailsID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        ReceiptID = c.Int(nullable: false),
                        Productv2ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReceiptDetailsID)
                .ForeignKey("dbo.Productv2", t => t.Productv2ID, cascadeDelete: true)
                .ForeignKey("dbo.Receipts", t => t.ReceiptID, cascadeDelete: true)
                .Index(t => t.ReceiptID)
                .Index(t => t.Productv2ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceiptDetails", "ReceiptID", "dbo.Receipts");
            DropForeignKey("dbo.ReceiptDetails", "Productv2ID", "dbo.Productv2");
            DropForeignKey("dbo.Receipts", "Client_ClientID", "dbo.Clients");
            DropIndex("dbo.ReceiptDetails", new[] { "Productv2ID" });
            DropIndex("dbo.ReceiptDetails", new[] { "ReceiptID" });
            DropIndex("dbo.Receipts", new[] { "Client_ClientID" });
            DropTable("dbo.ReceiptDetails");
            DropTable("dbo.Productv2");
            DropTable("dbo.Products");
            DropTable("dbo.Receipts");
            DropTable("dbo.Clients");
        }
    }
}
