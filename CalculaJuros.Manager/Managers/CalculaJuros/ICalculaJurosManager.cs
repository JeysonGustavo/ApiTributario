using CalculaJuros.Manager.Models.Result;
using System.Threading.Tasks;

namespace CalculaJuros.Manager.Managers.CalculaJuros
{
    public interface ICalculaJurosManager
    {
        /// <summary>
        /// Calcula Juros
        /// </summary>
        /// <param name="valorInicial">Valor inicial</param>
        /// <param name="tempo">Tempo em messes</param>
        /// <returns></returns>
        Task<ResultModel> CalculaJuros(decimal valorInicial, int tempo);

        /// <summary>
        /// Retorna a URL do código fonte do projeto no GitHub
        /// </summary>
        /// <returns></returns>
        ResultModel ShowMeTheCode();
    }
}
