using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    class GeradorId
    {
        public static int idCaixa = 0;
        public static int idRevista = 0;
        public static int idAmiguinho = 0;
        public static int idEmprestimo = 0;
        public static int GerarIdCaixa()
        {
            return ++idCaixa;
        }

        public static int GerarIdRevista()
        {
            return ++idRevista;
        }

        public static int GerarIdAmiguinho()
        {
            return ++idAmiguinho;
        }

        public static int GerarIdEmprestimo()
        {
            return ++idEmprestimo;
        }
    }
}
