using c__nRepository_2026.Interfaces;
using c__nRepository_2026.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace c__nRepository_2026.Repositories
{
    public class ImageRepository : IRepository<Image>
    {
        private readonly IContext context;
        public ImageRepository(IContext context) { this.context = context; }

        public async Task<Image> AddItemAsync(Image item)
        {
            await context.Images.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItemAsync(int id)
        {
            var image = await GetByIdAsync(id);
            if (image != null)
            {
                context.Images.Remove(image);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Image> GetByIdAsync(int id)
        {
            return await context.Images.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Image>> GetAllAsync()
        {
            return await context.Images.ToListAsync();
        }

        public async Task UpdateItemAsync(int id, Image item)
        {
            var image = await GetByIdAsync(id);
            if (image != null)
            {
                image.Url = item.Url;
                image.GalleryId = item.GalleryId;
                context.Images.Update(image);
                await context.SaveChangesAsync();
            }
        }

        // פונקציות ייחודיות למחלקה זו
        public async Task<List<Image>> GetImagesByGalleryIdAsync(int galleryId)
        {
            return await context.Images.Where(i => i.GalleryId == galleryId).ToListAsync();
        }

        public async Task<List<Image>> GetImagesByUserIdAsync(int userId)
        {
            return await context.Images.Where(i => i.UserId == userId).ToListAsync();
        }

        public async Task<Image> GetImageWithDetectionsAsync(int imageId)
        {
            // הוספתי Include כדי להביא את נתוני הזיהוי יחד עם התמונה
            return await context.Images.Include(i => i.DetectedCharacters).FirstOrDefaultAsync(i => i.Id == imageId);
        }
    }
}
/*
 * מטרת הקובץ (ImageRepository):
 * מנהל את הגישה לנתונים עבור טבלת ה'תמונות'. 
 * בדומה ל-GalleryRepository, הכל הומר לעבודה א-סינכרונית (Task, async/await, ToListAsync).
 * בפונקציה GetImageWithDetectionsAsync הוסף שימוש ב-Include. המטרה היא כשאנחנו שולפים תמונה, 
 * נשלוף יחד איתה (Eager Loading) את כל אובייקטי ה-DetectedCharacters המקושרים אליה, כדי שנוכל להציג למשתמש מי הדמויות שזוהו בה.
 */