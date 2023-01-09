using ElectronicsStore.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Models.Dto
{
    public class OrderDto
    {
        public int OrderNumber { get; set; }
        public string PutDate { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalWorth { get; set; }
        public string UserName { get; set; }
    }
}
