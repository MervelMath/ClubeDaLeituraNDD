using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Dominios
{
    public class Revista
    {
        public string tipoColecao;
        public string numeroEdicao;
        public string anoRevista;
        public Caixa caixa;
        public int id;
        public string status;
        public Revista()
        {
            id = GeradorId.GerarIdRevista();
        }

        public Revista(int idSelecionado)
        {
            id = idSelecionado;
        }


        public override bool Equals(object obj)
        {
            Revista revista = (Revista)obj;

            if (id == revista.id)
                return true;
            else
                return false;
        }
        

    }
}
