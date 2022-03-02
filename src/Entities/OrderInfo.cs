using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Enum;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    [Index(nameof(CompanyId), nameof(ContactId))]
    public class OrderInfo
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public int ContactId { get; set; }

        public int CurrencyId { get; set; }

        [Comment("can write order number")]
        public string OrderNumber { get; set; } = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();

        public OrderFlagEnum Flag { get; set; }

        public float ExchangeRate { get; set; }

        public string Remark { get; set; }

        public string Invoice { get; set; }

        public string InvoiceAddress { get; set; }

        public string Receipt { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        [ForeignKey(nameof(CurrencyId))]
        public virtual Currency Currency { get; set; }

        public IList<OrderItem> OrderItems { get; set; }
    }
}