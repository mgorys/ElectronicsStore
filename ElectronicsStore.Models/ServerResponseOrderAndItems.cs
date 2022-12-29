using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Models
{
    public class ServerResponseOrderAndItems<T>
    {
        public T? PurchasedItemList { get; set; }
        public bool Success { get; set; } = false;
        public int OrderNumber { get; set; }
        public DateTime PutDate { get; set; }
        public string Status { get; set; }
        public decimal TotalWorth { get; set; }
        public string UserName { get; set; }
    }
}
