using Xunit;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(0, new double [] { })]
        public void SemLances(double valorEsperado, double[] valorLances)
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("fulano", leilao);

            leilao.IniciaPregao();
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
        public void ComLances(double valorEsperado, double[] valorLances)
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("fulano", leilao);
            var beltrano = new Interessada("beltrano", leilao);

            leilao.IniciaPregao();
            for (int i = 0; i < valorLances.Length; i++)
            {
                var lance = valorLances[i];
                if (i % 2 == 0)
                    leilao.RecebeLance(fulano, lance);
                else
                    leilao.RecebeLance(beltrano, lance);
            }

            //Act
            leilao.TerminaPregao();

            //Assert
            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);
        }

        [Fact]
        public void SemInicioPregao()
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("fulano", leilao);

            leilao.RecebeLance(fulano, 300);

            //Assert
            Assert.Throws<System.InvalidOperationException>(
                //Act
                () => leilao.TerminaPregao()
            );
        }
    }
}