using DependencyInjectionSample.Interfaces;
using DependencyInjectionSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIChallenge
{
    public class ServicosDePagamento : IServicosDePagamento
    {
        IPagamentoDados pagamentoDados;
        public ServicosDePagamento(IPagamentoDados pagamentoDados)
        {
            this.pagamentoDados = pagamentoDados;
        }

        public void cancelarPagamento(long id, Pagamento pagamento)
        {
            try
            {
                //Busca o pagamento pelo id e valida se o Cliente que está cancelando é o Cliente que realizou o pagamento
                if (pagamentoDados.obterPagamentoPorId(id).Cliente.Id == pagamento.Cliente.Id)
                {
                    //Cancela o pagamento
                    pagamentoDados.cancelarPagamento(id);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (ArgumentException)
            {
                throw new ArgumentException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        
        public void inserirPagamento(Pagamento pagamento)
        {
            //Valida se o Cliente e o Estabelecimento foram informados, se foi passada uma data e se o valor do Pagamento é válido
            if (pagamento.Valor > 0 && !pagamento.Data.Equals(DateTime.MinValue) && pagamento.Cliente.Id != 0 && pagamento.Estabelecimento.Id != 0)
            {
                //Caso não tenho sido informado o id do Pagamento
                if (pagamento.Id == 0)
                {
                    //Um id válido é associado ao Pagamento
                    pagamento.Id = pagamentoDados.obterMaxIdPagamento();
                }
                //O Pagamento é inserido
                pagamentoDados.inserirPagamento(pagamento);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public List<Pagamento> obterListaPagamentosPorEstabelecimento(long idEstabelecimento)
        {
            return pagamentoDados.obterListaPagamentosPorEstabelecimento(idEstabelecimento);
        }
    }
}
