using CalculaJuros.Manager.Providers.CalculaJuros;
using CalculaJuros.Provider.CalculaJuros;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace CalculaJuros.Test
{
    public class CalculaJurosTest
    {
        #region Propriedades
        private readonly ICalculaJurosProvider _calculaJurosProvider;
        private IServiceCollection services;
        private IServiceProvider serviceProvider;
        #endregion

        #region Construtor
        public CalculaJurosTest()
        {
            services = new ServiceCollection();
            services.AddTransient<ICalculaJurosProvider, CalculaJurosProvider>();
            serviceProvider = services.BuildServiceProvider();
            _calculaJurosProvider = serviceProvider.GetRequiredService<ICalculaJurosProvider>();
        }
        #endregion

        #region Show Me The Code
        [Fact]
        public void ShowMeTheCode()
        {
            var retorno = _calculaJurosProvider.ShowMeTheCode();

            Assert.False(string.IsNullOrEmpty(retorno));
        }
        #endregion
    }
}
