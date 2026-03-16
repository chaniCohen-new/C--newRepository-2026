using c__nRepository_2026.Interfaces;
using c__nRepository_2026.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace c__nRepository_2026.Repositories
{
    public class GalleryRepository : IRepository<Gallery>
    {
        private readonly IContext context;
        public GalleryRepository(IContext context) { this.context = context; }

        public Gallery AddItem(Gallery item) { item.CreatedDate = DateTime.Now; context.Galleries.Add(item); context.SaveChanges(); return item; }
        public void DeleteItem(int id) { var gallery = Get(id); if (gallery != null) { context.Galleries.Remove(gallery); context.SaveChanges(); } }
        public Gallery Get(int id) { return context.Galleries.FirstOrDefault(g => g.Id == id); }
        public List<Gallery> GetAll() { return context.Galleries.OrderByDescending(g => g.CreatedDate).ToList(); }
        public void UpdateItem(int id, Gallery item) { var gallery = Get(id); if (gallery != null) { gallery.Name = item.Name; gallery.CharacterId = item.CharacterId; context.Galleries.Update(gallery); context.SaveChanges(); } }

        public List<Gallery> GetGalleriesByUserId(int userId) { return context.Galleries.Where(g => g.UserId == userId).OrderByDescending(g => g.CreatedDate).ToList(); }
        public List<Gallery> GetGalleriesByCharacterId(int characterId) { return context.Galleries.Where(g => g.CharacterId == characterId).ToList(); }
        public Gallery GetGalleryWithImages(int galleryId) { return context.Galleries.FirstOrDefault(g => g.Id == galleryId); }
    }
}