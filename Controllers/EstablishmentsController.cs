using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DependencyInjectionSample.Interfaces;
using System.Net;

namespace APIChallenge.Controllers
{
    [Route("[controller]")]
    public class EstablishmentsController : Controller
    {

        private IServicosDeEstabelecimento servicosDeEstabelecimento;
        public EstablishmentsController(IServicosDeEstabelecimento servicosDeEstabelecimento)
        {
            this.servicosDeEstabelecimento = servicosDeEstabelecimento;
        }

        // GET establishments
        /// <summary>
        /// Método responsável por retornar a lista de todos os Estabelecimentos cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Estabelecimento> Get()
        {
            try { 
                return servicosDeEstabelecimento.obterListaEstabelecimentos();
            }
            catch (Exception)
            {
                this.HttpContext.Response.StatusCode = 500;
                return null;
            }
}

        // GET establishments/5
        /// <summary>
        /// Método responsável por retornar os dados de um dado Estabelecimento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Estabelecimento Get(long id)
        {
            try
            {
                return servicosDeEstabelecimento.obterEstabelecimentoPorId(id);
            }
            catch (Exception)
            {
                this.HttpContext.Response.StatusCode = 500;
                return null;
            }
        }

        // POST establishments
        /// <summary>
        /// Método responsável por cadastrar um Estabelecimento cujos dados virão da receitaws
        /// </summary>
        /// <param name="stab"></param>
        [HttpPost]
        public void Post([FromBody]Estabelecimento stab)
        {
            try
            {
                servicosDeEstabelecimento.inserirEstabelecimento(stab.Cnpj.Replace(".", "").Replace("/", "").Replace("-", ""));
            }
            catch (ArgumentException)
            {
                this.HttpContext.Response.StatusCode = 406;
            }
            catch (WebException)
            {
                this.HttpContext.Response.StatusCode = 400;
            }
            catch (Exception)
            {
                this.HttpContext.Response.StatusCode = 500;
            }
        }
    }
}
