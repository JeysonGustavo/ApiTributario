using System;
using System.Threading.Tasks;
using CalculaJuros.Manager.Managers.CalculaJuros;
using CalculaJuros.Manager.Models.Error;
using CalculaJuros.Manager.Models.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculaJuros.Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        #region Propriedades
        private readonly ICalculaJurosManager _calculaJurosManager;
        #endregion

        #region Construtor
        public CalculaJurosController([FromServices] ICalculaJurosManager calculaJurosManager)
        {
            _calculaJurosManager = calculaJurosManager;
        }
        #endregion

        #region Calcula Juros
        /// <summary>
        /// Calcula Juros
        /// </summary>
        /// <param name="valorinicial">Valor Inicial</param>
        /// <param name="meses">Tempo em meses</param>
        /// <returns></returns>
        [HttpGet]
        [Route("calculajuros")]
        public async Task<IActionResult> CalculaJuros([FromQuery] decimal valorinicial, [FromQuery] int meses)
        {
            try
            {
                return Ok(await _calculaJurosManager.CalculaJuros(valorinicial, meses));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResultModel { Error = new ErrorModel { ErrorCode = "500", ErrorMessage = "Internal Server Error" } });
            }
        }
        #endregion

        #region Show Me The Code
        /// <summary>
        /// Retorna a URL do código fonte do GitHub
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("showmethecode")]
        public IActionResult ShowMeTheCode()
        {
            try
            {
                return Ok(_calculaJurosManager.ShowMeTheCode());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResultModel { Error = new ErrorModel { ErrorCode = "500", ErrorMessage = "Internal Server Error" } });
            }
        }
        #endregion
    }
}