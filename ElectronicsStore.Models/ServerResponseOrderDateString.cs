using ElectronicsStore.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Models
{
    public class ServerResponseOrderDateString<T>
    {
        public T? PurchasedItemList { get; set; }
        public bool Success { get; set; } = false;
        public int OrderNumber { get; set; }
        public string PutDate { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalWorth { get; set; }
        public string UserName { get; set; }
    }
}
