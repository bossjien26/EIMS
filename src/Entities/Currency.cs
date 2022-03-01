using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public float ExchangeRate { get; set; }
    }
}