using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public class OfertaSuperiorMaisProxima : IModalidadeAvalicao
    {
        public double valorItem { get; }

        public OfertaSuperiorMaisProxima(double valorItem)
        {
            this.valorItem = valorItem;
        }

        public Lance Avalia(Leilao leilao)
        {
            return leilao.Lances
                    .Where(w => w.Valor > valorItem)
                    .DefaultIfEmpty(new Lance(null, 0))
                    .OrderBy(ob => ob.Valor)
                    .FirstOrDefault();
        } 
    }
}