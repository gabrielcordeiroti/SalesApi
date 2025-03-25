using System;

namespace SalesApi.Domain.Entities
{
    /// <summary>
    /// Representa um item de uma venda.
    /// </summary>
    public class SaleItem
    {
        /// <summary>
        /// Identificador único do item.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Identificador do produto.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Quantidade do produto vendido.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Preço unitário do produto.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Desconto aplicado (0 para sem desconto, 0.1 para 10%, 0.2 para 20%).
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Total do item após desconto.
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Identificador da venda a que o item pertence.
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// Indica se o item foi cancelado.
        /// </summary>
        public bool IsCancelled { get; set; }
    }
}
