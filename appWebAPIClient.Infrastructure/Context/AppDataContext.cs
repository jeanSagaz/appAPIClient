using appWebAPIClient.Domain.Models;
using appWebAPIClient.Infrastructure.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace appWebAPIClient.Infrastructure.Context
{
    public class AppDataContext : DbContext
    {
        public AppDataContext() : base("name=appWebAPIClientBD")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<User> Users { get; set; }

        //desabilita algumas convenções do EF
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remove a propriedade de criar tabela com plural
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //remove o delete cascate de um para muitos
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //remove o delete cascate de muitos para muitos
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //configura o tipo "string" como "varchar" no BD
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //configura o tamanho como da "string" com "varchar" de 100
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClientConfig());
            modelBuilder.Configurations.Add(new PhoneConfig());
            modelBuilder.Configurations.Add(new UserConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
