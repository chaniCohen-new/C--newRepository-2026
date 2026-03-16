using c__nRepository_2026.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace c__nRepository_2026.Interfaces
{
    public interface IContext
    {
        DbSet<Character> Characters { get; set; }
        DbSet<DetectedCharacter> DetectedCharacters { get; set; }
        DbSet<Gallery> Galleries { get; set; }
        DbSet<Image> Images { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}