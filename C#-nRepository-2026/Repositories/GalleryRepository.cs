using c__nRepository_2026.Interfaces;
using c__nRepository_2026.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace c__nRepository_2026.Repositories
{
    public class GalleryRepository : IRepository<Gallery>
    {
        private readonly IContext context;
        public GalleryRepository(IContext context) { this.context = context; }

        public async Task<Gallery> AddItemAsync(Gallery item)
        {
            item.CreatedDate = DateTime.Now;
            await context.Galleries.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItemAsync(int id)
        {
            var gallery = await GetByIdAsync(id);
            if (gallery != null)
            {
                context.Galleries.Remove(gallery);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Gallery> GetByIdAsync(int id)
        {
            return await context.Galleries.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<List<Gallery>> GetAllAsync()
        {
            return await context.Galleries.OrderByDescending(g => g.CreatedDate).ToListAsync();
        }

        public async Task UpdateItemAsync(int id, Gallery item)
        {
            var gallery = await GetByIdAsync(id);
            if (gallery != null)
            {
                gallery.Name = item.Name;
                gallery.CharacterId = item.CharacterId;
                context.Galleries.Update(gallery);
                await context.SaveChangesAsync();
            }
        }

        // פונקציות ייחודיות למחלקה זו - גם הן הפכו לא-סינכרוניות
        public async Task<List<Gallery>> GetGalleriesByUserIdAsync(int userId)
        {
            return await context.Galleries.Where(g => g.UserId == userId).OrderByDescending(g => g.CreatedDate).ToListAsync();
        }

        public async Task<List<Gallery>> GetGalleriesByCharacterIdAsync(int characterId)
        {
            return await context.Galleries.Where(g => g.CharacterId == characterId).ToListAsync();
        }

        public async Task<Gallery> GetGalleryWithImagesAsync(int galleryId)
        {
            // שימי לב: הוספתי פה Include כדי שבאמת יביא את התמונות יחד עם הגלריה!
            return await context.Galleries.Include(g => g.Images).FirstOrDefaultAsync(g => g.Id == galleryId);
        }
    }
}
/*
 * מטרת הקובץ (GalleryRepository):
 * מחלקה זו אחראית על כל פעולות המסד (CRUD) עבור ישות 'גלריה'.
 * שינויים שבוצעו:
 * 1. הוספת Using ל-Microsoft.EntityFrameworkCore ו-System.Threading.Tasks.
 * 2. כל הפונקציות הפכו ל-async ומחזירות Task כדי לעמוד בדרישת המורה לגישה א-סינכרונית ל-DB (סעיף 22).
 * 3. החלפת פקודות LINQ רגילות בפקודות הא-סינכרוניות של Entity Framework (כמו ToListAsync ו-FirstOrDefaultAsync).
 * 4. שדרוג מקצועי: בפונקציה GetGalleryWithImagesAsync הוספתי את הפקודה Include(g => g.Images). זה הכרחי, כי אחרת Entity Framework לא ישלוף את התמונות הקשורות לגלריה, והרשימה תהיה ריקה.
 */