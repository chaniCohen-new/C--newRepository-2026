
using System;
using System.Collections.Generic;
// אל תוסיפי כאן using c__nRepository_2026...

namespace c__nRepository_2026.Entities
{
    public class Gallery
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}