using System;
using System.Collections.Generic;

namespace C__repository_2026.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int GalleryId { get; set; } // קישור לגלריה
        public Gallery Gallery { get; set; }
        public List<DetectedCharacter> DetectedCharacters { get; set; } = new List<DetectedCharacter>();
        public int UserId { get; set; }
    }
}