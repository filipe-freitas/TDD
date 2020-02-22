using System;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        public static void UmLance() {
            //Arrange
            var leilao = new Leilao("Van Gogh");

            var fulano = new Interessada("fulano", leilao);
            leilao.RecebeLance(fulano, 800);

            var maiorLance = 800;

            //Act
            leilao.TerminaPregao();

            //Assert
            Verifica(maiorLance, leilao.Ganhador.Valor);
        }

        public static void VariosLances() {
            //Arrange
            var leilao = new Leilao("Van Gogh");

            var fulano = new Interessada("fulano", leilao);
            var sicrano = new Interessada("sicrano", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(sicrano, 900);
            leilao.RecebeLance(fulano, 1200);
            leilao.RecebeLance(sicrano, 1800);
            leilao.RecebeLance(fulano, 1500);

            var maiorLance = 1800;

            //Act
            leilao.TerminaPregao();

            //Assert
            Verifica(maiorLance, leilao.Ganhador.Valor);
        }

        public static void Verifica (double esperado, double obtido) {
            var consoleColor = Console.ForegroundColor;
            if (obtido == esperado){
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success");
            }
            else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fail");
            }
            Console.ForegroundColor = consoleColor;
        }

        static void Main()
        {
            UmLance();
            VariosLances();
        }
    }
}
