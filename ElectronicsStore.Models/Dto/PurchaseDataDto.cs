using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Models.Dto
{
    public class PurchaseDataDto<T>
    {
        public T? PurchaseList { get; set; }
        public string Email { get; set; }
    }
}
