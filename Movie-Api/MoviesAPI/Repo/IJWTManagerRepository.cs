using MoviesAPI.Models;
using Newtonsoft.Json.Linq;
using Microsoft.IdentityModel;

namespace MoviesAPI.Repo
{
    public interface IJWTManagerRepository
    {
        string Authentication(LoginModel login);
    }
}
