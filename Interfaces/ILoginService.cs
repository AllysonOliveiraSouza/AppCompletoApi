using AppCompletoApi.Dtos;

namespace AppCompletoApi.Interfaces
{
    public interface ILoginService
    {
        public bool ValidaLogin(LoginDto dto);
        public string? GetJwt(LoginDto dto);
    }
}
