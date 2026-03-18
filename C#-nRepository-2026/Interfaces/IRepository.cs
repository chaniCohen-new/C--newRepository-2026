using System.Collections.Generic;
using System.Threading.Tasks;

namespace c__nRepository_2026.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddItemAsync(T item);
        Task DeleteItemAsync(int id);
        Task UpdateItemAsync(int id, T item);
    }
}
/*
 * מטרת הקובץ (Interface - IRepository):
 * זהו ממשק גנרי המגדיר את הפעולות הבסיסיות (CRUD) מול מסד הנתונים לכל טבלה (T).
 * תיקון קריטי: שמות המתודות שונו ונוסף להם הסיומת Async, והן מחזירות Task. 
 * זה מבטיח עמידה בדרישת הפרויקט (סעיף 22) שהגישה ל-DB תהיה א-סינכרונית כדי לא לחסום את התהליך הראשי (Thread).
 */