using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Dominios;
namespace ClubeDaLeitura.ConsoleApp.Controladores
{

    public class ControladorEmprestimo : ControladorBase
    {
        ControladorAmiguinho controladorAmiguinho;
        ControladorRevista controladorRevista;
        private int idAmigo;
        private int idRevista;
        public ControladorEmprestimo(ControladorAmiguinho controladorAmiguinho, ControladorRevista controladorRevista)
        {
            this.controladorAmiguinho = controladorAmiguinho;
            this.controladorRevista = controladorRevista;
        }

        public void RegistrarEmprestimo(int id, int idRevistaEmprestimo, int idAmiguinhoEmprestimo, DateTime dataEmprestimo, DateTime dataDevolucao)
        {
            idAmigo = idAmiguinhoEmprestimo;
            idRevista = idRevistaEmprestimo;

            Emprestimo emprestimo = null;

            int posicao;

            if (id == 0)
            {
                emprestimo = new Emprestimo();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Emprestimo(id));
                emprestimo = (Emprestimo)registros[posicao];
            }

            emprestimo.amiguinho = controladorAmiguinho.SelecionarAmiguinhoPorId(idAmiguinhoEmprestimo);
            emprestimo.revista = controladorRevista.SelecionarRevistaPorId(idRevistaEmprestimo);
            emprestimo.dataEmprestimo = dataEmprestimo;
            emprestimo.dataDevolucao = dataDevolucao;
            controladorRevista.SelecionarRevistaPorId(idRevistaEmprestimo).status = "alugada";
            controladorAmiguinho.SelecionarAmiguinhoPorId(idAmiguinhoEmprestimo).status = "alugada";

            registros[posicao] = emprestimo;


        }

        public bool ExcluirEmprestimo(int idSelecionado)
        {
            controladorRevista.SelecionarRevistaPorId(idRevista).status = "";
            controladorAmiguinho.SelecionarAmiguinhoPorId(idAmigo).status = "";

            return ExcluirRegistro(new Emprestimo(idSelecionado));
        }

        public Emprestimo[] SelecionarTodosEmprestimos()
        {
            Emprestimo[] emprestimoAux = new Emprestimo[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), emprestimoAux, emprestimoAux.Length);

            return emprestimoAux;
        }

        public Emprestimo SelecionarRevistaPorId(int id)
        {
            return (Emprestimo)SelecionarRegistroPorId(new Emprestimo(id));
        }
    }
}
