using APIChallenge.Data.Data;
using DependencyInjectionSample.Data;
using DependencyInjectionSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIChallenge
{
    public class PagamentoDados : IPagamentoDados
    {
        IDataBase dataBase;
        public PagamentoDados(IDataBase dataBasePagamento)
        {
            this.dataBase = dataBasePagamento;
        }

        public void cancelarPagamento(long id)
        {
            try
            {
                dataBase.apagarPagamento(id);
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
        }

        public void inserirPagamento(Pagamento pagamento)
        {
          
            try
             {
                 dataBase.inserirPagamento(pagamento);
             }
             catch (Exception)
             {
                 throw new Exception();
             }
        }

        public List<Pagamento> obterListaPagamentosPorEstabelecimento(long idEstabelecimento)
        {
            return dataBase.obterListaPagamentosPorEstabelecimento(idEstabelecimento);
        }

        public Pagamento obterPagamentoPorId(long id)
        {
            return dataBase.obterPagamentoPorId(id);
        }

        public long obterMaxIdPagamento()
        {
            return dataBase.obterMaxIdPagamento() + 1;
        }
    }
}
