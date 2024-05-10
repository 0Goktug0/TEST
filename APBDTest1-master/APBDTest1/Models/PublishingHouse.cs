using System.ComponentModel.DataAnnotations.Schema;

namespace APBDTest1.Models
{
    [Table("publishing_houses")]
    public class PublishingHouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
