using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIChallenge
{
    public class Pagamento
    {
        private long id;
        private float valor;
        private DateTime data;
        private long idCliente {get;set;}
        [ForeignKey("idCliente")]
        public virtual Cliente Cliente { get; set; }
        private long idEstabelecimento;
        [ForeignKey("idEstabelecimento")]
        public virtual Estabelecimento Estabelecimento { get; set; }

        public long Id { get => id; set => id = value; }
        public float Valor { get => valor; set => valor = value; }
        public DateTime Data { get => data; set => data = value; }

        public Pagamento(long id, float valor, DateTime data, long idCliente, long idEstabelecimento)
        {
            this.id = id;
            this.valor = valor;
            this.data = data;
            this.idCliente = idCliente;
            this.idEstabelecimento = idEstabelecimento;
        }
        public Pagamento()
        {
        }
    }
}
