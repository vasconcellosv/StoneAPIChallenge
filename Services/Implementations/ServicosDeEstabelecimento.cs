using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System;
using DependencyInjectionSample.Interfaces;
using DependencyInjectionSample.Models;

namespace APIChallenge
{
    public class ServicosDeEstabelecimento : IServicosDeEstabelecimento
    {
        IEstabelecimentoDados estabelecimentoDados;
        public ServicosDeEstabelecimento(IEstabelecimentoDados estabelecimentoDados)
        {
            this.estabelecimentoDados = estabelecimentoDados;
        }

        public void inserirEstabelecimento(string cnpj)
        {
            //Buscar o Estabelecimento no banco por seu CNPJ. Caso exista, o Estabelecimento já está cadastrado
            if (estabelecimentoDados.obterEstabelecimentoPorCnpj(cnpj) == null)
            {
                Estabelecimento estabelecimento;
                try
                {
                    //Recupera as informações do Estabelecimento junto a receitaws através do CNPJ
                    estabelecimento = ReceitaUtils.obterEstabelecimentoReceita(cnpj);
                }
                catch (Exception)
                {
                    throw new WebException();
                }
                //Obtem o id que deverá ser associado ao novo Estabelecimento
                estabelecimento.Id = estabelecimentoDados.obterMaxIdEstabelecimento();
                //Cadastra o Estabelecimento no banco
                estabelecimentoDados.inserirEstabelecimento(estabelecimento);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public Estabelecimento obterEstabelecimentoPorId(long id)
        {
            return estabelecimentoDados.obterEstabelecimentoPorId(id);
        }

        public List<Estabelecimento> obterListaEstabelecimentos()
        {
            return estabelecimentoDados.obterListaEstabelecimentos();
        }
    }
}
