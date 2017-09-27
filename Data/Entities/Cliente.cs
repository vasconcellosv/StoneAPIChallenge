using System;
using System.ComponentModel.DataAnnotations;

namespace APIChallenge
{
    public class Cliente
    {
        [Key]
        private long id;
        private String nome;
        private String cpf;
        private DateTime dataNascimento;
        private String numeroCartao;

        public long Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public DateTime DataNascimento { get => dataNascimento; set => dataNascimento = value; }
        public String NumeroCartao { get => numeroCartao; set => numeroCartao = value; }

        public Cliente(long id, string nome, string cpf, DateTime dataNascimento, string numeroCartao)
        {
            this.id = id;
            this.nome = nome;
            this.cpf = cpf;
            this.dataNascimento = dataNascimento;
            this.numeroCartao = numeroCartao;
        }

        public Cliente()
        {
        }
    }
}
