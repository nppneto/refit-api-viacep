using Refit;
using System.Threading.Tasks;

namespace ConsoleApiComRefit.Models
{
    internal interface ICepApiService
    {
        [Get("/ws/{cep}/json")]
        Task<CepResponse> GetAddressAsync(string cep);
    }
}
