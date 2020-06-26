using CalculaJuros.Manager.Providers;

namespace CalculaJuros.Provider
{
    public class JurosProvider : IJurosProvider
    {
        #region Retorna Taxa Juros
        public decimal RetornaTaxaJuros()
        {
            return 0.01m;
        } 
        #endregion
    }
}
