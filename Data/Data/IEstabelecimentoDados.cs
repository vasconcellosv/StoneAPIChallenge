using APIChallenge;
using System.Collections.Generic;

namespace DependencyInjectionSample.Models
{
    public interface IEstabelecimentoDados
    {
        List<Estabelecimento> obterListaEstabelecimentos();
        Estabelecimento obterEstabelecimentoPorId(long id);
        Estabelecimento obterEstabelecimentoPorCnpj(string cnpj);
        long obterMaxIdEstabelecimento();
        void inserirEstabelecimento(Estabelecimento estabelecimento);
    }
}