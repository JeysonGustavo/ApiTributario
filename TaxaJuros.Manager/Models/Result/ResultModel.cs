using TaxaJuros.Manager.Models.Error;

namespace TaxaJuros.Manager.Models.Result
{
    public class ResultModel
    {
        #region Propriedades
        public bool Success { get; set; }
        public ErrorModel Error { get; set; }
        public dynamic ResultData { get; set; }
        #endregion

        #region Construtor
        public ResultModel()
        {
            Error = new ErrorModel();
        }

        public ResultModel(ErrorModel error, dynamic resulData = null)
        {
            Error = error;
            ResultData = resulData;
        }

        public ResultModel(bool success, ErrorModel error = null, dynamic resulData = null)
        {
            Success = success;
            Error = error;
            ResultData = resulData;
        }
        #endregion
    }
}
