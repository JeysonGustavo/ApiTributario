using CalculaJuros.Manager.Models.Enum;
using CalculaJuros.Manager.Models.Result;
using System.Threading.Tasks;

namespace CalculaJuros.Manager.Managers.TaxaJuros
{
    public interface ITaxaJurosManager
    {
        /// <summary>
        /// Chamar Web Service
        /// </summary>
        /// <param name="endPoint">End point</param>
        /// <param name="requestTypeEnum">Tipo de chamada</param>
        /// <param name="obj">objeto a ser enviado</param>
        /// <returns></returns>
        Task<ResultModel> CallWebService(string endPoint, RequestTypeEnum requestTypeEnum, object obj = default);
    }
}
