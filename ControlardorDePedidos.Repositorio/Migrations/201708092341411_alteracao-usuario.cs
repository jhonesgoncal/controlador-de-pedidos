namespace ControladorDePedidos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracaousuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "Financeiro", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Financeiro");
        }
    }
}
