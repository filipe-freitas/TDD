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
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("fulano", leilao);
            var beltrano = new Interessada("beltrano", leilao);
            var sicrano = new Interessada("sicrano", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(beltrano, 1000);
            leilao.RecebeLance(sicrano, 1200);
            leilao.TerminaPregao();
            
            //Act
            leilao.RecebeLance(fulano, 1900);

            //Assert
            Assert.Equal(3, leilao.Lances.Count());
        }

    }
}