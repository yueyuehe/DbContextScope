namespace TaoBao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        GoodsNumber = c.String(),
                        Name = c.String(),
                        ImageUrl = c.String(),
                        DescriptionUrl = c.String(),
                        Category = c.String(),
                        TaoBaoKe = c.String(),
                        TaoBaoKeShortUrl = c.String(),
                        TaoBaoToken = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesVolume = c.Int(nullable: false),
                        CommissionRatio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Commission = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SaleMan = c.String(),
                        SaleManID = c.String(),
                        ShopName = c.String(),
                        ShopType = c.String(),
                        TicketId = c.String(),
                        TicketTotalNum = c.Int(nullable: false),
                        TicketNum = c.Int(nullable: false),
                        TicketDescription = c.String(),
                        TicketPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        TicketUrl = c.String(),
                        TicketPutUrl = c.String(),
                        TicketPutShortUrl = c.String(),
                        TicketPutToken = c.String(),
                        GoodsType = c.String(),
                        UpdateTime = c.DateTime(nullable: false),
                        DownDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Goods");
        }
    }
}
