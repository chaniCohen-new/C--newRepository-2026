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
    public class DetectedCharacterRepository : IRepository<DetectedCharacter>
    {
        private readonly IContext context;

        public DetectedCharacterRepository(IContext context)
        {
            this.context = context;
        }

        public DetectedCharacter AddItem(DetectedCharacter item)
        {
            item.DetectionDate = DateTime.Now;
            context.DetectedCharacters.Add(item);
            context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            var detection = Get(id);
            if (detection != null)
            {
                context.DetectedCharacters.Remove(detection);
                context.Save();
            }
        }

        public DetectedCharacter Get(int id)
        {
            return context.DetectedCharacters
                .Where(dc => dc.Id == id)
                .FirstOrDefault();
        }

        public List<DetectedCharacter> GetAll()
        {
            return context.DetectedCharacters
                .OrderByDescending(dc => dc.DetectionDate)
                .ToList();
        }

        public void UpdateItem(int id, DetectedCharacter item)
        {
            var detection = Get(id);
            if (detection != null)
            {
                detection.Confidence = item.Confidence;
                context.DetectedCharacters.Update(detection);
                context.Save();
            }
        }

        /// קבל את כל הדמויות שזוהו בתמונה מסוימת
        /// מסודרות לפי רמת ודאות (הדיוק הגבוה ביותר קודם)
        /// דוגמה: בתמונה X זוהו: Brad Pitt (95%), Tom Hanks (87%)
        /// OrderByDescending: מסדר מהודאות הגבוהה לנמוכה
        public List<DetectedCharacter> GetDetectionsByImageId(int imageId)
        {
            return context.DetectedCharacters
                .Where(dc => dc.ImageId == imageId)
                .OrderByDescending(dc => dc.Confidence)
                .ToList();
        }

        /// קבל את כל התמונות שזוהתה בהן דמות מסוימת
        /// מסודרות לפי תאריך זיהוי
        public List<DetectedCharacter> GetDetectionsByCharacterId(int characterId)
        {
            return context.DetectedCharacters
                .Where(dc => dc.CharacterId == characterId)
                .OrderByDescending(dc => dc.DetectionDate)
                .ToList();
        }
    }
}