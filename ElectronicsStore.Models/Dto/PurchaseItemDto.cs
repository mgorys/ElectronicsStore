using ElectronicsStore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Models.Dto
{
    public class PurchaseItemDto
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
