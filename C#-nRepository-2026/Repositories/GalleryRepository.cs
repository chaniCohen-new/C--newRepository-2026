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
    public class GalleryRepository : IRepository<Gallery>
    {
        private readonly IContext context;

        public GalleryRepository(IContext context)
        {
            this.context = context;
        }

        public Gallery AddItem(Gallery item)
        {
            item.CreatedDate = DateTime.Now;
            context.Galleries.Add(item);
            context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            var gallery = Get(id);
            if (gallery != null)
            {
                context.Galleries.Remove(gallery);
                context.Save();
            }
        }

        public Gallery Get(int id)
        {
            return context.Galleries
                .Where(g => g.Id == id)
                .FirstOrDefault();
        }

        public List<Gallery> GetAll()
        {
            return context.Galleries
                .OrderByDescending(g => g.CreatedDate)
                .ToList();
        }

        public void UpdateItem(int id, Gallery item)
        {
            var gallery = Get(id);
            if (gallery != null)
            {
                gallery.Name = item.Name;
                gallery.CharacterId = item.CharacterId;
                context.Galleries.Update(gallery);
                context.Save();
            }
        }

        public List<Gallery> GetGalleriesByUserId(int userId)
        {
            return context.Galleries
                .Where(g => g.UserId == userId)
                .OrderByDescending(g => g.CreatedDate)
                .ToList();
        }

        public List<Gallery> GetGalleriesByCharacterId(int characterId)
        {
            return context.Galleries
                .Where(g => g.CharacterId == characterId)
                .ToList();
        }

        public Gallery GetGalleryWithImages(int galleryId)
        {
            return context.Galleries
                .Where(g => g.Id == galleryId)
                .FirstOrDefault();
        }
    }
}