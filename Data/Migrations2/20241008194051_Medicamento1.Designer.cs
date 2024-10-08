﻿// <auto-generated />
using System;
using ConsultorioMedico.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsultorioMedico.Data.Migrations2
{
    [DbContext(typeof(Contexto))]
    [Migration("20241008194051_Medicamento1")]
    partial class Medicamento1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConsultorioMedico.Models.Cid", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("ID");

                    b.ToTable("Cids");
                });

            modelBuilder.Entity("ConsultorioMedico.Models.Cidade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("ID");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("ConsultorioMedico.Models.Consulta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("cidID")
                        .HasColumnType("int");

                    b.Property<int?>("cidadeID")
                        .HasColumnType("int");

                    b.Property<int?>("especialidadeID")
                        .HasColumnType("int");

                    b.Property<int>("medicamentoID")
                        .HasColumnType("int");

                    b.Property<string>("medicoEspecialidadeID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("medicoID")
                        .HasColumnType("int");

                    b.Property<string>("pacienteCidadeID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pacienteID")
                        .HasColumnType("int");

                    b.Property<string>("pacienteUFID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("qtdeMedicamento")
                        .HasColumnType("int");

                    b.Property<decimal?>("valorConsulta")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("cidID");

                    b.HasIndex("cidadeID");

                    b.HasIndex("especialidadeID");

                    b.HasIndex("medicamentoID");

                    b.HasIndex("medicoID");

                    b.HasIndex("pacienteID");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("ConsultorioMedico.Models.Especialidade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("ID");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("ConsultorioMedico.Models.Medicamento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<int>("estoqueMax")
                        .HasColumnType("int");

                    b.Property<int>("estoqueMin")
                        .HasColumnType("int");

                    b.Property<decimal?>("precoUnitario")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("qtdeEstoque")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Medicamentos");
                });

            modelBuilder.Entity("ConsultorioMedico.Models.Medico", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("UFID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cidadeID")
                        .HasColumnType("int");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<int>("especialidadeID")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("ID");

                    b.HasIndex("cidadeID");

                    b.HasIndex("especialidadeID");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("ConsultorioMedico.Models.Paciente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("UFID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cidadeID")
                        .HasColumnType("int");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("cidadeID");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("ConsultorioMedico.Models.Consulta", b =>
                {
                    b.HasOne("ConsultorioMedico.Models.Cid", "cid")
                        .WithMany()
                        .HasForeignKey("cidID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsultorioMedico.Models.Cidade", "cidade")
                        .WithMany()
                        .HasForeignKey("cidadeID");

                    b.HasOne("ConsultorioMedico.Models.Especialidade", "especialidade")
                        .WithMany()
                        .HasForeignKey("especialidadeID");

                    b.HasOne("ConsultorioMedico.Models.Medicamento", "medicamento")
                        .WithMany()
                        .HasForeignKey("medicamentoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsultorioMedico.Models.Medico", "medico")
                        .WithMany()
                        .HasForeignKey("medicoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsultorioMedico.Models.Paciente", "paciente")
                        .WithMany()
                        .HasForeignKey("pacienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cid");

                    b.Navigation("cidade");

                    b.Navigation("especialidade");

                    b.Navigation("medicamento");

                    b.Navigation("medico");

                    b.Navigation("paciente");
                });

            modelBuilder.Entity("ConsultorioMedico.Models.Medico", b =>
                {
                    b.HasOne("ConsultorioMedico.Models.Cidade", "cidade")
                        .WithMany()
                        .HasForeignKey("cidadeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsultorioMedico.Models.Especialidade", "especialidade")
                        .WithMany()
                        .HasForeignKey("especialidadeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cidade");

                    b.Navigation("especialidade");
                });

            modelBuilder.Entity("ConsultorioMedico.Models.Paciente", b =>
                {
                    b.HasOne("ConsultorioMedico.Models.Cidade", "cidade")
                        .WithMany()
                        .HasForeignKey("cidadeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cidade");
                });
#pragma warning restore 612, 618
        }
    }
}
