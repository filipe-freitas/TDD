using System;
using Xunit;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTestes
    {
        [Fact]
        public void umLance() 
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");

            var fulano = new Interessada("fulano", leilao);
            leilao.RecebeLance(fulano, 800);

            var maiorLance = 800;

            //Act
            leilao.TerminaPregao();

            //Assert
            Assert.Equal(maiorLance, leilao.Ganhador.Valor);
        }

        [Fact]
        public void variosLances()
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");

            var fulano = new Interessada("fulano", leilao);
            leilao.RecebeLance(fulano, 800);

            var maiorLance = 800;

            //Act
            leilao.TerminaPregao();

            //Assert
            Assert.Equal(maiorLance, leilao.Ganhador.Valor);
        }
    }
}
