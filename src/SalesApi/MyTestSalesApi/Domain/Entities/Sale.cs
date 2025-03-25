namespace SalesApi.Domain.Entities
{
    /// <summary>
    /// Representa uma venda.
    /// </summary>
    public class Sale
    {
        /// <summary>
        /// Identificador único da venda.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Número da venda.
        /// </summary>
        public string SaleNumber { get; set; }

        /// <summary>
        /// Data da venda.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Identificador do cliente.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Identificador da filial.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Valor total da venda (com descontos aplicados).
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Indica se a venda foi cancelada.
        /// </summary>
        public bool Cancelled { get; set; }

        /// <summary>
        /// Lista de itens da venda.
        /// </summary>
        public List<SaleItem> Items { get; set; } = new();
    }
}
