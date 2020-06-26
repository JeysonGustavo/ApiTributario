using CalculaJuros.Manager.Providers;
using CalculaJuros.Provider;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace CalculaJuros.Test
{
    public class CalculaJurosTest
    {
        #region Propriedades
        private readonly IJurosProvider _jurosProvider;
        private IServiceCollection services;
        private IServiceProvider serviceProvider;
        #endregion

        #region Construtor
        public CalculaJurosTest()
        {
            services = new ServiceCollection();
            services.AddTransient<IJurosProvider, JurosProvider>();
            serviceProvider = services.BuildServiceProvider();
            _jurosProvider = serviceProvider.GetRequiredService<IJurosProvider>();
        }
        #endregion

        #region Test Valor Juros
        [Fact]
        public void ValorJuros()
        {
            var taxa = _jurosProvider.RetornaTaxaJuros();

            Assert.Equal(0.01m, taxa);
        } 
        #endregion
    }
}
