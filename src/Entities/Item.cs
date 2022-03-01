using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Item
    {
        public int Id { get; set; }

        public int SKU { get; set; }

        public int WarehouseId { get; set; }

        public string Name { get; set; }

        public string Specification { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public string Describe { get; set; }

        public string Information { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        [ForeignKey(nameof(WarehouseId))]
        public Warehouse Warehouse { get; set; }
    }
}