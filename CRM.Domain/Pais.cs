using CRM.Domain.Common;

namespace CRM.Domain
{
    public class Pais: BaseDomainModel
    {
        public string? NombrePais { get; set; }
        public string? Iso2 { get; set; }
        public string? Iso3 { get; set; }
    }
}
