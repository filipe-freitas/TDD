using Xunit;
using System.Linq;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Fact]
        public void NaoPermiteNovosLancesAposLeilaoFinalizado()
        {
            //Arrange
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("fulano", leilao);
            var beltrano = new Interessada("beltrano", leilao);
            var sicrano = new Interessada("sicrano", leilao);

            leilao.IniciaPregao();
            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(beltrano, 1000);
            leilao.RecebeLance(sicrano, 1200);
            leilao.TerminaPregao();
            
            //Act
            leilao.RecebeLance(fulano, 1900);

            //Assert
            Assert.Equal(3, leilao.Lances.Count());
        }

        [Theory]
        [InlineData(0, new double[] { 800 })]
        public void NaoPermiteLancesAntesIniciarPregao(int qtdLancesEsperados, double[] valorLances)
        {
            //Arrange
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("fulano", leilao);
            
            //Act
            foreach(var lance in valorLances){
                leilao.RecebeLance(fulano, lance);
            }
            leilao.IniciaPregao();
            leilao.TerminaPregao();

            //Assert
            Assert.Equal(qtdLancesEsperados, leilao.Lances.Count());
        }

        [Theory]
        [InlineData(1, new double[] { 800, 900 })]
        public void NaoPermiteLancesConsecutivosInteressados(int qtdLancesEsperados, double[] valorLances)
        {
            //Arrange
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("fulano", leilao);
            leilao.IniciaPregao();
            
            //Act
            foreach(var lance in valorLances){
                leilao.RecebeLance(fulano, lance);
            }
            leilao.TerminaPregao();

            //Assert
            Assert.Equal(qtdLancesEsperados, leilao.Lances.Count());
        }
    }
}