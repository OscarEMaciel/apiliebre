using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required int Price { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }
        public string ImageURL { get; set; }

    }
}