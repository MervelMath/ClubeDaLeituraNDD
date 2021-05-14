using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Dominios
{
    public class Emprestimo
    {
        public Amiguinho amiguinho;
        public Revista revista;
        public DateTime dataEmprestimo;
        public DateTime dataDevolucao;
        public int id;

        public Emprestimo()
        {
            id = GeradorId.GerarIdEmprestimo();
        }

        public Emprestimo(int idSelecionado)
        {
            id = idSelecionado;
        }


        public override bool Equals(object obj)
        {
            Emprestimo emprestimo = (Emprestimo)obj;

            if (id == emprestimo.id)
                return true;
            else
                return false;
        }
    }
}
