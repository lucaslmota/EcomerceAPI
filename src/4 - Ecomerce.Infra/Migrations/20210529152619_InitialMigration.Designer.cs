﻿// <auto-generated />
using System;
using Ecomerce.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace _4___Ecomerce.Infra.Migrations
{
    [DbContext(typeof(EcomerceContext))]
    [Migration("20210529152619_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Ecomerce.Domain.Entities.Companhia", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)")
                        .HasColumnName("cnpj");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("nome_fantasia");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("razao_social");

                    b.HasKey("Id");

                    b.ToTable("Companhia");
                });

            modelBuilder.Entity("Ecomerce.Domain.Entities.Compra", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)")
                        .HasColumnName("cep");

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("data");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("endereco");

                    b.Property<byte>("FormaDePagamento")
                        .HasColumnType("smallint")
                        .HasColumnName("forma-de-pagamento");

                    b.Property<long>("IdUsuario")
                        .HasColumnType("bigint")
                        .HasColumnName("id_usuario");

                    b.Property<string>("Observacao")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("observacao");

                    b.Property<byte>("StatusCompra")
                        .HasColumnType("smallint")
                        .HasColumnName("status-compra");

                    b.Property<float>("Valor")
                        .HasColumnType("real")
                        .HasColumnName("valor");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("Ecomerce.Domain.Entities.Produto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("descricao");

                    b.Property<long>("IdCompanhia")
                        .HasColumnType("bigint")
                        .HasColumnName("id_companhia");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("character varying(180)")
                        .HasColumnName("nome_produto");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("observacao");

                    b.Property<float>("Valor")
                        .HasColumnType("real")
                        .HasColumnName("valor");

                    b.HasKey("Id");

                    b.HasIndex("IdCompanhia");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Ecomerce.Domain.Entities.ProdutoPedido", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("CompraId")
                        .HasColumnType("bigint");

                    b.Property<int>("IdCompra")
                        .HasColumnType("integer");

                    b.Property<long>("IdProduto")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProdutoId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CompraId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutoPedido");
                });

            modelBuilder.Entity("Ecomerce.Domain.Entities.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("cpf");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("character varying(180)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)")
                        .HasColumnName("usuario");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("senha");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Ecomerce.Domain.Entities.Compra", b =>
                {
                    b.HasOne("Ecomerce.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Compras")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Ecomerce.Domain.Entities.Produto", b =>
                {
                    b.HasOne("Ecomerce.Domain.Entities.Companhia", "Companhia")
                        .WithMany("Produtos")
                        .HasForeignKey("IdCompanhia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Companhia");
                });

            modelBuilder.Entity("Ecomerce.Domain.Entities.ProdutoPedido", b =>
                {
                    b.HasOne("Ecomerce.Domain.Entities.Compra", "Compra")
                        .WithMany("ProdutosPedidos")
                        .HasForeignKey("CompraId");

                    b.HasOne("Ecomerce.Domain.Entities.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.Navigation("Compra");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Ecomerce.Domain.Entities.Companhia", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Ecomerce.Domain.Entities.Compra", b =>
                {
                    b.Navigation("ProdutosPedidos");
                });

            modelBuilder.Entity("Ecomerce.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Compras");
                });
#pragma warning restore 612, 618
        }
    }
}
