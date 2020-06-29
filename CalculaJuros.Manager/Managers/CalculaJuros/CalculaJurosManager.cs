using CalculaJuros.Manager.Managers.TaxaJuros;
using CalculaJuros.Manager.Models.Enum;
using CalculaJuros.Manager.Models.Result;
using CalculaJuros.Manager.Providers.CalculaJuros;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CalculaJuros.Manager.Managers.CalculaJuros
{
    public class CalculaJurosManager : ICalculaJurosManager
    {
        #region Propriedades
        private readonly ICalculaJurosProvider _calculaJurosProvider;
        private readonly ITaxaJurosManager _taxaJurosManager;
        #endregion

        #region Construtor
        public CalculaJurosManager(ICalculaJurosProvider calculaJurosProvider, ITaxaJurosManager taxaJurosManager)
        {
            _calculaJurosProvider = calculaJurosProvider;
            _taxaJurosManager = taxaJurosManager;
        }
        #endregion

        #region Calcula Juros
        public async Task<ResultModel> CalculaJuros(decimal valorInicial, int tempo)
        {
            try
            {
                //Chamar a API Taxa Juros
                var result = await _taxaJurosManager.CallWebService($"TaxaJuros/taxaJuros", RequestTypeEnum.GET);

                var taxaJuros = JsonConvert.DeserializeObject<decimal>(result.ResultData);

                var retorno = _calculaJurosProvider.CalculaJuros(valorInicial, taxaJuros, tempo);

                return new ResultModel { Success = true, Error = null, ResultData = retorno };
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region ShowMe The Code
        public ResultModel ShowMeTheCode()
        {
            try
            {
                var retorno = _calculaJurosProvider.ShowMeTheCode();

                return new ResultModel { Error = null, ResultData = retorno, Success = true };
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
