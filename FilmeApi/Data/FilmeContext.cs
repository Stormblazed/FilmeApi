using FilmeApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace FilmeApi.Data;
public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Sessao>()
                .HasKey(sessao => new { sessao.filmeId, sessao.cinemaId });

        builder.Entity<Sessao>()
            .HasOne(sessao => sessao.cinema)
            .WithMany(cinema => cinema.sessoes)
            .HasForeignKey(sessao => sessao.cinemaId);

        builder.Entity<Sessao>()
            .HasOne(sessao => sessao.filme)
            .WithMany(filme => filme.Sessoes)
            .HasForeignKey(sessao => sessao.filmeId);

        builder.Entity<Endereco>()
            .HasOne(endereco => endereco.cinema)
            .WithOne(cinema => cinema.endereco)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Filme> filmes { get; set; }
    public DbSet<Cinema> cinemas { get; set; }
    public DbSet<Endereco> enderecos { get; set; }
    public DbSet<Sessao> sessoes { get; set; }
}
