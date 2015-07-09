using System.Data.Entity.ModelConfiguration;
using Demo.Dominio;

namespace Demo.Infra.Repositorio.Configuracao
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            ToTable("Cliente");
        }
    }

    public class ContaAReceberConfig : EntityTypeConfiguration<ContaAReceber>
    {
        public ContaAReceberConfig()
        {
            ToTable("ContasReceber");

            Property(x => x.Numero)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.DataDeEmissao)
                .HasColumnType("Date");

            Property(x => x.Valor)
                .HasPrecision(10, 2);

            Property(x => x.DataDeVencimento)
                .HasColumnType("Date");

            HasRequired(x => x.Cliente)
                .WithMany();
        }
    }

    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            Property(x => x.Nome).HasMaxLength(100).IsRequired();
            Property(x => x.Preço).HasPrecision(10, 2);
            Property(x => x.CodigoDeBarras).IsRequired();
        }
    }

    public class TransportadoraConfig : EntityTypeConfiguration<Transportadora>
    {
        public TransportadoraConfig()
        {
            ToTable("Transportadora");
        }
    }

    public class RepresentanteConfig : EntityTypeConfiguration<Representante>
    {
        public RepresentanteConfig()
        {
            ToTable("Representante");

            HasMany(x => x.Clientes)
                .WithMany(x => x.Representantes)
                .Map(m =>
                         {
                             m.ToTable("ClienteRepresentante");
                             m.MapLeftKey("ClienteId");
                             m.MapRightKey("RepresentanteId");
                         });
        }
    }

    public class ParticipanteConfig : EntityTypeConfiguration<Participante>
    {
        public ParticipanteConfig()
        {
            ToTable("Participante");
            Property(x => x.Nome).IsRequired().HasMaxLength(100);
            Property(x => x.Inscricao).IsRequired().HasMaxLength(100);
        }
    }

    public class ComissaoConfig : EntityTypeConfiguration<Comissao>
    {
        public ComissaoConfig()
        {
            ToTable("Comissao");
        }
    }

    public class ItensDaVendaConfig : EntityTypeConfiguration<ItemDaVenda>
    {
        public ItensDaVendaConfig()
        {
            ToTable("ItemDaVenda");

            Property(x => x.Descricao).HasMaxLength(300).IsRequired();

            HasRequired(x => x.Representante)
                .WithMany();

            HasRequired(x => x.Produto)
                .WithMany();
        }
    }

    public class VendaConfig : EntityTypeConfiguration<Venda>
    {
        public VendaConfig()
        {
            ToTable("Venda");

            Property(x => x.Descricao).HasMaxLength(300).IsRequired();
            Property(x => x.ChaveDeAcessoNFE).IsFixedLength().HasMaxLength(44);
            Property(x => x.DataDaImpressao).IsOptional();

            HasRequired(x => x.Cliente)
                .WithMany();

            HasMany(x => x.ItensDaVenda)
                .WithRequired();
        }
    }
}