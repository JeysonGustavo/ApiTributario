namespace CalculaJuros.Manager.Providers.CalculaJuros
{
    public interface ICalculaJurosProvider
    {
        /// <summary>
        /// Calcula Juros
        /// </summary>
        /// <param name="valorInicial">Valor inicial</param>
        /// <param name="taxa">Taxa de juros</param>
        /// <param name="tempo">Tempo em messes</param>
        /// <returns></returns>
        decimal CalculaJuros(decimal valorInicial, decimal taxa, int tempo);

        /// <summary>
        /// Retorna a URL do código fonte do projeto no GitHub
        /// </summary>
        /// <returns></returns>
        string ShowMeTheCode();
    }
}
