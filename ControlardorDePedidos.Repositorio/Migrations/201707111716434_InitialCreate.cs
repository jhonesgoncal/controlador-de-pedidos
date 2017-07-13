namespace ControladorDePedidos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        ValorDeCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorDeVenda = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantidadeEmEstoque = c.Int(nullable: false),
                        QuantidadeMinimaEmEstoque = c.Int(nullable: false),
                        QuantidadeDesejavelEmEstoque = c.Int(nullable: false),
                        Marca_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Marcas", t => t.Marca_Codigo)
                .Index(t => t.Marca_Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "Marca_Codigo", "dbo.Marcas");
            DropIndex("dbo.Produtoes", new[] { "Marca_Codigo" });
            DropTable("dbo.Produtoes");
            DropTable("dbo.Marcas");
        }
    }
}
