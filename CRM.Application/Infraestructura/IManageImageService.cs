using CRM.Application.Modelos.ImagenManagement;

namespace CRM.Application.Infraestructura
{
    public interface IManageImageService
    {
        Task<ImageResponse> UploadImage(ImageData imageStream);
    }
}
