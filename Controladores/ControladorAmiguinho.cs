using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Dominios;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorAmiguinho : ControladorBase
    {
      // nome;
      // responsavel;
      // telefone;
      // localAmiguinho;
        public void RegistrarAmiguinho(int id, string nome, string reponsavel, string telefone, string localAmiguinho)
        {
            Amiguinho amiguinho = null;
            int posicao;

            if (id == 0)
            {
                amiguinho = new Amiguinho();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Amiguinho(id));
                amiguinho = (Amiguinho)registros[posicao];
            }

            amiguinho.localAmiguinho = localAmiguinho;
            amiguinho.telefone = telefone;
            amiguinho.responsavel = reponsavel;
            amiguinho.nome = nome;

            registros[posicao] = amiguinho;

        }


        public Amiguinho SelecionarAmiguinhoPorId(int id)
        {
            return (Amiguinho)SelecionarRegistroPorId(new Amiguinho(id));
        }

        public bool ExcluirAmiguinho(int idSelecionado)
        {
            return ExcluirRegistro(new Amiguinho(idSelecionado));
        }

        public Amiguinho[] SelecionarTodasAmiguinhos()
        {
            Amiguinho[] amiguinhoAux = new Amiguinho[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), amiguinhoAux, amiguinhoAux.Length);

            return amiguinhoAux;
        }
    }
}
