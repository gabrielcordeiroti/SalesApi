using System;

namespace SalesApi.Domain.Entities
{
    /// <summary>
    /// Representa um produto.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Identificador único do produto.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Título do produto.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Preço do produto.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Descrição do produto.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Categoria do produto.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// URL da imagem do produto.
        /// </summary>
        public string Image { get; set; }
    }
}
