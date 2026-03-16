using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using C__repository_2026.Entities;

namespace C__repository_2026.Interfaces
{
    public interface IContext
    {
        DbSet<Gallery> Galleries { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<Character> Characters { get; set; }
        DbSet<DetectedCharacter> DetectedCharacters { get; set; }
        public void Save();
    }
}