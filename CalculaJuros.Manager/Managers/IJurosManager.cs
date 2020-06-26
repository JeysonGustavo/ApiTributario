using CalculaJuros.Manager.Models.Result;

namespace CalculaJuros.Manager.Managers
{
    public interface IJurosManager
    {
        /// <summary>
        /// Retorna a Taxa de Juros
        /// </summary>
        /// <returns></returns>
        public ResultModel RetornaTaxaJuros();
    }
}
