using TaxaJuros.Manager.Providers.TaxaJuros;

namespace TaxaJuros.Provider.TaxaJuros
{
    public class TaxaJurosProvider : ITaxaJurosProvider
    {
        #region Retorna Taxa Juros
        public decimal RetornaTaxaJuros()
        {
            return 0.01m;
        }
        #endregion
    }
}
