using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsBroOffApi.Models;

namespace IsBroOffApi.Services
{
    public interface IBroDetailsService
    {
        BroDetailsDto GetBroDetails();
    }
}
