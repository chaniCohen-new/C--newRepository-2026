using C__repository_2026.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
<<<<<<< HEAD
        DbSet<Gallery> Galleries { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<Character> Characters { get; set; }
        DbSet<DetectedCharacter> DetectedCharacters { get; set; }
        void Save();

=======
         List<T> GetAll();
         T Get(int id);
         T AddItem(T item);
         void DeleteItem(int id);
         void UpdateItem(int id, T item);
>>>>>>> 51113ab6fa9afebca6108a2c968f160eac88500f
    }
}