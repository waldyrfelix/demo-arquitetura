using System;
using System.Collections.Generic;
using System.Data.Entity;
using Demo.Dominio;

namespace Demo.Infra.Repositorio.Configuracao
{
    public class DemoDatabaseInitialize : DropCreateDatabaseIfModelChanges<ContextoBanco>
    {
        protected override void Seed(ContextoBanco context)
        {
            context.Produtos.Add(new Produto
                                     {
                                         CodigoDeBarras = 1234,
                                         Nome = "Coca-cola Lata",
                                         Preço = 2m
                                     });
            context.Produtos.Add(new Produto
                                     {
                                         CodigoDeBarras = 4567,
                                         Nome = "Coca-cola garrafa 290ml",
                                         Preço = 1.5m
                                     });
            context.Produtos.Add(new Produto
                                     {
                                         CodigoDeBarras = 7890,
                                         Nome = "Coca-cola garrafa 600ml",
                                         Preço = 2.5m
                                     });
            context.Produtos.Add(new Produto
                                     {
                                         CodigoDeBarras = 1356,
                                         Nome = "Coca-cola garrafa 1L",
                                         Preço = 3m
                                     });
            context.Produtos.Add(new Produto
                                     {
                                         CodigoDeBarras = 4680,
                                         Nome = "Coca-cola garrafa 2L",
                                         Preço = 4m
                                     });

            var produto = new Produto { CodigoDeBarras = 9876543, Nome = "Coca-Cola", Preço = 4m };
            var cliente = new Cliente { Inscricao = "000.000.191-00", LimiteDeCredito = 200000, Nome = "Álvaro Brognoli" };
            var representante = new Representante { Inscricao = "001.910.000-00", Nome = "Renan", PercentualDeComissao = 5 };
            var venda = new Venda
                            {
                                Cliente = cliente,
                                NumeroDaNota = 123456789,
                                DataDaEmissao = new DateTime(2011, 12, 31),
                                DataDaSaida = new DateTime(2011, 12, 31),
                                ValorTotal = 120,
                                Descricao = "Compra de coca-cola para o time.",
                                ItensDaVenda = new List<ItemDaVenda>
                                                   {
                                                       new ItemDaVenda
                                                           {
                                                               Descricao = "Coca-cola 2L",
                                                               ValorUnitario = 4,
                                                               ValorTotal = 8,
                                                               Quantidade = 2,
                                                               Produto = produto,
                                                               Representante = representante,
                                                           }
                                                   }
                            };

            context.Vendas.Add(venda);

            context.Transportadoras.Add(new Transportadora
                                            {
                                                Inscricao = "12345678",
                                                Nome = "Ouro Negro"
                                            });
            context.Transportadoras.Add(new Transportadora
                                            {
                                                Inscricao = "893843",
                                                Nome = "Jolivan"
                                            });
            context.Transportadoras.Add(new Transportadora
                                            {
                                                Inscricao = "937202",
                                                Nome = "Mercurio"
                                            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}