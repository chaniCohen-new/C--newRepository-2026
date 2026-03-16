using C__repository_2026.Interfaces;
using C__repository_2026.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace C__repository_2026.Repositories
{
    public class ImageRepository : IRepository<Image>
    {
        private readonly IContext context;

        public ImageRepository(IContext context)
        {
            this.context = context;
        }

        public Image AddItem(Image item)
        {
            context.Images.Add(item);
            context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            var image = Get(id);
            if (image != null)
            {
                context.Images.Remove(image);
                context.Save();
            }
        }

        public Image Get(int id)
        {
            return context.Images
                .Where(i => i.Id == id)
                .FirstOrDefault();
        }

        public List<Image> GetAll()
        {
            return context.Images.ToList();
        }

        public void UpdateItem(int id, Image item)
        {
            var image = Get(id);
            if (image != null)
            {
                image.Url = item.Url;
                image.GalleryId = item.GalleryId;
                context.Images.Update(image);
                context.Save();
            }
        }

        public List<Image> GetImagesByGalleryId(int galleryId)
        {
            return context.Images
                .Where(i => i.GalleryId == galleryId)
                .ToList();
        }

        public List<Image> GetImagesByUserId(int userId)
        {
            return context.Images
                .Where(i => i.UserId == userId)
                .ToList();
        }

        /// קבל תמונה עם כל הדמויות שזוהו בה
        /// זה חשוב כשרוצים להציג את התמונה ואת כל הדמויות שנמצאו בה
        public Image GetImageWithDetections(int imageId)
        {
            return context.Images
                .Where(i => i.Id == imageId)
                .FirstOrDefault();
        }
    }
}