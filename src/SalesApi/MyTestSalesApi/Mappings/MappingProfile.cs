using AutoMapper;
using SalesApi.Domain.Entities;

namespace SalesApi.Mappings
{
    /// <summary>
    /// Perfil de mapeamento para o AutoMapper.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Configuração dos mapeamentos.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Product, Product>();
            CreateMap<Sale, Sale>();
            CreateMap<SaleItem, SaleItem>();
        }
    }
}
