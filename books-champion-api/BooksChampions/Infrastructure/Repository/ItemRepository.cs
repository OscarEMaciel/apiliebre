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
