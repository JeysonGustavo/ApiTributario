namespace CalculaJuros.Manager.Providers
{
    public interface IJurosProvider
    {
        /// <summary>
        /// Retorna a Taxa de Juros
        /// </summary>
        /// <returns></returns>
        decimal RetornaTaxaJuros();
    }
}
