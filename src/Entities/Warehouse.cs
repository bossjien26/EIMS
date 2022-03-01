using System.ComponentModel.DataAnnotations;
using Enum;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    [Index(nameof(Type))]
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }

        public WarehouseEnum Type { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}