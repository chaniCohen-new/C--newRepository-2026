using c__nRepository_2026.Interfaces;
using c__nRepository_2026.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace c__nRepository_2026.Repositories
{
    public class DetectedCharacterRepository : IRepository<DetectedCharacter>
    {
        private readonly IContext context;
        public DetectedCharacterRepository(IContext context) { this.context = context; }

        public DetectedCharacter AddItem(DetectedCharacter item) { item.DetectionDate = DateTime.Now; context.DetectedCharacters.Add(item); context.SaveChanges(); return item; }
        public void DeleteItem(int id) { var detection = Get(id); if (detection != null) { context.DetectedCharacters.Remove(detection); context.SaveChanges(); } }
        public DetectedCharacter Get(int id) { return context.DetectedCharacters.FirstOrDefault(dc => dc.Id == id); }
        public List<DetectedCharacter> GetAll() { return context.DetectedCharacters.OrderByDescending(dc => dc.DetectionDate).ToList(); }
        public void UpdateItem(int id, DetectedCharacter item) { var detection = Get(id); if (detection != null) { detection.Confidence = item.Confidence; context.DetectedCharacters.Update(detection); context.SaveChanges(); } }

        public List<DetectedCharacter> GetDetectionsByImageId(int imageId) { return context.DetectedCharacters.Where(dc => dc.ImageId == imageId).OrderByDescending(dc => dc.Confidence).ToList(); }
        public List<DetectedCharacter> GetDetectionsByCharacterId(int characterId) { return context.DetectedCharacters.Where(dc => dc.CharacterId == characterId).OrderByDescending(dc => dc.DetectionDate).ToList(); }
    }
}