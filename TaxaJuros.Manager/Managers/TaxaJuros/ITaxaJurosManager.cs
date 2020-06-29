using TaxaJuros.Manager.Models.Result;

namespace TaxaJuros.Manager.Managers.TaxaJuros
{
    public interface ITaxaJurosManager
    {
        /// <summary>
        /// Retorna a Taxa de Juros
        /// </summary>
        /// <returns></returns>
        public ResultModel RetornaTaxaJuros();
    }
}
