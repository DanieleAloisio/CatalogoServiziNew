using CatalogoServizi.Business.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CatalogoServizi.Business.Data;

/// <summary>
/// Database Context
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Configurazione
    /// </summary>
    protected readonly IConfiguration Configuration;

    /// <summary>
    /// Costruttore
    /// </summary>
    /// <param name="options"></param>
    /// <param name="configuration"></param>
    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }

    /// <summary>
    /// AreaIntranet
    /// </summary>
    public virtual DbSet<AreaIntranet> AreaIntranet { get; set; } = null!;

    /// <summary>
    /// Categoria
    /// </summary>
    public virtual DbSet<Categoria> Categoria { get; set; } = null!;

    /// <summary>
    /// Servizio
    /// </summary>
    public virtual DbSet<Servizio> Servizio { get; set; }

    /// <summary>
    /// Utente
    /// </summary>
    public virtual DbSet<Utente> Utente { get; set; }

    /// <summary>
    /// Utente
    /// </summary>
    public virtual DbSet<Ruolo> Ruolo { get; set; }

    /// <summary>
    /// Log
    /// </summary>
    public virtual DbSet<Log> Log { get; set; }

    /// <summary>
    /// ConfigurazioneParametro
    /// </summary>
    public virtual DbSet<ConfigurazioneParametro> ConfigurazioneParametro { get; set; }

    /// <summary>
    /// StoricoDestinatario
    /// </summary>
    public virtual DbSet<StoricoDestinatario> StoricoDestinatario { get; set; }

    /// <summary>
    /// StoricoEmail
    /// </summary>
    public virtual DbSet<StoricoEmail> StoricoEmail { get; set; }

    /// <summary>
    /// Destinatario
    /// </summary>
    public virtual DbSet<Destinatario> Destinatario { get; set; }

    /// <summary>
    /// TipoDestinatario
    /// </summary>
    public virtual DbSet<TipoDestinatario> TipoDestinatario { get; set; }

    /// <summary>
    /// ConfigurazioneEmail
    /// </summary>
    public virtual DbSet<ConfigurazioneEmail> ConfigurazioneEmail { get; set; }

    /// <summary>
    /// TipoEvento
    /// </summary>
    public virtual DbSet<TipoEvento> TipoEvento { get; set; }

    /// <summary>
    /// Tag
    /// </summary>
    public virtual DbSet<Tag> Tag { get; set; }



    /// <summary>
    /// Creazione modello
    /// </summary>
    /// <param name="modelBuilder">Model Builder</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<ConfigurazioneEmail>()
        .HasMany<Tag>(s => s.Tag)
        .WithMany(g => g.ConfigurazioneEmail);

        modelBuilder.Entity<Utente>()
            .HasMany(u => u.Ruoli)
            .WithMany(r => r.Utenti);


        //SEED

        modelBuilder.Entity<TipoDestinatario>().HasData(
            new TipoDestinatario()
            {
                Id = (int)TipoDestinatarioEnum.To,
                Titolo = "To"
            },
            new TipoDestinatario()
            {
                Id = (int)TipoDestinatarioEnum.CC,
                Titolo = "Cc"
            },
            new TipoDestinatario()
            {
                Id = (int)TipoDestinatarioEnum.CCN,
                Titolo = "Ccn"
            });


        //modelBuilder.Entity<ConfigurazioneEmail>().HasData(new ConfigurazioneEmail()
        //{
        //    Id = 1,
        //    IdTipoEvento = (int)TipoEventoEnum.CensimentoUtente,
        //    Testo = "Gentile utente [UTENTE],in data [DATA] è stato censito correttamente al catalogo dei servizi",
        //    Oggetto = "Censimento Catalogo Servizi",
        //    DataUltimaModifica = DateTime.Now,
        //    IdAutoreModifica = 1,
        //    IsAttivo = true,
        //    Canc = false



        //});
    }

}