using APIChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionSample.Interfaces
{
    public interface IServicosDeCliente
    {
        /// <summary>
        /// Método responsável por obter a lista de Clientes cadastrados
        /// </summary>
        /// <returns></returns>
        List<Cliente> obterListaClientes();
        /// <summary>
        /// Método responsável por obter um Cliente por seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Cliente obterClientePorId(long id);
        /// <summary>
        /// Método responsável por validar os dados e inserir um Cliente
        /// </summary>
        /// <param name="cliente"></param>
        void inserirCliente(Cliente cliente);
    }
}
