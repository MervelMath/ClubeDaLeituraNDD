using System;
using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Dominios;
namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaCaixa : TelaBase
    {
        private ControladorCaixa controladorCaixa;
        public TelaCaixa(ControladorCaixa controlador)
            : base("Cadastro de Caixa")
        {
            controladorCaixa = controlador;
        }

        public override void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo uma nova caixa de revistas");

            GravarCaixa(0);

            Console.WriteLine("Caixa inserida.");

        }

        public override void EditarRegistro()
        {
            ConfigurarTela("Editando caixa...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da caixa que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            GravarCaixa(id);

            Console.WriteLine("Caixa inserida.");
        }
        

        public override void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando caixas...");

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35} | {3, -35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Caixa[] caixas = controladorCaixa.SelecionarTodasCaixas();

            if (caixas.Length == 0)
            {
                ApresentarMensagem("Nenhuma caixa cadastrado!", TipoMensagem.Atencao);
                InserirNovoRegistro();
                VisualizarRegistros();
                return;
            }

            for (int i = 0; i < caixas.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   caixas[i].id, caixas[i].cor, caixas[i].numero, caixas[i].etiqueta);
            }
        }

        #region métodos privados
        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "cor", "número", "etiqueta");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private void GravarCaixa(int id)
        {
            Console.Write("Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.Write("Digite a etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();

            Console.Write("Digite o número da caixa: ");
            string numero = Console.ReadLine();

            controladorCaixa.RegistrarCaixa(id, cor, etiqueta, numero);
        }



        #endregion
    }
}
