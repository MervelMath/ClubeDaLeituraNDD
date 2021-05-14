using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Dominios
{
    public class Caixa
    {
        public int id;
        public string cor;
        public string etiqueta;
        public string numero;

        public Caixa()
        {
            id = GeradorId.GerarIdCaixa();
        }

        public Caixa(int idSelecionado)
        {
            id = idSelecionado;
        }


        public override bool Equals(object obj)
        {
            Caixa caixa = (Caixa)obj;

            if (id == caixa.id)
                return true;
            else
                return false;
        }

    }
}
