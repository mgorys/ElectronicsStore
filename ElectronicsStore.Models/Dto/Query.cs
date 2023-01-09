using ElectronicsStore.Entities.Enums;
using ElectronicsStore.Models.Enums;
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
        public SortDirection? SortDirection { get; set; }
        public int PageSize { get; set; } = 5;
    }
}
