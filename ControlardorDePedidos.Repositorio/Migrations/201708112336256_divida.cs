namespace ControladorDePedidos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class divida : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Divida",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        ValorDaDivida = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Situacao = c.Int(nullable: false),
                        DataDeVencimento = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Financeiro",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Divida_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Divida", t => t.Divida_Codigo)
                .Index(t => t.Divida_Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Financeiro", "Divida_Codigo", "dbo.Divida");
            DropIndex("dbo.Financeiro", new[] { "Divida_Codigo" });
            DropTable("dbo.Financeiro");
            DropTable("dbo.Divida");
        }
    }
}
