using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceApp.Application.Service.Implementations.Login;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Infrastructure.Service
{
    public class SerilogLoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;

        public SerilogLoggerAdapter(ILogger<T> logger) // Constructor 
        {
            _logger = logger;
        }

        public void LogError(Exception ex, string message) => _logger.LogError(ex, message);
        public void LogInformation(string message) => _logger.LogInformation(message);
        public void LogWarning(string message) => _logger.LogWarning(message);
    }
}
