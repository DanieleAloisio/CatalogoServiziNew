using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoServizi.Business.Data;

/// <summary>
/// Entità Servizio
/// </summary>
[Table("Servizio")]
public class Servizio
{
    /// <summary>
    /// ID
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Nome servizio
    /// </summary>
    [Required, MaxLength(256)]
    public string Nome { get; set; } = string.Empty;

    /// <summary>
    /// Identificativo autore censimento
    /// </summary>
    [Required]
    public int IdAutoreCensimento { get; set; } 

    /// <summary>
    /// Url servizio
    /// </summary>
    [Required, MaxLength(512)]
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// Data inizio pubblicazione
    /// </summary>
    public DateTime InizioPubblicazione { get; set; }

    /// <summary>
    /// Data fine pubblicazione
    /// </summary>
    public DateTime? DataFinePubblicazione { get; set; }

    /// <summary>
    /// Servizio cancellato
    /// </summary>
    public bool Canc { get; set; }

    /// <summary>
    /// Utente
    /// </summary>
    [ForeignKey("IdUtente")]
    public virtual Utente Utente { get; set; } = null!;

}