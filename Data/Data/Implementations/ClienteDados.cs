using DependencyInjectionSample.Data;
using DependencyInjectionSample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace APIChallenge
{
    public class ClienteDados : IClienteDados
    {
        IDataBase dataBase;

        public ClienteDados(IDataBase dataBaseClient)
        {
            this.dataBase = dataBaseClient;
        }

        public void inserirCliente(Cliente clienteTemp)
        {
            try
            {
                dataBase.inserirCliente(clienteTemp);
            }
            catch(DbUpdateException)
            {
                throw new Exception();
            }
        }

        public Cliente obterClientePorId(long id)
        {
            //Busca um Cliente por seu id
            return dataBase.obterClientePorId(id);
        }
        
        public List<Cliente> obterListaClientes()
        {
            return dataBase.obterListaClientes();
        }
    }
}
