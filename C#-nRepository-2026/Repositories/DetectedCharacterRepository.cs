using c__nRepository_2026.Interfaces;
using c__nRepository_2026.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace c__nRepository_2026.Repositories
{
    public class DetectedCharacterRepository : IRepository<DetectedCharacter>
    {
        private readonly IContext context;

        // הזרקת תלויות של ה-IContext
        public DetectedCharacterRepository(IContext context) { this.context = context; }

        public async Task<DetectedCharacter> AddItemAsync(DetectedCharacter item)
        {
            item.DetectionDate = DateTime.Now;
            await context.DetectedCharacters.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItemAsync(int id)
        {
            var detection = await GetByIdAsync(id);
            if (detection != null)
            {
                context.DetectedCharacters.Remove(detection);
                await context.SaveChangesAsync();
            }
        }

        public async Task<DetectedCharacter> GetByIdAsync(int id)
        {
            return await context.DetectedCharacters.FirstOrDefaultAsync(dc => dc.Id == id);
        }

        public async Task<List<DetectedCharacter>> GetAllAsync()
        {
            return await context.DetectedCharacters.OrderByDescending(dc => dc.DetectionDate).ToListAsync();
        }

        public async Task UpdateItemAsync(int id, DetectedCharacter item)
        {
            var detection = await GetByIdAsync(id);
            if (detection != null)
            {
                detection.Confidence = item.Confidence;
                context.DetectedCharacters.Update(detection);
                await context.SaveChangesAsync();
            }
        }

        // --- פונקציות ייחודיות למחלקה זו ---

        public async Task<List<DetectedCharacter>> GetDetectionsByImageIdAsync(int imageId)
        {
            return await context.DetectedCharacters.Where(dc => dc.ImageId == imageId).OrderByDescending(dc => dc.Confidence).ToListAsync();
        }

        public async Task<List<DetectedCharacter>> GetDetectionsByCharacterIdAsync(int characterId)
        {
            return await context.DetectedCharacters.Where(dc => dc.CharacterId == characterId).OrderByDescending(dc => dc.DetectionDate).ToListAsync();
        }
    }
}
/*
 * מטרת הקובץ (DetectedCharacterRepository):
 * מחלקה זו אחראית על ניהול טבלת 'זיהויים' (DetectedCharacters) במסד הנתונים.
 * זוהי למעשה טבלת הגישור שמחברת בין תמונה לדמות שזוהתה בה.
 * * שינויים שבוצעו כדי לעמוד בדרישות הפרויקט:
 * 1. הוספת Using ל-Microsoft.EntityFrameworkCore ול-System.Threading.Tasks.
 * 2. כל הפונקציות הומרו לא-סינכרוניות (async/await ומחזירות Task) בהתאם לדרישת המורה שהפרויקט יהיה א-סינכרוני בכל גישה ל-DB.
 * 3. פונקציות שליפה שונו להשתמש ב-ToListAsync ו-FirstOrDefaultAsync.
 * 4. הפונקציות הייחודיות (כמו שליפת כל הזיהויים עבור תמונה ספציפית או דמות ספציפית) עודכנו גם הן לעבודה א-סינכרונית.
 */