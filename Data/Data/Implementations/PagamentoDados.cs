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
            //Valida se existe um pagamento com o id recebido
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
            //Valida se o Cliente e o Estabelecimento existem e que não exista um Pagamento com o id recebido
            if (dataBase.obterClientePorId(pagamento.IdCliente) != null && dataBase.obterEstabelecimentoPorId(pagamento.IdEstabelecimento) != null && dataBase.obterPagamentoPorId(pagamento.Id) == null)
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
            else
            {
                throw new Exception();
            }
        }

        public List<Pagamento> obterListaPagamentosPorEstabelecimento(long idEstabelecimento)
        {
            try
            {
                return dataBase.obterListaPagamentosPorEstabelecimento(idEstabelecimento);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Pagamento obterPagamentoPorId(long id)
        {
            try
            {
                return dataBase.obterPagamentoPorId(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public long obterMaxIdPagamento()
        {
            return dataBase.obterMaxIdPagamento() + 1;
        }
    }
}
