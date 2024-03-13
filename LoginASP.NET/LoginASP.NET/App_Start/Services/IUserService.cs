using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginASP.NET.Models;

namespace LoginASP.NET.App_Start.Services
{
    public interface IUserService
    {
        Task<TokenViewModel> LoginAsync(string username, string password);
    }
}
