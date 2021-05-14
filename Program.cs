using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Telas;
namespace ClubeDaLeitura.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            

            ControladorAmiguinho ctrlAmiguinho = new ControladorAmiguinho();

            ControladorCaixa controladorCaixa = new ControladorCaixa();


            ControladorRevista controladorRevista = new ControladorRevista(controladorCaixa);

            ControladorEmprestimo controladorEmprestimo = new ControladorEmprestimo(ctrlAmiguinho, controladorRevista);

            TelaCaixa telaCaixa = new TelaCaixa(controladorCaixa);
            TelaAmiguinho telaAmiguinho = new TelaAmiguinho(ctrlAmiguinho);
            TelaRevista telaRevista = new TelaRevista(telaCaixa, controladorRevista);


            TelaPrincipal telaPrincipal = new TelaPrincipal(controladorRevista, ctrlAmiguinho, controladorEmprestimo, controladorCaixa, telaCaixa, telaRevista, telaAmiguinho);


            while (true)
            {
                TelaBase telaSelecionada = telaPrincipal.ObterOpcao();

                if (telaSelecionada == null)
                    break;

                Console.Clear();

                if (telaSelecionada is TelaBase)
                    Console.WriteLine(((TelaBase)telaSelecionada).Titulo); Console.WriteLine();

                string opcao = telaSelecionada.ObterOpcao();

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (opcao == "1")
                    telaSelecionada.InserirNovoRegistro();

                else if (opcao == "2")
                {
                    telaSelecionada.VisualizarRegistros();
                    Console.ReadLine();
                }

                else if (opcao == "3")
                    telaSelecionada.EditarRegistro();

                else if (opcao == "4")
                    telaSelecionada.ExcluirRegistro();

                Console.Clear();
            }
        }
    }
}
