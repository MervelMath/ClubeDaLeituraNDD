using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Controladores;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    class TelaPrincipal
    {

        public TelaBase ObterOpcao()
        {
            TelaBase telaSelecionada = null;

            string opcao;

            do
            {
                Console.WriteLine("Digite 1 para controle de caixas");
                Console.WriteLine("Digite 2 para controle de revistas");
                Console.WriteLine("Digite 3 para controle de Amigos");
                Console.WriteLine("Digite 4 para controle de emprestimos");

                Console.WriteLine("Digite S para sair");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        telaSelecionada = new TelaCaixa();
                        break;

                    case "2":
                        telaSelecionada = new TelaRevista();
                        break;

                    case "3":
                        telaSelecionada = new TelaAmiguinho();
                        break;

                    case "4":
                        telaSelecionada = new TelaEmprestimo();
                        break;

                    case "5":
                        telaSelecionada = null;
                        break;
                }



            } while (opcaoInvalida(opcao));
        }

        private bool opcaoInvalida(string opcao)
        {
            if (opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Opção inválida");
                Console.ReadLine();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
