namespace TaxaJuros.Manager.Providers.TaxaJuros
{
    public interface ITaxaJurosProvider
    {
        /// <summary>
        /// Retorna a Taxa de Juros
        /// </summary>
        /// <returns></returns>
        decimal RetornaTaxaJuros();
    }
}
