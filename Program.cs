using ConsoleApiComRefit.Models;
using Refit;
using System;
using System.Threading.Tasks;

namespace ConsoleApiComRefit
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                string baseUrl = "http://viacep.com.br";

                var cepClient = RestService.For<ICepApiService>(baseUrl);
                Console.WriteLine("Informe seu CEP: ");

                string receivedCep = Console.ReadLine().ToString();
                Console.WriteLine("Consultando informações do CEP: " + receivedCep);

                var response = await cepClient.GetAddressAsync(receivedCep);

                Console.WriteLine($"\n" +
                    $"Logradouro: {response.Logradouro}\n" +
                    $"Complemento: {response.Complemento}\n" +
                    $"Bairro: {response.Bairro}\n" +
                    $"Localidade: {response.Localidade}\n" +
                    $"UF: {response.Uf}\n" +
                    $"IBGE: {response.Ibge}\n" +
                    $"GIA: {response.Gia}\n" +
                    $"DDD: {response.Ddd}\n" +
                    $"SIAFI: {response.Siafi}");

                Console.ReadKey();

            }
            catch (Exception e)
            {

                Console.WriteLine("Erro na consulta de cep: " + e.Message);
            }
        }
    }
}
