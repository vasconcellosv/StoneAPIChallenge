using APIChallengeCmd.Data.Data.DataBase;
using DependencyInjectionSample.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIChallenge.Data.Data
{
    public class DataBase : IDataBase
    {
        public MyContext myContext;

        public DataBase(MyContext myContext)
        {
            this.myContext = myContext;
            this.myContext.Database.EnsureCreated();
        }

        public List<Cliente> obterListaClientes()
        {
            List<Cliente> lista = null;
            try
            {
                lista = this.myContext.Clientes.ToList();
            }
            catch (InvalidOperationException)
            {
            }
            if(lista.Count == 0)
            {
                return null;
            }
            return lista;
        }

        public List<Estabelecimento> obterListaEstabelecimentos()
        {
            List<Estabelecimento> lista = null;
            try
            {
                lista = this.myContext.Estabelecimentos.ToList();
            }
            catch (InvalidOperationException)
            {
            }
            if (lista.Count == 0)
            {
                return null;
            }
            return lista;
        }

        public List<Pagamento> obterListaPagamentos()
        {
            List<Pagamento> lista = null;
            try
            {
                lista = this.myContext.Pagamentos.ToList();
            }
            catch (InvalidOperationException)
            {
            }
            if (lista.Count == 0)
            {
                return null;
            }
            return lista;
        }

        public void apagarCliente(long id)
        {
            Cliente cliente = myContext.Clientes.Single(x => x.Id.Equals(id));
            this.myContext.Clientes.Remove(cliente);
            this.myContext.SaveChanges();
        }

        public void apagarPagamento(long id)
        {
            Pagamento pagamento = myContext.Pagamentos.Single(x => x.Id.Equals(id));
            this.myContext.Pagamentos.Remove(pagamento);
            this.myContext.SaveChanges();
        }

        public void inserirCliente(Cliente cliente)
        {
            this.myContext.Clientes.Add(cliente);
            this.myContext.SaveChanges();
        }

        public void inserirEstabelecimento(Estabelecimento estabelecimento)
        {
            this.myContext.Estabelecimentos.Add(estabelecimento);
            this.myContext.SaveChanges();
        }

        public void inserirPagamento(Pagamento pagamento)
        {
            this.myContext.Pagamentos.Add(pagamento);
            this.myContext.SaveChanges();
        }

        public Cliente obterClientePorId(long id)
        {
            Cliente cliente = null;
            try
            {
                cliente = this.myContext.Clientes.Single(x => x.Id.Equals(id));
            }
            catch (InvalidOperationException)
            {
            }
            return cliente;
        }

        public Estabelecimento obterEstabelecimentoPorId(long id)
        {
            Estabelecimento stab = null;
            try
            {
                stab = this.myContext.Estabelecimentos.Single(x => x.Id.Equals(id));
            }
            catch (InvalidOperationException)
            {
            }
            return stab;
        }

        public Estabelecimento obterEstabelecimentoPorCnpj(string cnpj)
        {
            Estabelecimento stab = null;
            try
            {
                stab = this.myContext.Estabelecimentos.Single(x => x.Cnpj.Replace(".", "").Replace("/", "").Replace("-", "").Equals(cnpj.Replace(".", "").Replace("/", "").Replace("-", "")));
            }
            catch (InvalidOperationException)
            {
            }
            return stab;
        }

        public Pagamento obterPagamentoPorId(long id)
        {
            Pagamento pag = null;
            try
            {
                pag = this.myContext.Pagamentos.Single(x => x.Id.Equals(id));
            }
            catch (InvalidOperationException)
            {
            }
            return pag;
        }

        public List<Pagamento> obterListaPagamentosPorEstabelecimento(long idEstabelecimento)
        {
            List<Pagamento> listStab = null;
            try
            {
                listStab = this.myContext.Pagamentos.Where(x => x.Estabelecimento.Id.Equals(idEstabelecimento)).ToList();
            }
            catch (InvalidOperationException)
            {
            }
            if (listStab.Count == 0)
            {
                return null;
            }
            return listStab;
        }

        public long obterMaxIdEstabelecimento()
        {
            long maxId = 0;
            try
            {
                maxId = this.myContext.Estabelecimentos.Max(x => x.Id);
            }
            catch (ArgumentNullException)
            {
            }
            return maxId;
        }

        public long obterMaxIdPagamento()
        {
            long maxId = 0;
            try
            {
                maxId = this.myContext.Pagamentos.Max(x => x.Id);
            }
            catch (ArgumentNullException)
            {
            }
            return maxId;
        }
    }
}
