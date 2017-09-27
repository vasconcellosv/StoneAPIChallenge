using APIChallenge;
using System.Collections.Generic;

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