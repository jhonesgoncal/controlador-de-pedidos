﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControladorDePedidos.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ControladorDePedidos.Repositorio
{
    public class Contexto : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            base.OnModelCreating(modelBuilder);
        }

        public Contexto() : base("DefaultConnection") { }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<ItemDaCompra> ItemDaCompra { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<ItemDaVenda> ItemDaVenda { get; set; }
        public DbSet<Fornecedor> fornecedor { get; set; }
        public DbSet<Divida> divida { get; set; }
        public DbSet<Financeiro> financeiro { get; set; }
    }

}
