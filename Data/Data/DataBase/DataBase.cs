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

            //listaClientes.Add(new Cliente(1, "Nome1", "123", DateTime.Today, "456"));
            //listaClientes.Add(new Cliente(2, "Nome2", "234", DateTime.Today, "567"));
            //listaClientes.Add(new Cliente(3, "Nome3", "345", DateTime.Today, "678"));
            //listaClientes.Add(new Cliente(4, "Nome4", "456", DateTime.Today, "789"));
            //listaEstabelecimentos.Add(new Estabelecimento(1, "GLOBO COMUNICACAO E PARTICIPACOES S/A", "27.865.757/0001-02", "205-4 - Sociedade Anônima Fechada", "ATIVA"));
            //listaEstabelecimentos.Add(new Estabelecimento(2, "TVSBT CANAL 4 DE SAO PAULO S/A", "45.039.237/0001-14", "205-4 - Sociedade Anônima Fechada", "ATIVA"));
            //listaEstabelecimentos.Add(new Estabelecimento(3, "STONE PAGAMENTOS S.A.", "16.501.555/0001-57", "205-4 - Sociedade Anônima Fechada", "ATIVA"));
            //listaPagamentos.Add(new Pagamento(1, 123.45f, DateTime.Today, 1, 3));
            //listaPagamentos.Add(new Pagamento(2, 234.56f, DateTime.Today, 2, 3));
            //listaPagamentos.Add(new Pagamento(3, 345.67f, DateTime.Today, 1, 1));
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
