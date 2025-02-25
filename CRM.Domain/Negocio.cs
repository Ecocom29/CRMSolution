using CRM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
    public class Negocio :  BaseDomainModel
    {
        public string? UrlLogo { get; set; }
        public string? NombreNegocio { get; set; }
        public string? RazonSocial { get; set; }
        public string? RFC { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Pais { get; set; }
        public string? Estado { get; set; }
        public string? Colonia { get; set; }
        public string? NombreReponsable { get; set; }
        public string? URLWeb { get; set; }
        public string? URLMapa { get; set; }
        public bool? Status { get; set; } = true;
        public decimal? PorcetanjeImpuesto { get; set; }
        public string? TipoMoneda { get; set; }
    }
}
