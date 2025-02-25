using System.Runtime.Serialization;

namespace CRM.Domain
{
    public enum ProductoStatus
    {
        [EnumMember(Value = "Producto Inactivo")]
        Inactive,
        [EnumMember(Value = "Producto Activo")]
        Active
    }
}
