using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Interfaces
{
    public interface IItemRepository
    {
        List<Item> GetItems();
        int AddItem(Item item);
        void DeleteItem(int id);

        // Método para actualizar un ítem existente
        bool UpdateItem(Item item);
    }
}