using System;
using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Dominios;
namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaAmiguinho : TelaBase
    {
        private ControladorAmiguinho controladorAmiguinho;
        public TelaAmiguinho(ControladorAmiguinho controlador)
            : base("Cadastro de Amiguinho")
        {
            controladorAmiguinho = controlador;
        }

        public override void InserirNovoRegistro()
        {
            ConfigurarTela("Registrando um novo amiguinho...");

            GravarAmiguinho(0);

            Console.WriteLine("Amiguinho registrado.");

        }

        public override void EditarRegistro()
        {
            ConfigurarTela("Editando amiguinho...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do amiguinho que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            GravarAmiguinho(id);

            Console.WriteLine("Amiguinho inserido.");
        }


        public override void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando amiguinhos...");

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35} | {3, -35} | {4,-20}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Amiguinho[] amigos = controladorAmiguinho.SelecionarTodasAmiguinhos();

            if (amigos.Length == 0)
            {
                ApresentarMensagem("Nenhum amiguinho cadastrado!", TipoMensagem.Atencao);
                InserirNovoRegistro();
                VisualizarRegistros();
                return;
            }

            for (int i = 0; i < amigos.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   amigos[i].id, amigos[i].nome, amigos[i].telefone, amigos[i].responsavel, amigos[i].localAmiguinho);
            }
        }


        #region métodos privados
        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "nome", "telefone", "responsável", "Endereço");

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private void GravarAmiguinho(int id)
        {
            Console.Write("Digite o nome do amiguiho: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do bairro dele: ");
            string endereco = Console.ReadLine();

            Console.Write("Digite o teledone: ");
            string telefone = Console.ReadLine();

            Console.WriteLine("Digite o nome do responsável dele: ");
            string nomeResp = Console.ReadLine();

            controladorAmiguinho.RegistrarAmiguinho(id, nome, nomeResp, telefone, endereco);
        }



        #endregion
    }
}
