using Microsoft.Extensions.DependencyInjection;
using System;
using TaxaJuros.Manager.Providers.TaxaJuros;
using TaxaJuros.Provider.TaxaJuros;
using Xunit;

namespace TaxaJuros.Test
{
    public class TaxaJurosTest
    {
        #region Propriedades
        private readonly ITaxaJurosProvider _taxaJurosProvider;
        private IServiceCollection services;
        private IServiceProvider serviceProvider;
        #endregion

        #region Construtor
        public TaxaJurosTest()
        {
            services = new ServiceCollection();
            services.AddTransient<ITaxaJurosProvider, TaxaJurosProvider>();
            serviceProvider = services.BuildServiceProvider();
            _taxaJurosProvider = serviceProvider.GetRequiredService<ITaxaJurosProvider>();
        }
        #endregion

        #region Test Valor Juros
        [Fact]
        public void ValorJuros()
        {
            var taxa = _taxaJurosProvider.RetornaTaxaJuros();

            Assert.Equal(0.01m, taxa);
        }
        #endregion
    }
}
