﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoFinaAPIRest.Data;

#nullable disable

namespace ProjetoFinaAPIRest.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjetoFinaAPIRest.Models.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("ProjetoFinaAPIRest.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("LocalEventoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("LocalEventoId");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("ProjetoFinaAPIRest.Models.FotoPortifolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CaminhoFoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PortifolioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PortifolioId");

                    b.ToTable("FotoPortifolio");
                });

            modelBuilder.Entity("ProjetoFinaAPIRest.Models.Ingresso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoIngressoId")
                        .HasColumnType("int");

                    b.Property<double>("ValorFinal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("PessoaId");

                    b.HasIndex("TipoIngressoId");

                    b.ToTable("Ingresso");
                });

            modelBuilder.Entity("ProjetoFinaAPIRest.Models.LocalEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("Id");

                    b.ToTable("LocalEvento");
                });

            modelBuilder.Entity("ProjetoFinaAPIRest.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("ProjetoFinaAPIRest.Models.Portifolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CaminhoFotoPrincipal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Portifolio");
                });

            modelBuilder.Entity("ProjetoFinaAPIRest.Models.TipoIngresso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("PercentualDesconto")
                        .HasColumnType("float");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TipoIngresso");
                });

            modelBuilder.Entity("ProjetoFinaAPIRest.Models.Contato", b =>
                {
                    b.HasOne("ProjetoFinaAPIRest.Models.Pessoa", "Pessoa")
                        .WithMany("Contatos")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("ProjetoFinaAPIRest.Models.Evento", b =>
                {
                    b.HasOne("ProjetoFinaAPIRest.Models.LocalEvento", "LocalEvento")
                        .WithMany("Eventos")
                        .HasForeignKey("LocalEventoId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("LocalEvento");
                });

            modelBuilder.Entity("ProjetoFinaAPIRest.Models.FotoPortifolio", b =>
                {
                    b.HasOne("ProjetoFinaAPIRest.Models.Portifolio", "Portifolio")
                        .WithMany("FotosPortifolio")
                        .HasForeignKey("PortifolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portifolio");
                });

            modelBuilder.Entity("ProjetoFinaAPIRest.Models.Ingresso", b =>
                {
                    b.HasOne("ProjetoFinaAPIRest.Models.Evento", "Evento")
                        .WithMany("Ingressos")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinaAPIRest.Models.Pessoa", "Pessoa")
                        .WithMany("Ingressos")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinaAPIRest.Models.TipoIngresso", "TipoIngresso")
                        .WithMany("Ingressos")
                        .HasForeignKey("TipoIngressoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Pessoa");

                    b.Navigation("TipoIngresso");
                });

            modelBuilder.Entity("ProjetoFinaAPIRest.Models.Evento", b =>
                {
                    b.Navigation("Ingressos");
                });

            modelBuilder.Entity("ProjetoFinaAPIRest.Models.LocalEvento", b =>
                {
                    b.Navigation("Eventos");
                });

            modelBuilder.Entity("ProjetoFinaAPIRest.Models.Pessoa", b =>
                {
                    b.Navigation("Contatos");

                    b.Navigation("Ingressos");
                });

            modelBuilder.Entity("ProjetoFinaAPIRest.Models.Portifolio", b =>
                {
                    b.Navigation("FotosPortifolio");
                });

            modelBuilder.Entity("ProjetoFinaAPIRest.Models.TipoIngresso", b =>
                {
                    b.Navigation("Ingressos");
                });
#pragma warning restore 612, 618
        }
    }
}
