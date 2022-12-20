using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Models
{
    public class ServerResponse<T>
    {
        public T? DataFromServer { get; set; }
        public bool Success { get; set; } = false;
        public int PagesCount { get; set; } = 1;
    }
}
