using System;
using System.Collections.Generic;
// אל תוסיפי כאן using c__nRepository_2026...

namespace c__nRepository_2026.Entities
{
    public class DetectedCharacter
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public int CharacterId { get; set; }
        public float Confidence { get; set; }
        public DateTime DetectionDate { get; set; }

        public virtual Image Image { get; set; }
        public virtual Character Character { get; set; }
    }
}