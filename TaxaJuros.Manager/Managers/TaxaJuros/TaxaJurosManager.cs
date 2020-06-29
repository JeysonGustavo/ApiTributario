using System;
using TaxaJuros.Manager.Models.Result;
using TaxaJuros.Manager.Providers.TaxaJuros;

namespace TaxaJuros.Manager.Managers.TaxaJuros
{
    public class TaxaJurosManager : ITaxaJurosManager
    {
        #region Propriedades
        private readonly ITaxaJurosProvider _taxaJurosProvider;
        #endregion

        #region Construtor
        public TaxaJurosManager(ITaxaJurosProvider taxaJurosProvider)
        {
            _taxaJurosProvider = taxaJurosProvider;
        }
        #endregion

        #region Retorna Taxa Juros
        public ResultModel RetornaTaxaJuros()
        {
            try
            {
                var taxa = _taxaJurosProvider.RetornaTaxaJuros();

                return new ResultModel { Error = null, ResultData = taxa, Success = true };
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
