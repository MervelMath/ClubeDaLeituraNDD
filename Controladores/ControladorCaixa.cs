using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Dominios;
namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorCaixa : ControladorBase
    {
        public void RegistrarCaixa(int id, string cor, string etiqueta, string numero)
        {
            Caixa caixa = null;
            int posicao;

            if (id == 0)
            {
                caixa = new Caixa();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Caixa(id));
                caixa = (Caixa)registros[posicao];
            }

            caixa.cor = cor;
            caixa.numero = numero;
            caixa.etiqueta = etiqueta;

            registros[posicao] = caixa;

        }


        public  Caixa SelecionarCaixaPorId(int id)
        {
            return (Caixa)SelecionarRegistroPorId(new Caixa(id));
        }

        public bool ExcluirCaixa(int idSelecionado)
        {
            return ExcluirRegistro(new Caixa(idSelecionado));
        }

        public Caixa[] SelecionarTodasCaixas()
        {
            Caixa[] caixaAux = new Caixa[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), caixaAux, caixaAux.Length);

            return caixaAux;
        }
    }
}
