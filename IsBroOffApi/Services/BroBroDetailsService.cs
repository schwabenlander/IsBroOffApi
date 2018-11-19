using IsBroOffApi.Models;
using Microsoft.Extensions.Configuration;

namespace IsBroOffApi.Services
{
    public class BroBroDetailsService : IBroDetailsService
    {
        private readonly IConfiguration _configuration;

        public readonly string Name;
        public readonly string PhoneNumber;
        public readonly string EmailAddress;

        public BroBroDetailsService(IConfiguration configuration)
        {
            _configuration = configuration;
            Name = _configuration["BroSettings:Name"];
            PhoneNumber = _configuration["BroSettings:PhoneNumber"];
            EmailAddress = _configuration["BroSettings:Email"];
        }

        public BroDetailsDto GetBroDetails()
        {
            return new BroDetailsDto
            {
                Name = this.Name,
                PhoneNumber = this.PhoneNumber,
                EmailAddress = this.EmailAddress
            };
        }
    }
}
