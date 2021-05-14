using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Dominios
{
    public class Amiguinho
    {
        public string nome;
        public string responsavel;
        public string telefone;
        public string localAmiguinho;
        public int id;
        public string status;

        public Amiguinho()
        {
            id = GeradorId.GerarIdAmiguinho();
        }

        public Amiguinho(int idSelecionado)
        {
            id = idSelecionado;
        }


        public override bool Equals(object obj)
        {
            Amiguinho amiguinho = (Amiguinho)obj;

            if (id == amiguinho.id)
                return true;
            else
                return false;
        }
    }
}
