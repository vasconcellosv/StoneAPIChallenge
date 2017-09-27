using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DependencyInjectionSample.Interfaces;

namespace APIChallenge.Controllers
{
    [Route("[controller]")]
    public class ClientsController : Controller
    {

        private IServicosDeCliente servicosDeClientes;
        public ClientsController(IServicosDeCliente servicosDeClientes)
        {
            this.servicosDeClientes = servicosDeClientes;
        }

        // GET clients
        /// <summary>
        /// Método responsável por listar todos os Clientes cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            try
            {
                return servicosDeClientes.obterListaClientes();
            }
            catch (Exception)
            {
                this.HttpContext.Response.StatusCode = 500;
                return null;
            }
        }

        // GET clients/5
        /// <summary>
        /// Método responsável por exibir um determinado Cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Cliente Get(long id)
        {
            try
            {
                return servicosDeClientes.obterClientePorId(id);
            }
            catch (Exception)
            {
                this.HttpContext.Response.StatusCode = 500;
                return null;
            }
        }

        // POST clients
        /// <summary>
        /// Método responsável por cadastrar um Cliente
        /// </summary>
        /// <param name="cliente"></param>
        [HttpPost]
        public void Post([FromBody]Cliente cliente)
        {
            try
            {
                servicosDeClientes.inserirCliente(cliente);
            }
            catch (ArgumentException)
            {
                this.HttpContext.Response.StatusCode = 406;
            }
            catch (Exception)
            {
                this.HttpContext.Response.StatusCode = 500;
            }
        }
    }
}
