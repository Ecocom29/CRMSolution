using CRM.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain
{
    public class Review: BaseDomainModel
    {
        [Column(TypeName = "NVARCHAR(150)")]
        public string? ReviewBy { get; set; }
        public int Rating { get; set; }
        [Column(TypeName = "NVARCHAR(4000)")]
        public string? Comments { get; set; }
        public int ProductId { get; set; }
    }
}
