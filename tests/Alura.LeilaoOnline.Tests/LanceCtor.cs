using Xunit;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void NaoPermiteLancesNegativos()
        {
            //Arrange
            var lanceNegativo = -120;

            //Assert
            Assert.Throws<System.ArgumentException>(
                //Act
                () => new Lance(null, lanceNegativo)
            );
        }
    }
}