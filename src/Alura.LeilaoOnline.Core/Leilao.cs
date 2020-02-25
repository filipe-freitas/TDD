using System.Collections.Generic;

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
        private IModalidadeAvalicao _avaliador;
        private Interessada _clienteAnterior = null;

        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao Estado { get; private set; }

        public Leilao(string peca, IModalidadeAvalicao avaliador)
        {
            Peca = peca;
            _lances = new List<Lance>();
            _avaliador = avaliador;
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
            if (Estado != EstadoLeilao.EmAndamento){
                throw new System.InvalidOperationException();
            }

            Ganhador = _avaliador.Avalia(this);
            
            Estado = EstadoLeilao.Finalizado;
        }
    }
}