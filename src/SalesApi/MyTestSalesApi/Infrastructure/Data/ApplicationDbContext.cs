using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using SalesApi.Domain.Entities;

namespace SalesApi.Infrastructure.Data
{
    /// <summary>
    /// Contexto de dados utilizado pelo Entity Framework Core.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Construtor que utiliza as opções de configuração.
        /// </summary>
        /// <param name="options">Opções do contexto.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        /// <summary>
        /// Conjunto de produtos.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Conjunto de vendas.
        /// </summary>
        public DbSet<Sale> Sales { get; set; }

        /// <summary>
        /// Conjunto de itens de venda.
        /// </summary>
        public DbSet<SaleItem> SaleItems { get; set; }

        /// <summary>
        /// Configuração dos modelos.
        /// </summary>
        /// <param name="modelBuilder">Construtor do modelo.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
