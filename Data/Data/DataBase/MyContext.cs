using APIChallenge;
using Microsoft.EntityFrameworkCore;

namespace APIChallengeCmd.Data.Data.DataBase
{
    public class MyContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Estabelecimento> Estabelecimentos { get; set; }

        public DbSet<Pagamento> Pagamentos { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
    }
}
