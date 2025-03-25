using Microsoft.AspNetCore.Mvc;
using MyTestSalesApi.Validations;
using SalesApi.Domain.Entities;
using SalesApi.Events;
using SalesApi.Infrastructure.Data;

namespace MyTestSalesApi.Controllers
{
    /// <summary>
    /// Controller para gerenciar produtos.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEventPublisher _eventPublisher;

        /// <summary>
        /// Construtor que injeta o contexto do banco de dados e o publicador de eventos.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        /// <param name="eventPublisher">Implementação de IEventPublisher.</param>
        public ProductsController(ApplicationDbContext context, IEventPublisher eventPublisher)
        {
            _context = context;
            _eventPublisher = eventPublisher;
        }

        /// <summary>
        /// Cria um novo produto e publica um evento de criação.
        /// </summary>
        /// <param name="product">Dados do produto a ser criado.</param>
        /// <returns>Produto criado com confirmação.</returns>
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            var validator = new ProductValidator();
            var validationResult = validator.Validate(product);

            if (!validationResult.IsValid)
            {
                return BadRequest(new { type = "BadRequest", error = "Invalid Product", 
                    detail = validationResult.Errors.Select(e => e.ErrorMessage).ToList() });
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            // Publica um evento "ProductCreated" com os dados do produto
            _eventPublisher.Publish("ProductCreated", product);

            return Ok(new { data = product, status = "success", message = "Operação concluída com sucesso" });
        }

        /// <summary>
        /// Retorna a lista de produtos cadastrados.
        /// </summary>
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _context.Products.ToList();
            return Ok(new { data = products, status = "success", message = "Operação concluída com sucesso" });
        }
    }
}
