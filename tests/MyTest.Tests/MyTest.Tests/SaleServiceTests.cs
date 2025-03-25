using SalesApi.Domain.Entities;
using SalesApi.Domain.Services;

namespace MyTest.Tests
{
    /// <summary>
    /// Testes para a aplicação de descontos na venda.
    /// </summary>
    public class SaleServiceTests
    {
        /// <summary>
        /// Testa se os descontos são aplicados corretamente de acordo com a quantidade.
        /// </summary>
        /// <param name="quantity">Quantidade do item.</param>
        /// <param name="expectedDiscount">Desconto esperado.</param>
        [Theory]
        [InlineData(3, 0)]
        [InlineData(4, 0.1)]
        [InlineData(10, 0.2)]
        public void ApplyDiscounts_AppliesCorrectDiscount(int quantity, decimal expectedDiscount)
        {
            // Arrange
            var sale = new Sale
            {
                Items = new List<SaleItem>
                {
                    new SaleItem { ProductId = Guid.NewGuid(), Quantity = quantity, UnitPrice = 100 }
                }
            };
            var service = new SaleService();

            // Act
            service.ApplyDiscounts(sale);
            var item = sale.Items[0];

            // Assert
            Assert.Equal(expectedDiscount, item.Discount);
            var expectedTotal = (100 * quantity) - (100 * quantity * expectedDiscount);
            Assert.Equal(expectedTotal, item.Total);
        }

        /// <summary>
        /// Testa se uma exceção é lançada quando a quantidade é maior que 20.
        /// </summary>
        [Fact]
        public void ApplyDiscounts_ThrowsWhenQuantityAbove20()
        {
            // Arrange
            var sale = new Sale
            {
                Items = new List<SaleItem>
                {
                    new SaleItem { ProductId = Guid.NewGuid(), Quantity = 21, UnitPrice = 100 }
                }
            };
            var service = new SaleService();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => service.ApplyDiscounts(sale));
        }
    }
}
