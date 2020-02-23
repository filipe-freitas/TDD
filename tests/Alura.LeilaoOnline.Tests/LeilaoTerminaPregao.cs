using Xunit;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(0, new double [] { })]
        public void SemLances(double valorEsperado, double[] valorLances){
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("fulano", leilao);
            foreach(var lance in valorLances){
                leilao.RecebeLance(fulano, lance);
            }

            //Act
            leilao.TerminaPregao();

            //Assert
            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);
        }

        [Theory]
        [InlineData(800, new double [] { 800 })]
        [InlineData(1000, new double [] { 800, 900, 1000 })]
        [InlineData(1000, new double [] { 800, 900, 1000, 950 })]
        public void ComLances(double valorEsperado, double[] valorLances){
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("fulano", leilao);
            foreach(var lance in valorLances){
                leilao.RecebeLance(fulano, lance);
            }

            //Act
            leilao.TerminaPregao();

            //Assert
            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);
        }
    }
}
