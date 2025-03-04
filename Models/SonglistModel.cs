using System.ComponentModel.DataAnnotations; // dataannotations för required och felmeddelanden

namespace moment4_dt191g.Models;

public class SonglistModel {
    // Properties
    public int Id { get; set; } // primärnyckel

    // artist
    [Required(ErrorMessage = "Du måste ange artist.")]
    public string? Artist { get; set; }

    // titel på låt
    [Required(ErrorMessage = "Du måste ange låttitel.")]
    public string? Title { get; set; }

    public int Length { get; set; }

    // låtens kategori/genre
    [Required(ErrorMessage = "Du måste ange låtens kategori/genre.")]
    public string? Category { get; set; }
}