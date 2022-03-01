using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        public string Company { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public IList<SupplierContact> SupplierContacts { get; set; }
    }
}