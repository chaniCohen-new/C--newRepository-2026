using c__nRepository_2026.Interfaces;
using c__nRepository_2026.Entities;
using System.Collections.Generic;
using System.Linq;

namespace c__nRepository_2026.Repositories
{
    public class ImageRepository : IRepository<Image>
    {
        private readonly IContext context;
        public ImageRepository(IContext context) { this.context = context; }

        public Image AddItem(Image item) { context.Images.Add(item); context.SaveChanges(); return item; }
        public void DeleteItem(int id) { var image = Get(id); if (image != null) { context.Images.Remove(image); context.SaveChanges(); } }
        public Image Get(int id) { return context.Images.FirstOrDefault(i => i.Id == id); }
        public List<Image> GetAll() { return context.Images.ToList(); }
        public void UpdateItem(int id, Image item) { var image = Get(id); if (image != null) { image.Url = item.Url; image.GalleryId = item.GalleryId; context.Images.Update(image); context.SaveChanges(); } }

        public List<Image> GetImagesByGalleryId(int galleryId) { return context.Images.Where(i => i.GalleryId == galleryId).ToList(); }
        public List<Image> GetImagesByUserId(int userId) { return context.Images.Where(i => i.UserId == userId).ToList(); }
        public Image GetImageWithDetections(int imageId) { return context.Images.FirstOrDefault(i => i.Id == imageId); }
    }
}