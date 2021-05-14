using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Dominios;
namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaRevista : TelaBase
    {
        private TelaCaixa telaCaixa;
        private ControladorRevista controladorRevista;

        public TelaRevista(TelaCaixa tela, ControladorRevista controlador)
            : base("Cadastro de Revistas")
        {
            telaCaixa = tela;
            controladorRevista = controlador;
        }

        public override void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo uma nova revista...");

            GavarRevista(0);

        }

        public override void ExcluirRegistro()
        {
            ConfigurarTela("Emprestando revista...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da revista que deseja emprestar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuAlugar = controladorRevista.ExcluirRevista(idSelecionado);

            if (conseguiuAlugar)
                ApresentarMensagem("Revista alugada com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar alugar revista. Esta revista não está disponível", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }


        public override void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando revistas...");

            MontarCabecalhoTabela();

            Revista[] revistas = controladorRevista.SelecionarTodasRevistas();

            if (revistas.Length == 0)
            {
                ApresentarMensagem("Nenhum revista registrado!", TipoMensagem.Atencao);
                return;
            }

            foreach (Revista revista in revistas)
            {
                Console.WriteLine("{0,-10} | {1,-30} | {2,-55} | {3,-25} | {4,-25}",
                    revista.id, revista.caixa.cor, revista.anoRevista, revista.tipoColecao, revista.numeroEdicao);
            }
        }

        #region Métodos Privados
        private static void MontarCabecalhoTabela()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-30} | {2,-55} | {3,-25} | {4,-25}", "Id", "Caixa", "Ano da Revista", "Tipo da Coleção", "Número da Edição");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private void GavarRevista(int idRevistaSelecionada)
        {
            telaCaixa.VisualizarRegistros();

            Console.Write("Digite o Id da caixa que deseja giardá-la: ");
            int idCaixaRevista = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o tipo da coleção da revista: ");
            string tipo = Console.ReadLine();

            Console.Write("Digite o ano da revista: ");
            string ano = Console.ReadLine();

            Console.WriteLine("Digite o número da edição da revista");
            string nmr = Console.ReadLine();

            controladorRevista.
                RegistrarRevista(idRevistaSelecionada, idCaixaRevista, tipo, ano, nmr);

        }

        #endregion
    }
}
