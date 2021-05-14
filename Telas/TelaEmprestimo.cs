using System;
using ClubeDaLeitura.ConsoleApp.Telas;
using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Dominios;
namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaEmprestimo : TelaBase
    {
        private TelaRevista telaRevista;
        private TelaAmiguinho telaAmiguinho;
        private ControladorEmprestimo controladorEmprestimo;
        private ControladorRevista controladorRevista;
        private ControladorAmiguinho controladorAmiguinho;

        public TelaEmprestimo(TelaRevista telaRevista, TelaAmiguinho telaAmiguinho, ControladorEmprestimo controladorEmprestimo, ControladorRevista controladorRevista, ControladorAmiguinho controladorAmiguinho)
            : base("Empréstimo de Revistas")
        {
            this.telaRevista = telaRevista;
            this.telaAmiguinho = telaAmiguinho;
            this.controladorEmprestimo = controladorEmprestimo;
            this.controladorRevista = controladorRevista;
            this.controladorAmiguinho = controladorAmiguinho;
        }

        public override void InserirNovoRegistro()
        {
            ConfigurarTela("Registrando um novo empréstimo...");

            GravarEmprestimo(0);

        }

        public override void ExcluirRegistro()
        {
            ConfigurarTela("Devolvendo revista...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do empréstimo que deseja remover: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());


            bool conseguiuExcluir = controladorEmprestimo.ExcluirEmprestimo(idSelecionado); //preciso de um controlador revist aqui.
            

            if (conseguiuExcluir)
                ApresentarMensagem("Revista devolvida com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar devolver revista. Esta revista não foi alugada.", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }


        public override void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando empréstimos...");

            MontarCabecalhoTabela();

            Emprestimo[] emprestimos = controladorEmprestimo.SelecionarTodosEmprestimos();

            if (emprestimos.Length == 0)
            {
                ApresentarMensagem("Nenhum emprestimo registrado!", TipoMensagem.Atencao);
                return;
            }

            Console.WriteLine("Empréstimos do mês...");

            foreach (Emprestimo emprestimo in emprestimos)
            {
                if (emprestimo.dataEmprestimo.Month == DateTime.Now.Month)
                {
                    Console.WriteLine("{0,-10} | {1,-30} | {2,-55} | {3,-25} | {4,-25}",
                        emprestimo.id, emprestimo.revista.id, emprestimo.amiguinho.id, emprestimo.dataEmprestimo, emprestimo.dataDevolucao);
                }
            }

            Console.ReadLine();
            Console.WriteLine("Empréstimos de hoje...");

            foreach (Emprestimo emprestimo in emprestimos)
            {
                if (emprestimo.dataEmprestimo.Day == DateTime.Now.Day)
                {
                    Console.WriteLine("{0,-10} | {1,-30} | {2,-55} | {3,-25} | {4,-25}",
                        emprestimo.id, emprestimo.revista.id, emprestimo.amiguinho.id, emprestimo.dataEmprestimo, emprestimo.dataDevolucao);
                }
            }
        }

        #region Métodos Privados
        private static void MontarCabecalhoTabela()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-30} | {2,-55} | {3,-25} | {4,-25}", "Id Empréstimo", "Id Revista", "Id Amiguinho", "Data Empréstimo", "Data Devolução");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private void GravarEmprestimo(int idEmprestimoSelecionado)
        {
            telaAmiguinho.VisualizarRegistros();

            Console.Write("Digite o Id do amiguinho que deseja pegar um livro emprestado: ");
            int idAmiguinhoEmprestimo = Convert.ToInt32(Console.ReadLine());

            if (controladorAmiguinho.SelecionarAmiguinhoPorId(idAmiguinhoEmprestimo).status == "alugada")
            {
                Console.WriteLine("Amiguinho está com uma revista");
                Console.ReadLine();
                Console.Clear();
                GravarEmprestimo(idEmprestimoSelecionado);
            }


            telaRevista.VisualizarRegistros();

            Console.Write("Digite o Id da revista, que o amiguinho que deseja pegar um livro emprestado: ");
            int idRevistaEmprestimo = Convert.ToInt32(Console.ReadLine());
            if(controladorRevista.SelecionarRevistaPorId(idRevistaEmprestimo).status == "alugada")
            {
                Console.WriteLine("Revista já alugada");
                Console.ReadLine();
                Console.Clear();
                GravarEmprestimo(idEmprestimoSelecionado);
            }
            Console.Write("Digite a data de devolução: ");
            DateTime dataDevolucao = DateTime.Parse(Console.ReadLine());

            controladorEmprestimo.
                RegistrarEmprestimo(idEmprestimoSelecionado, idRevistaEmprestimo, idAmiguinhoEmprestimo, DateTime.Now, dataDevolucao);

        }

        #endregion
    }
}
