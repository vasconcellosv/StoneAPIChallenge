using APIChallenge;
using System.Collections.Generic;

namespace DependencyInjectionSample.Models
{
    public interface IClienteDados
    {
        void inserirCliente(Cliente cliente);
        List<Cliente> obterListaClientes();
        Cliente obterClientePorId(long id);
    }
}