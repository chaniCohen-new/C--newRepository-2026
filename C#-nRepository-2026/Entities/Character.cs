using System;
using System.Collections.Generic;
// אל תוסיפי כאן using c__nRepository_2026...

namespace c__nRepository_2026.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public string CharacterName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<DetectedCharacter> DetectedCharacters { get; set; } = new List<DetectedCharacter>();
    }
}