using System;
using System.Collections.Generic;
// אל תוסיפי כאן using c__nRepository_2026...

namespace c__nRepository_2026.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public int GalleryId { get; set; }
        public Gallery Gallery { get; set; }
        public List<DetectedCharacter> DetectedCharacters { get; set; } = new List<DetectedCharacter>();
        public int UserId { get; set; }
    }
}