using System;
using static System.Net.Mime.MediaTypeNames;

namespace C__repository_2026.Entities
{
    public class DetectedCharacter
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public int CharacterId { get; set; }
        public float Confidence { get; set; } // ערך בין 0 ל-1 לדיוק הזיהוי
        public DateTime DetectionDate { get; set; }

        // Foreign Keys
        public virtual Image Image { get; set; }
        public virtual Character Character { get; set; }
    }
}