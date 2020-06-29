using CalculaJuros.Manager.Providers.CalculaJuros;
using System;

namespace CalculaJuros.Provider.CalculaJuros
{
    public class CalculaJurosProvider : ICalculaJurosProvider
    {
        #region Calcula Juros
        public decimal CalculaJuros(decimal valorInicial, decimal taxa, int tempo)
        {
            var valorFinal = decimal.ToDouble(valorInicial) * Math.Pow((1 + decimal.ToDouble(taxa)), tempo);

            return (decimal)Math.Truncate(100 * valorFinal) / 100;
        }
        #endregion

        #region Show Me The Code
        public string ShowMeTheCode()
        {
            return "https://github.com/JeysonGustavo/ApiTributario";
        }
        #endregion
    }
}
