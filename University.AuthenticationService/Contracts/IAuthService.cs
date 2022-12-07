using University.AuthenticationService.Models;

namespace University.AuthenticationService.Contracts
{
    public interface IAuthService
    {
        string GetToken(TokenRequestModel model);
    }
}
