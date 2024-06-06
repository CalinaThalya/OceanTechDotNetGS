﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OceanTechDotNetGS.Models;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace OceanTechDotNetGS.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20240606204818_AdicionarNovaPropriedadeVazamentos")]
    partial class AdicionarNovaPropriedadeVazamentos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OceanTechDotNetGS.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("nomeEmpresa")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("nomeFantasia")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("tb_octh_empresa");
                });

            modelBuilder.Entity("OceanTechDotNetGS.Models.EmpresaUsuario", b =>
                {
                    b.Property<int>("EmpresaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("EmpresaUsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("EmpresaId", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tb_octh_empresaUsuario");
                });

            modelBuilder.Entity("OceanTechDotNetGS.Models.RegistroUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("tb_octh_registroUsuario");
                });

            modelBuilder.Entity("OceanTechDotNetGS.Models.RegistroVazamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataDetecao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("DescricaoVazamento")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("RegistroUsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("TipoSeveridade")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("RegistroUsuarioId");

                    b.ToTable("tb_octh_registroVazamento");
                });

            modelBuilder.Entity("OceanTechDotNetGS.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("tb_octh_usuario");
                });

            modelBuilder.Entity("OceanTechDotNetGS.Models.EmpresaUsuario", b =>
                {
                    b.HasOne("OceanTechDotNetGS.Models.Empresa", "Empresa")
                        .WithMany("EmpresaUsuarios")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OceanTechDotNetGS.Models.Usuario", "Usuario")
                        .WithMany("EmpresaUsuarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("OceanTechDotNetGS.Models.RegistroUsuario", b =>
                {
                    b.HasOne("OceanTechDotNetGS.Models.Usuario", "Usuario")
                        .WithOne("RegistroUsuario")
                        .HasForeignKey("OceanTechDotNetGS.Models.RegistroUsuario", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("OceanTechDotNetGS.Models.RegistroVazamento", b =>
                {
                    b.HasOne("OceanTechDotNetGS.Models.RegistroUsuario", "RegistroUsuario")
                        .WithMany("RegistroVazamentos")
                        .HasForeignKey("RegistroUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RegistroUsuario");
                });

            modelBuilder.Entity("OceanTechDotNetGS.Models.Empresa", b =>
                {
                    b.Navigation("EmpresaUsuarios");
                });

            modelBuilder.Entity("OceanTechDotNetGS.Models.RegistroUsuario", b =>
                {
                    b.Navigation("RegistroVazamentos");
                });

            modelBuilder.Entity("OceanTechDotNetGS.Models.Usuario", b =>
                {
                    b.Navigation("EmpresaUsuarios");

                    b.Navigation("RegistroUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
