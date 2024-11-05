using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class ItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public List<ItemDto> GetItems()
        {
            var items = _itemRepository.GetItems();

            return items.Select(item => new ItemDto
            {
                Id = item.Id,
                Title = item.Title,
                Price = item.Price,
                Description = item.Description,
                Category = item.Category,
                ImageURL = item.ImageURL
            })
                .ToList();
        }

        public int AddItem(ItemDto itemDto)
        {
            var item = new Item
            {
                Id = itemDto.Id,
                Title = itemDto.Title,
                Price = itemDto.Price,
                Description = itemDto.Description,
                Category = itemDto.Category,
                ImageURL = itemDto.ImageURL
            };

            return _itemRepository.AddItem(item);
        }

        public void DeleteItem(int id)
        {
            _itemRepository.DeleteItem(id);
        }
    }
}
