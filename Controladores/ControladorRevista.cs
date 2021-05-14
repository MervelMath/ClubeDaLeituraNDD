using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Dominios;
namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorRevista : ControladorBase
    {
        private ControladorCaixa controladorCaixa;

        public ControladorRevista(ControladorCaixa controlador)
        {
            controladorCaixa = controlador;
        }

        public void RegistrarRevista(int id, int idCaixaRevista, string tipo, string ano, string nmr)
        {
            Revista revista = null;

            int posicao;

            if (id == 0)
            {
                revista = new Revista();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Revista(id));
                revista = (Revista)registros[posicao];
            }

            revista.caixa = controladorCaixa.SelecionarCaixaPorId(idCaixaRevista);
            revista.anoRevista = ano;
            revista.numeroEdicao = nmr;
            revista.tipoColecao = tipo;

            
                registros[posicao] = revista;

           
        }

        public bool ExcluirRevista(int idSelecionado)
        {
            return ExcluirRegistro(new Revista(idSelecionado));
        }


        public Revista[] SelecionarTodasRevistas()
        {
            Revista[] revistasAux = new Revista[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), revistasAux, revistasAux.Length);

            return revistasAux;
        }

        public Revista SelecionarRevistaPorId(int id)
        {
            return (Revista)SelecionarRegistroPorId(new Revista(id));
        }
        
    }
}
