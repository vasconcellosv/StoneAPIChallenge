using APIChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionSample.Interfaces
{
    public interface IServicosDePagamento
    {
        /// <summary>
        /// Método responsável por obter o histórico de Pagamentos realizados em um determinado Estabelecimento
        /// </summary>
        /// <param name="idEstabelecimento"></param>
        /// <returns></returns>
        List<Pagamento> obterListaPagamentosPorEstabelecimento(long idEstabelecimento);
        /// <summary>
        /// Método responsável por cancelar um pagamento feito por um Cliente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pagamento"></param>
        void cancelarPagamento(long id, Pagamento pagamento);
        /// <summary>
        /// Método responsável por validar e realizar um pagamento
        /// </summary>
        /// <param name="pagamento"></param>
        void inserirPagamento(Pagamento pagamento);
    }
}
