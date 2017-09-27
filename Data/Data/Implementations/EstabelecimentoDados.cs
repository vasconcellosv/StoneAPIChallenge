using APIChallenge.Data.Data;
using DependencyInjectionSample.Data;
using DependencyInjectionSample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            //Valida se já existe um Estabelecimento com o mesmo id
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
            //Busca um Estabelecimento por seu CNPJ
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
