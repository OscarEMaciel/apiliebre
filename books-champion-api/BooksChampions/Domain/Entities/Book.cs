using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required int Price { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }
        public string? ImageURL { get; set; }
    }
}
