using ElectronicsStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Models.Dto
{
    public class Query
    {
        public int? Page { get; set; }
        public string? Search { get; set; }
        public OrderStatus? Status { get; set; }
    }
}
