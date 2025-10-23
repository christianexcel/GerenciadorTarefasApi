using System;
using GerenciadorTarefasApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefasApi.Infra.Context;

public class TarefaContext : DbContext
{
    public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
    {

    }

    public DbSet<Tarefa> Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarefa>(entity =>
        {
            entity.ToTable("TB_TAREFAS");

            entity.HasKey(t => t.Id);
            entity.Property(t => t.Id).HasColumnName("id_tarefa");
            entity.Property(t => t.Titulo).HasColumnName("titulo_tarefa").HasMaxLength(100);
            entity.Property(t => t.Descricao).HasColumnName("descricao_tarefa").HasMaxLength(500);
            entity.Property(t => t.DataConclusao).HasColumnName("data_conclusao");
            entity.Property(t => t.Concluida).HasColumnName("concluida");
            entity.Property(t => t.DataCriacao).HasColumnName("data_criacao");
            entity.Property(t => t.IdUsuario).HasColumnName("id_usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("TB_USUARIOS");

            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id).HasColumnName("id_usuario");
            entity.Property(u => u.Nome).HasColumnName("nome_usuario").HasMaxLength(100);
            entity.Property(u => u.Email).HasColumnName("email_usuario").HasMaxLength(150);
            entity.HasIndex(e => e.Email)
              .IsUnique();
        });

        /*modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Tarefa)
            .WithOne(t => t.)
            .HasForeignKey<Endereco>(e => e.Id);*/
    }
}