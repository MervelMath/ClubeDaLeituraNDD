using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaBase
    {
        private string titulo;

        public TelaBase(string titulo)
        {
            this.titulo = titulo;
        }

        public string Titulo { get { return titulo; } }

        internal string ObterOpcao()
        {

            Console.WriteLine("Digite 1 para inserir.");
            Console.WriteLine("Digite 2 para visualizar.");
            Console.WriteLine("Digite 3 para editar.");
            Console.WriteLine("Digite 4 para remover.");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public virtual void InserirNovoRegistro()
        {
        }

        public virtual void VisualizarRegistros()
        {
            
        }

        public virtual void EditarRegistro()
        {
            
        }

        public virtual void ExcluirRegistro()
        {
            
        }

        protected void ApresentarMensagem(string mensagem, TipoMensagem tm)
        {
            switch (tm)
            {
                case TipoMensagem.Sucesso:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case TipoMensagem.Atencao:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;

                case TipoMensagem.Erro:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                default:
                    break;
            }

            Console.WriteLine();
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }

        protected void ConfigurarTela(string subtitulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();

            Console.WriteLine(subtitulo);

            Console.WriteLine();
        }
    }
}
