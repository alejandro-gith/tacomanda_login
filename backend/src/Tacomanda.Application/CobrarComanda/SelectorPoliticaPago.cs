using Tacomanda.Application.Validacion;
using Tacomanda.Domain.Pagos;

namespace Tacomanda.Application.CobrarComanda;

public sealed class SelectorPoliticaPago
{
    private readonly IEnumerable<IPoliticaDePago> _politicas;
    public SelectorPoliticaPago(IEnumerable<IPoliticaDePago> politicas) { _politicas = politicas; }
    public IPoliticaDePago Elegir(string forma) => _politicas.FirstOrDefault(p => p.Forma == forma)
        ?? throw new ValidacionException("Forma de pago inválida.");
}
