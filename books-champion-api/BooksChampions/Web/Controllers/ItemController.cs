using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemController(ItemService itemService) {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult Get() {

            return Ok(_itemService.GetItems());
        }

        [HttpPost]
        public IActionResult Post(ItemDto itemDto)
        {
            return Ok(_itemService.AddItem(itemDto));
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _itemService.DeleteItem(id);
            return Ok();
        }
        // Método para actualizar un ítem
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, ItemDto itemDto)
        {
            // Verifica si la actualización fue exitosa
            var result = _itemService.UpdateItem(id, itemDto);
            if (!result)
            {
                return NotFound("El ítem no fue encontrado.");
            }

            return Ok("Ítem actualizado exitosamente.");
        }

    }
}
