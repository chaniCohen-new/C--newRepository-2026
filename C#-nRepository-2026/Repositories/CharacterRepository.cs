using c__nRepository_2026.Interfaces;
using c__nRepository_2026.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace c__nRepository_2026.Repositories
{
    public class CharacterRepository : IRepository<Character>
    {
        private readonly IContext context;
        public CharacterRepository(IContext context) { this.context = context; }

        public async Task<Character> AddItemAsync(Character item)
        {
            await context.Characters.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItemAsync(int id)
        {
            var character = await GetByIdAsync(id);
            if (character != null)
            {
                context.Characters.Remove(character);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Character> GetByIdAsync(int id)
        {
            // שימוש ב-FirstOrDefaultAsync במקום FirstOrDefault הרגיל
            return await context.Characters.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Character>> GetAllAsync()
        {
            // שימוש ב-ToListAsync
            return await context.Characters.ToListAsync();
        }

        public async Task UpdateItemAsync(int id, Character item)
        {
            var character = await GetByIdAsync(id);
            if (character != null)
            {
                character.CharacterName = item.CharacterName;
                character.Description = item.Description;
                context.Characters.Update(character);
                await context.SaveChangesAsync();
            }
        }
    }
}
/*
 * מטרת הקובץ (Repository - CharacterRepository):
 * מימוש בפועל של גישה לנתונים עבור ישות 'דמות' מתוך מסד הנתונים.
 * המימוש מעודכן להיות א-סינכרוני (async/await) עם פונקציות כמו ToListAsync() השייכות ל-Entity Framework.
 * המחלקה משתמשת בהזרקת תלויות (DI) של ה-IContext בקונסטרקטור, בהתאם לדרישות (סעיף 4).
 */