using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public class Leilao
    {
        public enum EstadoLeilao
        {
            Iniciado,
            EmAndamento,
            Finalizado
        }

        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao Estado { get; private set; }
        private Interessada _clienteAnterior = null;

        public Leilao(string peca)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilao.Iniciado;
        }

        public bool LanceValido(Interessada cliente, double valor)
        {
            return (cliente != _clienteAnterior) && (Estado == EstadoLeilao.EmAndamento);
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if (LanceValido(cliente, valor)){
                _lances.Add(new Lance(cliente, valor));
                _clienteAnterior = cliente;
            }
        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilao.EmAndamento;
        }

        public void TerminaPregao()
        {
            Ganhador = Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(ob => ob.Valor)
                .Last();
            
            Estado = EstadoLeilao.Finalizado;
        }
    }
}