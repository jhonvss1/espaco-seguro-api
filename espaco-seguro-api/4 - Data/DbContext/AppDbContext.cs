using espaco_seguro_api._3___Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace espaco_seguro_api._4___Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<VerificacaoCard>  VerificacaoCards { get; set; }
        public DbSet<CertificacaoMedico> Certificacoes { get; set; }
        public DbSet<ConteudoCard> ConteudoCards { get; set; }
        public DbSet<FonteCard> FonteCards { get; set; }
        public DbSet<Postagem> Postagens { get; set; }
        public DbSet<ComentarioPostagem> ComentarioPostagens { get; set; }
        public DbSet<MensagemChat> MensagemChats { get; set; }
        public DbSet<SessaoChat> SessaoChats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .Property(s => s.StatusUsuario)
                .HasConversion<string>()
                .HasMaxLength(20);
            
            modelBuilder.Entity<Usuario>()
                .Property(f => f.Funcao)
                .HasConversion<string>()
                .HasMaxLength(20);
            
            modelBuilder.Entity<Usuario>()
                .Property(d => d.DataNascimento)
                .HasColumnType("date");
            
            modelBuilder.Entity<Medico>()
                .Property(s => s.StatusMedico)
                .HasConversion<string>()
                .HasMaxLength(20);

            modelBuilder.Entity<VerificacaoCard>()
                .Property(s => s.StatusVerificacaoCard)
                .HasConversion<string>()
                .HasMaxLength(20);

            modelBuilder.Entity<CertificacaoMedico>()
                .Property(s => s.StatusCertificacao)
                .HasConversion<string>()
                .HasMaxLength(30);

            modelBuilder.Entity<CertificacaoMedico>()
                .Property(t => t.TipoCertificado)
                .HasConversion<string>()
                .HasMaxLength(100);

            modelBuilder.Entity<Postagem>()
                .Property(s => s.StatusPostagem)
                .HasConversion<string>()
                .HasMaxLength(30);
            
            modelBuilder.Entity<ComentarioPostagem>()
                .Property(s => s.StatusComentarioPostagem)
                .HasConversion<string>()
                .HasMaxLength(30);

            modelBuilder.Entity<SessaoChat>()
                .Property(s => s.TipoChat)
                .HasConversion<string>()
                .HasMaxLength(20);
            
            modelBuilder.Entity<SessaoChat>()
                .Property(s => s.StatusChat)
                .HasConversion<string>()
                .HasMaxLength(30);
            
            modelBuilder.Entity<MensagemChat>()
                .Property(m => m.TipoMensagem)
                .HasConversion<string>()
                .HasMaxLength(30);
        }
    }
}
