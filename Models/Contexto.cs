using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OceanTechDotNetGS.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<EmpresaUsuario> EmpresaUsuario { get; set; }
        public DbSet<RegistroUsuario> RegistroUsuarios { get; set; }

        public DbSet<RegistroVazamento> RegistroVazamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmpresaUsuario>()
                .HasKey(eu => new { eu.EmpresaId, eu.UsuarioId });

            modelBuilder.Entity<EmpresaUsuario>()
                .HasOne(eu => eu.Empresa)
                .WithMany(e => e.EmpresaUsuarios)
                .HasForeignKey(eu => eu.EmpresaId);

            modelBuilder.Entity<EmpresaUsuario>()
                .HasOne(eu => eu.Usuario)
                .WithMany(u => u.EmpresaUsuarios)
                .HasForeignKey(eu => eu.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.RegistroUsuario)
                .WithOne(r => r.Usuario)
                .HasForeignKey<RegistroUsuario>(r => r.UsuarioId);

             modelBuilder.Entity<RegistroUsuario>()
                .HasMany(r => r.RegistroVazamentos)
                .WithOne(rv => rv.RegistroUsuario)
                .HasForeignKey(rv => rv.RegistroUsuarioId);    
        }
    }
}