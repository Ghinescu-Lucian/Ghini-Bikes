using Application;
using Domain.Models;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ShopDbContext _db;

        public ImageRepository(ShopDbContext db) { _db = db; }
        public void CreateImage(Image image)
        {
            _db.Images.Add(image);
            _db.SaveChanges();
        }

        public Image DeleteImage(int imageId)
        {
            var imageDelete = GetImageById(imageId);
            if (imageDelete == null) return null;
            _db.Images.Remove(imageDelete);
            _db.SaveChanges();
            return imageDelete;
        }

        public Image GetImageById(int imageId)
        {
            var image = _db.Images.SingleOrDefault(image => image.Id == imageId);
            return image;
        }

        public IEnumerable<Image> GetImages()
        {
            return _db.Images;
        }

        public IEnumerable<Image> GetImagesByProductId(int productId)
        {
             var images = _db.Images.Where(image => image.ProductId == productId);
            return images;
        }

        public Image UpdateImage(int imageId, Image image)
        {
            var imageUpdate = GetImageById(imageId);
            imageUpdate.Path = image.Path;
            imageUpdate.ProductId=image.ProductId;
            //  _db.Users.Remove(userUpdate);
            _db.SaveChanges();
            return imageUpdate;
        }
    }
}
