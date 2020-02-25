using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public class MaiorValor : IModalidadeAvalicao
    {
        public Lance Avalia(Leilao leilao){
            return leilao.Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(ob => ob.Valor)
                .LastOrDefault();
        }
    }
}