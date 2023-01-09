using ElectronicsStore.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Models.Dto
{
    public class ChangeStatusByNumberDto
    {
        public int Number { get; set; }
        public OrderStatus Status { get; set; }
    }
}
