using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Diagnostics;
using Demo.Dominio;
using Demo.Infra.Repositorio.Configuracao;

namespace Demo.Infra.Repositorio
{
    public class ContextoBanco : DbContext
    {
        public ContextoBanco()
        {
            Database.SetInitializer(new DemoDatabaseInitialize());
            Debug.WriteLine("CONTEXTO EF CRIADO: " + GetHashCode());
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ContaAReceber> ContasAReceber { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Representante> Representantes { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Transportadora> Transportadoras { get; set; }

        protected override void Dispose(bool disposing)
        {
            Debug.WriteLine("CONTEXTO EF EXCLUIDO: " + GetHashCode());
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var dbSpatialServices = SqlSpatialServices.Default;

            modelBuilder.Configurations.Add(new ParticipanteConfig());
            modelBuilder.Configurations.Add(new ContaAReceberConfig());
            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());
            modelBuilder.Configurations.Add(new TransportadoraConfig());
            modelBuilder.Configurations.Add(new RepresentanteConfig());
            modelBuilder.Configurations.Add(new ComissaoConfig());
            modelBuilder.Configurations.Add(new VendaConfig());
            modelBuilder.Configurations.Add(new ItensDaVendaConfig());
        }
    }
}