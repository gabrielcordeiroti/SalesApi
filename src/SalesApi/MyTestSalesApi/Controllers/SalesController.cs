using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesApi.Infrastructure.Data;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Services;
using MyTestSalesApi.Validations;

namespace SalesApi.Controllers
{
    /// <summary>
    /// Controller para gerenciar vendas.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly SaleService _saleService;

        /// <summary>
        /// Construtor injetando o contexto e instanciando o serviço de vendas.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public SalesController(ApplicationDbContext context)
        {
            _context = context;
            _saleService = new SaleService();
        }

        /// <summary>
        /// Cria uma nova venda aplicando as regras de desconto.
        /// </summary>
        /// <param name="sale">Dados da venda.</param>
        [HttpPost]
        public IActionResult CreateSale([FromBody] Sale sale)
        {
            try
            {
                _saleService.ApplyDiscounts(sale);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { type = "BadRequest", error = "Invalid Sell", detail = ex.Message });
            }

            var validator = new SaleValidator();
            var validationResult = validator.Validate(sale);

            if (!validationResult.IsValid)
                return BadRequest(new { type = "BadRequest", error = "Invalid Sale", 
                    detail = validationResult.Errors.Select(e => e.ErrorMessage).ToList() });

            _context.Sales.Add(sale);
            _context.SaveChanges();
            // Opcional: publicar evento SaleCreated
            return Ok(new { data = sale, status = "success", message = "Venda criada com sucesso" });
        }

        /// <summary>
        /// Retorna a lista de vendas.
        /// </summary>
        [HttpGet]
        public IActionResult GetSales()
        {
            var sales = _context.Sales.Include(s => s.Items).ToList();
            return Ok(new { data = sales, status = "success", message = "Operação concluída com sucesso" });
        }

        /// <summary>
        /// Cancela uma venda a partir do seu identificador.
        /// </summary>
        /// <param name="id">Identificador da venda.</param>
        [HttpDelete("{id}")]
        public IActionResult CancelSale(Guid id)
        {
            var sale = _context.Sales.Include(s => s.Items).FirstOrDefault(s => s.Id == id);
            if (sale == null)
                return NotFound(new { type = "NotFound", error = "Sale not found", detail = "A venda informada não existe" });

            sale.Cancelled = true;
            foreach (var item in sale.Items)
                item.IsCancelled = true;

            _context.SaveChanges();
            // Opcional: publicar evento SaleCancelled
            return Ok(new { status = "success", message = "Venda cancelada com sucesso" });
        }
    }
}
