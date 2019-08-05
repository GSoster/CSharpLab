using System;
using System.Collections.Generic;

namespace Xml
{
    public class Purchase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string OrderNumber { get; set; }
        public string SellerId { get; set; }

        public List<string> SellerIds { get; set; } = new List<string>(){
        "seller1",
        "seller2",
        "seller3",
        "seller4",
        };

        public int[] ItemIds { get; set; } =
        {
            32,
            12,
            27,
            42
        };
    }
}