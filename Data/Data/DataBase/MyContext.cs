using APIChallenge;
using Microsoft.EntityFrameworkCore;

namespace APIChallengeCmd.Data.Data.DataBase
{
    public class MyContext : DbContext
    {
        //private string server = "apichallengedb-2.cjn59s2cng7w.us-east-1.rds.amazonaws.com";
        //private string database = "apichallengedb";
        //private string uid = "apichallengedb";
        //private string pwd = "Vini2723";

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Estabelecimento> Estabelecimentos { get; set; }

        public DbSet<Pagamento> Pagamentos { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //=> optionsBuilder
                //.UseMySql(String.Format(@"Server={0};database={1};uid={2};pwd={3};", server, database, uid, pwd));
    }
}
