using C__repository_2026.Interfaces;
using C__repository_2026.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace C__repository_2026.Repositories
{
    public class CharacterRepository : IRepository<Character>
    {
        private readonly IContext context;

        public CharacterRepository(IContext context)
        {
            this.context = context;
        }

        public Character AddItem(Character item)
        {
            context.Characters.Add(item);
            context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            var character = Get(id);
            if (character != null)
            {
                context.Characters.Remove(character);
                context.Save();
            }
        }

        public Character Get(int id)
        {
            return context.Characters.FirstOrDefault(c => c.Id == id);
        }

        public List<Character> GetAll()
        {
            return context.Characters.ToList();
        }

        public void UpdateItem(int id, Character item)
        {
            var character = Get(id);
            if (character != null)
            {
                character.CharacterName = item.CharacterName;
                character.Description = item.Description;
                context.Characters.Update(character);
                context.Save();
            }
        }
    }
}