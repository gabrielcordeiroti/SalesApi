using System;
using System.Linq;
using SalesApi.Domain.Entities;

namespace SalesApi.Domain.Services
{
    /// <summary>
    /// Serviço responsável por aplicar regras de negócio nas vendas.
    /// </summary>
    public class SaleService
    {
        /// <summary>
        /// Aplica os descontos e valida as regras de negócio para uma venda.
        /// </summary>
        /// <param name="sale">A venda a ser processada.</param>
        /// <exception cref="InvalidOperationException">Lançada quando a quantidade de um item excede 20.</exception>
        public void ApplyDiscounts(Sale sale)
        {
            foreach (var item in sale.Items)
            {
                if (item.Quantity > 20)
                    throw new InvalidOperationException("Você não pode comprar mais de 20 peças do mesmo item");

                if (item.Quantity >= 10)
                    item.Discount = 0.2m;
                else if (item.Quantity >= 4)
                    item.Discount = 0.1m;
                else
                    item.Discount = 0m;

                item.Total = (item.UnitPrice * item.Quantity) - (item.UnitPrice * item.Quantity * item.Discount);
            }
            sale.TotalAmount = sale.Items.Sum(i => i.Total);
            sale.Cancelled = false;
        }
    }
}
