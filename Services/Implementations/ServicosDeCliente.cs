using DependencyInjectionSample.Interfaces;
using DependencyInjectionSample.Models;
using System;
using System.Collections.Generic;

namespace APIChallenge
{
    public class ServicosDeCliente : IServicosDeCliente
    {
        IClienteDados clienteDados;
        public ServicosDeCliente(IClienteDados clienteDados)
        {
            this.clienteDados = clienteDados;
        }

        public void inserirCliente(Cliente cliente)
        {
            //realizar a validação dos dados recebidos
            if (cliente.Cpf.Trim() != null
                && !cliente.DataNascimento.Equals(DateTime.MinValue)
                && cliente.Nome.Trim() != null
                && cliente.NumeroCartao.Trim() != null
                && cliente.Id != 0)
            {
                try
                {
                    //inserir os Cliente no banco
                    clienteDados.inserirCliente(cliente);
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public Cliente obterClientePorId(long id)
        {
            return clienteDados.obterClientePorId(id);
        }

        public List<Cliente> obterListaClientes()
        {
            return clienteDados.obterListaClientes();
        }
    }
}
