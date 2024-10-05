﻿// <auto-generated />
using ConsultorioMedico.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsultorioMedico.Data.Migrations2
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<float>("precoUnitario")
                        .HasColumnType("real");

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
