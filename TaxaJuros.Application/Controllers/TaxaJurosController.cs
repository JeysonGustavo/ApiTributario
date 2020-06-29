using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxaJuros.Manager.Managers.TaxaJuros;
using TaxaJuros.Manager.Models.Error;
using TaxaJuros.Manager.Models.Result;

namespace TaxaJuros.Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        #region Propriedades
        private readonly ITaxaJurosManager _taxaJurosManager;
        #endregion

        #region Construtor
        public TaxaJurosController([FromServices] ITaxaJurosManager taxaJurosManager)
        {
            _taxaJurosManager = taxaJurosManager;
        }
        #endregion

        #region Retorna Taxa Juros
        /// <summary>
        /// Retorna Taxa de Juros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("taxaJuros")]
        public IActionResult RetornaTaxaJuros()
        {
            try
            {
                return Ok(_taxaJurosManager.RetornaTaxaJuros());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResultModel { Error = new ErrorModel { ErrorCode = "500", ErrorMessage = "Internal Server Error" } });
            }
        }
        #endregion
    }
}