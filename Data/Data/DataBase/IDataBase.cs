using APIChallenge;
using System.Collections.Generic;

namespace DependencyInjectionSample.Data
{
    public interface IDataBase
    {
        List<Cliente> obterListaClientes();
        List<Estabelecimento> obterListaEstabelecimentos();
        List<Pagamento> obterListaPagamentos();
        void apagarCliente(long id);
        void apagarPagamento(long id);
        void inserirCliente(Cliente cliente);
        void inserirEstabelecimento(Estabelecimento estabelecimento);
        void inserirPagamento(Pagamento pagamento);
        Cliente obterClientePorId(long id);
        Estabelecimento obterEstabelecimentoPorId(long id);
        Estabelecimento obterEstabelecimentoPorCnpj(string cnpj);
        Pagamento obterPagamentoPorId(long id);
        List<Pagamento> obterListaPagamentosPorEstabelecimento(long idEstabelecimento);
        long obterMaxIdEstabelecimento();
        long obterMaxIdPagamento();
    }
}
