using APIChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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