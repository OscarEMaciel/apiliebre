using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly ItemDbContext _dbContext;

        public ItemRepository(ItemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Item> GetItems()
        {
            return _dbContext.Items.ToList();
        }

        public int AddItem(Item item)
        {
            _dbContext.Items.Add(item);
            _dbContext.SaveChanges();
            return item.Id;
        }

        public bool UpdateItem(Item item)
        {
            // Busca el ítem existente en la base de datos
            var existingItem = _dbContext.Items.FirstOrDefault(x => x.Id == item.Id);

            if (existingItem != null)
            {
                // Actualiza los campos necesarios
                existingItem.Title = item.Title;
                existingItem.Description = item.Description;
                existingItem.Price = item.Price;
                // Añade más campos según corresponda

                _dbContext.SaveChanges();
                return true;
            }

            return false; // Retorna false si el ítem no fue encontrado
        }



        public void DeleteItem(int id)
        {
            var item = _dbContext.Items.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                _dbContext.Items.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
