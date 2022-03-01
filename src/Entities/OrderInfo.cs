using System;
using Enum;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class OrderInfo
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int ClientDetailId { get; set; }

        public int CurrencyId { get; set; }

        [Comment("can write order number")]
        public string OrderNumber { get; set; }

        public OrderFlagEnum Flag { get; set; }

        public float ExchangeRate { get; set; }

        public string Remark { get; set; }

        public string Invoice { get; set; }

        public string InvoiceAddress { get; set; }

        public string Receipt { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}