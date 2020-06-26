using CalculaJuros.Manager.Models.Result;
using CalculaJuros.Manager.Providers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CalculaJuros.Manager.Managers
{
	public class JurosManager : IJurosManager
    {
		#region Propriedades
		private readonly IJurosProvider _jurosProvider;
		#endregion

		#region Construtor
		public JurosManager([FromServices]  IJurosProvider jurosProvider)
		{
			_jurosProvider = jurosProvider;
		} 
		#endregion

		#region Retorna Taxa Juros
		public ResultModel RetornaTaxaJuros()
		{
			try
			{
				var taxa = _jurosProvider.RetornaTaxaJuros();

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
