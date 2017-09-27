using APIChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionSample.Interfaces
{
    public interface IServicosDeEstabelecimento
    {
        /// <summary>
        /// Método responsável por obter a lista de Estabelecimentos cadastrados
        /// </summary>
        /// <returns></returns>
        List<Estabelecimento> obterListaEstabelecimentos();
        /// <summary>
        /// Método responsável por obter um Estabelecimento por seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Estabelecimento obterEstabelecimentoPorId(long id);
        /// <summary>
        /// Método responsável por validar e cadastrar um Estabelecimento por seu CNPJ recuperando as informações da API receitaws
        /// </summary>
        /// <param name="cnpj"></param>
        void inserirEstabelecimento(string cnpj);
    }
}
