using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Application.Service.Implementations.Login
{
    public interface IAppLogger<T>
    {
        void LogInformation(string message);
        void LogError(Exception ex, string message);
        void LogWarning(string message);
    }
}
