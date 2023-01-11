using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private static readonly List<ItemDto> items = new()
        {
            new ItemDto(Guid.NewGuid(), "Potion","Restores a small amount of HP",5, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Potion 2","Restores a small amount of HP",5, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Potion 3","Restores a small amount of HP",5, DateTimeOffset.UtcNow)
        };


        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            return items;
        }

        [HttpGet("{Id}")]
        public ItemDto GetById(Guid Id)
        {
            var item = items.Where(x => x.Id == Id).SingleOrDefault();
            return item;
        }
        
        [HttpPost]
        public ActionResult<ItemDto> Post(CreateItemDto createItemDto)
        {
            var item = new ItemDto(Guid.NewGuid(), createItemDto.Name, createItemDto.Desc, createItemDto.Price, DateTimeOffset.UtcNow);

            items.Add(item);
            return CreatedAtAction(nameof(GetById), new {id= item.Id}, item);
        }

    }
}
