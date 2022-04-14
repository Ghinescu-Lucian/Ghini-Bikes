using Domain.Models;

namespace Application
{
    public interface IImageRepository
    {
        void CreateImage(Image image);
        IEnumerable<Image> GetImages();
        Image DeleteImage(int imageId);
        Image GetImageById(int imageId);
        IEnumerable<Image> GetImagesByProductId(int productId);
        Image UpdateImage(int imageId, Image image);
    }
}
