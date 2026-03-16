using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace C__repository_2026.Entities
{
    public class Gallery
    {
        public int Id { get; set; }
        public string Name { get; set; }           // שם האוסף (למשל: "דמות מסוימת")
        public int CharacterId { get; set; }       // איזו דמות זה
        public Character Character { get; set; }   // הקשר ל-Character
        public List<Image> Images { get; set; }    // כל התמונות באוסף הזה
        public int UserId { get; set; }            // למי שייך
        public DateTime CreatedDate { get; set; }  // מתי נוצר
    }
}