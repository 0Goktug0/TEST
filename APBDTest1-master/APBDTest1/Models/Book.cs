using System.ComponentModel.DataAnnotations.Schema;

namespace APBDTest1.Models
{
    [Table("books")]
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<BookEdition> Editions { get; set; }
    }
}
