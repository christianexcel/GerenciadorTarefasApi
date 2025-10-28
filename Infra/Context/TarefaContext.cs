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
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TarefaTag> TarefasTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

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

        modelBuilder.Entity<DetalhesTarefa>(entity =>
        {
            entity.ToTable("TB_DETALHES_TAREFA");

            entity.HasKey(t => t.IdTarefa);
            entity.Property(t => t.IdTarefa).HasColumnName("id_tarefa");
            entity.Property(t => t.Prioridade).HasColumnName("prioridade").HasMaxLength(100);
            entity.Property(t => t.NotasAdicionais).HasColumnName("notas_adicionais");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.ToTable("TB_TAGS");
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Id).HasColumnName("id_tag");
            entity.Property(t => t.Nome).HasColumnName("nome_tag");
        });

        modelBuilder.Entity<TarefaTag>(entity =>
        {
            entity.ToTable("TB_TAREFAS_TAGS");
            entity.HasKey(tt => new { tt.IdTarefa, tt.IdTag });
            entity.Property(tt => tt.IdTarefa).HasColumnName("id_tarefa");
            entity.Property(tt => tt.IdTag).HasColumnName("id_tag");
            entity.HasOne(tt => tt.Tarefa)
                .WithMany(t => t.TarefaTags)
                .HasForeignKey(tt => tt.IdTarefa)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_tarefatag_tarefa");

            entity.HasOne(tt => tt.Tag)
                .WithMany(t => t.TarefaTags)
                .HasForeignKey(tt => tt.IdTag)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_tarefatag_tag");
        });

        #region Relacionamentos
        modelBuilder.Entity<Tarefa>()
            .HasOne(t => t.DetalhesTarefa)
            .WithOne(d => d.Tarefa)
            .HasForeignKey<DetalhesTarefa>(d => d.IdTarefa)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_tarefa_detalhes");

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Tarefas)
            .WithOne(t => t.Usuario)
            .HasForeignKey(t => t.IdUsuario)
            .HasConstraintName("fk_usuario_tarefa");

        modelBuilder.Entity<Tarefa>()
            .HasOne(t => t.Usuario)
            .WithMany(u => u.Tarefas)
            .HasForeignKey(t => t.IdUsuario)
            .HasConstraintName("fk_usuario_tarefa");
        #endregion
    }
}