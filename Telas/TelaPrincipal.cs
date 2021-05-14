using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Controladores;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaPrincipal
    {
        private readonly TelaCaixa telaCaixa;
        private readonly TelaRevista telaRevista;
        private readonly TelaAmiguinho telaAmiguinho;
        private readonly ControladorRevista controladorRevista;
        private readonly ControladorAmiguinho controladorAmiguinho;
        private readonly ControladorEmprestimo controladorEmprestimo;
        private readonly ControladorCaixa controladorCaixa;

        public TelaPrincipal(ControladorRevista controladorRevista, ControladorAmiguinho controladorAmiguinho, ControladorEmprestimo controladorEmprestimo, ControladorCaixa controladorCaixa, TelaCaixa telaCaixa, TelaRevista telaRevista, TelaAmiguinho telaAmiguinho)
        {
            this.controladorRevista = controladorRevista;
            this.controladorAmiguinho = controladorAmiguinho;
            this.controladorEmprestimo = controladorEmprestimo;
            this.controladorCaixa = controladorCaixa;
            this.telaCaixa = telaCaixa;
            this.telaRevista = telaRevista;
            this.telaAmiguinho = telaAmiguinho;
        }

        public TelaBase ObterOpcao()
        {
            TelaBase telaSelecionada = null;

            string opcao;

            do
            {
                Console.WriteLine("Digite 1 para controle de caixas");
                Console.WriteLine("Digite 2 para controle de revistas");
                Console.WriteLine("Digite 3 para controle de Amiguinhos");
                Console.WriteLine("Digite 4 para controle de emprestimos");

                Console.WriteLine("Digite S para sair");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        telaSelecionada = new TelaCaixa(controladorCaixa);
                        break;

                    case "2":
                        telaSelecionada = new TelaRevista(telaCaixa, controladorRevista);
                        break;
                  
                    case "3":
                        telaSelecionada = new TelaAmiguinho(controladorAmiguinho);
                        break;
                  
                    case "4":
                        telaSelecionada = new TelaEmprestimo(telaRevista, telaAmiguinho, controladorEmprestimo, controladorRevista, controladorAmiguinho);
                        break;
                        
                }

                if (opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                    telaSelecionada = null;
                

            } while (opcaoInvalida(opcao));

            return telaSelecionada;
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
