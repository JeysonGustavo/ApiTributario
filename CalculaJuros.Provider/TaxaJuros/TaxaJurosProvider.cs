using CalculaJuros.Manager;
using CalculaJuros.Manager.Providers.TaxaJuros;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CalculaJuros.Provider.TaxaJuros
{
    public class TaxaJurosProvider : ITaxaJurosProvider
    {
        #region Propriedades
        private readonly HttpClient _client;
        #endregion

        #region Construtor
        public TaxaJurosProvider()
        {
            _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.Uri;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion

        #region Post Async
        public async Task<HttpResponseMessage> PostAsync<T>(string endPoint, T obj)
            => await new Manager.HttpClientHelper(_client)
                .SetEndpoint(endPoint)
                .WithContentSerialized(obj)
                .PostAsync(); 
        #endregion

        #region Put Async
        public async Task<HttpResponseMessage> PutAsync<T>(string endPoint, T obj)
         => await new Manager.HttpClientHelper(_client)
                .SetEndpoint(endPoint)
                .WithContentSerialized(obj)
                .PutAsync(); 
        #endregion

        #region Get Async
        public async Task<HttpResponseMessage> GetAsync(string endPoint)
        => await new Manager.HttpClientHelper(_client)
                .SetEndpoint(endPoint)
                .GetAsync(); 
        #endregion

        #region Delete Async
        public async Task<HttpResponseMessage> DeleteAsync(string endPoint)
          => await new Manager.HttpClientHelper(_client)
              .SetEndpoint(endPoint)
              .DeleteAsync(); 
        #endregion
    }
}
