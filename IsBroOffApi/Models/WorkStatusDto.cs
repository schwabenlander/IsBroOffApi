using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsBroOffApi.Models
{
    public class WorkStatusDto
    {
        public DateTime Date { get; set; }
        public string DateAsString { get; set; }
        public bool IsBroOff { get; set; }
        public string StatusText { get; set; }
    }
}
