using APIChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionSample.Models
{
    public interface IPagamentoDados
    {
        void inserirPagamento(Pagamento pagamento);
        List<Pagamento> obterListaPagamentosPorEstabelecimento(long idEstabelecimento);
        Pagamento obterPagamentoPorId(long id);
        void cancelarPagamento(long id);
        long obterMaxIdPagamento();
    }
}