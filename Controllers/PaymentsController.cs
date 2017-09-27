using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DependencyInjectionSample.Interfaces;

namespace APIChallenge.Controllers
{
    [Route("[controller]")]
    public class PaymentsController : Controller
    {
        private IServicosDePagamento servicosDePagamento;
        public PaymentsController(IServicosDePagamento servicosDePagamento)
        {
            this.servicosDePagamento = servicosDePagamento;
        }

        // GET payments
        /// <summary>
        /// Método responsável por retornar o histórico de Pagamentos feitos em um Estabelecimento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IEnumerable<Pagamento> Get(long id)
        {
            try
            {
                return servicosDePagamento.obterListaPagamentosPorEstabelecimento(id);
            }
            catch (Exception)
            {
                this.HttpContext.Response.StatusCode = 500;
                return null;
            }
        }

        // GET payments/5
        /// <summary>
        /// Método responsável por cancelar um Pagamento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pagamento"></param>
        [HttpDelete("{id}")]
        public void Delete(long id, [FromBody]Pagamento pagamento)
        {
            try
            {
                if (pagamento == null || id == 0)
                {
                    throw new ArgumentException();
                }
                servicosDePagamento.cancelarPagamento(id, pagamento);
            }
            catch (ArgumentException)
            {
                this.HttpContext.Response.StatusCode = 409;
            }
            catch (Exception)
            {
                this.HttpContext.Response.StatusCode = 400;
            }
        }

        // POST payments
        /// <summary>
        /// Método responsável por fazer o pagamento de um Cliente em um Estabelecimento
        /// </summary>
        /// <param name="pagamento"></param>
        [HttpPost]
        public void Post([FromBody]Pagamento pagamento)
        {
            try
            {
                if (pagamento == null)
                {
                    throw new Exception();
                }
                else
                {
                    servicosDePagamento.inserirPagamento(pagamento);
                }
            }
            catch (ArgumentException)
            {
                this.HttpContext.Response.StatusCode = 406;
            }
            catch (Exception)
            {
                this.HttpContext.Response.StatusCode = 400;
            }
        }
    }
}
