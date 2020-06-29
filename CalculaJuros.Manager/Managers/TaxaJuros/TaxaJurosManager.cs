using CalculaJuros.Manager.Models.Enum;
using CalculaJuros.Manager.Models.Error;
using CalculaJuros.Manager.Models.Result;
using CalculaJuros.Manager.Models.WS;
using CalculaJuros.Manager.Providers.TaxaJuros;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculaJuros.Manager.Managers.TaxaJuros
{
    public class TaxaJurosManager : ITaxaJurosManager
    {
        #region Propriedades
        private readonly ITaxaJurosProvider _taxaJurosProvider;
        private const string ERRO = "Ocorreu um erro inesperado, por favor tente novamente";
        #endregion

        #region Construtor
        public TaxaJurosManager(ITaxaJurosProvider taxaJurosProvider)
        {
            _taxaJurosProvider = taxaJurosProvider;
        }
        #endregion

        #region Call Web Service
        public async Task<ResultModel> CallWebService(string endPoint, RequestTypeEnum requestTypeEnum, object obj = default)
        {
            try
            {
                var httpResponse = new HttpResponseMessage();

                switch (requestTypeEnum)
                {
                    case RequestTypeEnum.GET:
                        httpResponse = await _taxaJurosProvider.GetAsync(endPoint);
                        break;
                    case RequestTypeEnum.POST:
                        httpResponse = await _taxaJurosProvider.PostAsync(endPoint, obj);
                        break;
                    case RequestTypeEnum.PUT:
                        httpResponse = await _taxaJurosProvider.PutAsync(endPoint, obj);
                        break;
                    case RequestTypeEnum.DELETE:
                        httpResponse = await _taxaJurosProvider.DeleteAsync(endPoint);
                        break;
                    default:
                        new ResultModel
                        {
                            Success = false,
                            Error = new ErrorModel
                            {
                                ErrorCode = "0",
                                ErrorMessage = "Nenhuma requisição selecionada",
                            },
                            ResultData = null
                        };
                        break;
                }

                if (!httpResponse.IsSuccessStatusCode)
                {
                    var contentResult = await httpResponse.Content.ReadAsStringAsync();
                    if (((int)httpResponse.StatusCode) >= 400 && ((int)httpResponse.StatusCode) < 500)
                        throw new Exception(contentResult);

                    throw new Exception(ERRO);
                }

                var json = await httpResponse.Content.ReadAsStringAsync();
                var resultCore = JsonConvert.DeserializeObject<ResultCoreModel>(json);

                return new ResultModel
                {
                    Error = resultCore.Error,
                    Success = resultCore.Success,
                    ResultData = Convert.ToString(resultCore.ResultData)
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion
    }
}
