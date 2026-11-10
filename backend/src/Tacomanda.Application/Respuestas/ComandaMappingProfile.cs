using AutoMapper;
using Tacomanda.Domain.Comandas;
using Tacomanda.Domain.Mesas;
using Tacomanda.Domain.Platillos;
using Tacomanda.Application.ConsultarMesas;
using Tacomanda.Application.ConsultarPlatillo;

namespace Tacomanda.Application.Respuestas;

public sealed class ComandaMappingProfile : Profile
{
    public ComandaMappingProfile()
    {
        CreateMap<DetalleComanda, DetalleComandaDto>();
        CreateMap<Comanda, ComandaDto>();
        CreateMap<Mesa, MesaDto>();
        CreateMap<Platillo, PlatilloDto>();
    }
}
