namespace ControladorDePedidos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class financeiro : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Financeiro", "Divida_Codigo", "dbo.Divida");
            DropIndex("dbo.Financeiro", new[] { "Divida_Codigo" });
            AddColumn("dbo.Financeiro", "TotalCompras", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Financeiro", "TotalVendas", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Financeiro", "TotalDividas", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Financeiro", "Divida_Codigo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Financeiro", "Divida_Codigo", c => c.Int());
            DropColumn("dbo.Financeiro", "TotalDividas");
            DropColumn("dbo.Financeiro", "TotalVendas");
            DropColumn("dbo.Financeiro", "TotalCompras");
            CreateIndex("dbo.Financeiro", "Divida_Codigo");
            AddForeignKey("dbo.Financeiro", "Divida_Codigo", "dbo.Divida", "Codigo");
        }
    }
}
