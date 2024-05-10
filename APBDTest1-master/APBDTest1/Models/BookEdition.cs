using System.ComponentModel.DataAnnotations.Schema;

namespace APBDTest1.Models
{
    [Table("books_editions")]
    public class BookEdition
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string EditionTitle { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int PublishingHouseId { get; set; }
        public PublishingHouse PublishingHouse { get; set; }
    }

}
