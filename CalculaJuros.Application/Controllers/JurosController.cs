using System;
using CalculaJuros.Manager.Managers;
using CalculaJuros.Manager.Models.Error;
using CalculaJuros.Manager.Models.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculaJuros.Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JurosController : ControllerBase
    {
        #region Propriedades
        private readonly IJurosManager _jurosManager;
        #endregion

        #region Construtor
        public JurosController([FromServices] IJurosManager jurosManager)
        {
            _jurosManager = jurosManager;
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
                return Ok(_jurosManager.RetornaTaxaJuros());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResultModel { Error = new ErrorModel { ErrorCode = "500", ErrorMessage = "Internal Server Error" } });
            }
        } 
        #endregion
    }
}