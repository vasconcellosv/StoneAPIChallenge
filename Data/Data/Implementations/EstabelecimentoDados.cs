using DependencyInjectionSample.Data;
using DependencyInjectionSample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace APIChallenge
{
    public class EstabelecimentoDados : IEstabelecimentoDados
    {
        IDataBase dataBase;
        public EstabelecimentoDados(IDataBase dataBaseEstabelecimento)
        {
            this.dataBase = dataBaseEstabelecimento;
        }

        public void inserirEstabelecimento(Estabelecimento estabelecimento)
        {
            try
            {
                dataBase.inserirEstabelecimento(estabelecimento);
            }
            catch (DbUpdateException)
            {
                throw new ArgumentException();
            }
        }

        public Estabelecimento obterEstabelecimentoPorCnpj(string cnpj)
        {
            try
            {
                return dataBase.obterEstabelecimentoPorCnpj(cnpj);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Estabelecimento obterEstabelecimentoPorId(long id)
        {
            return dataBase.obterEstabelecimentoPorId(id);
        }

        public List<Estabelecimento> obterListaEstabelecimentos()
        {
            try
            {    
                return dataBase.obterListaEstabelecimentos();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public long obterMaxIdEstabelecimento()
        {
            return dataBase.obterMaxIdEstabelecimento()+1;
        }
    }
}
