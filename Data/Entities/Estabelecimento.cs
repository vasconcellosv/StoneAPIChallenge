using System;
using System.ComponentModel.DataAnnotations;

namespace APIChallenge
{
    public class Estabelecimento
    {
        [Key]
        private long id;
        private String nome;
        private String cnpj;
        private String natureza_juridica;
        private String situacao;

        public long Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cnpj { get => cnpj; set => cnpj = value; }
        public string Natureza_Juridica { get => natureza_juridica; set => natureza_juridica = value; }
        public string Situacao { get => situacao; set => situacao = value; }

        public Estabelecimento(long id, string nome, string cnpj, string natureza_juridica, string situacao)
        {
            this.id = id;
            this.nome = nome;
            this.cnpj = cnpj;
            this.natureza_juridica = natureza_juridica;
            this.situacao = situacao;
        }
    }
}
