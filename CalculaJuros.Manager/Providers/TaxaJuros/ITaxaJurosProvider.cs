using System.Net.Http;
using System.Threading.Tasks;

namespace CalculaJuros.Manager.Providers.TaxaJuros
{
    public interface ITaxaJurosProvider
    {
        /// <summary>
        /// Post Async
        /// </summary>
        /// <typeparam name="T">Tipo do parâmetro</typeparam>
        /// <param name="endPoint">End point da chamada</param>
        /// <param name="obj">Objeto</param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostAsync<T>(string endPoint, T obj);

        /// <summary>
        /// Put Async
        /// </summary>
        /// <typeparam name="T">Tipo do parâmetro</typeparam>
        /// <param name="endPoint">End point da chamada</param>
        /// <param name="obj">Objeto</param>
        /// <returns></returns>
        Task<HttpResponseMessage> PutAsync<T>(string endPoint, T obj);

        /// <summary>
        /// Get Async
        /// </summary>
        /// <param name="endPoint">End point da chamada</param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetAsync(string endPoint);

        /// <summary>
        /// Delete Async
        /// </summary>
        /// <param name="endPoint">End point da chamada</param>
        /// <returns></returns>
        Task<HttpResponseMessage> DeleteAsync(string endPoint);
    }
}
