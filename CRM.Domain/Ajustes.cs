using CRM.Domain.Common;

namespace CRM.Domain
{
    public class Ajustes: BaseDomainModel
    {
        public string? Recurso { get; set; }
        public string? Propiedad { get; set; }
        public string? Valor { get; set; }
    }
}
