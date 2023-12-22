using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsPoster.BL.Auth.Entities;

namespace EventsPoster.BL.Auth
{
    public interface IAuthProvider
    {
        Task<TokensResponse> AuthorizeUser(string email, string password);
        Task RegisterUser(string email, string password);
    }
}
