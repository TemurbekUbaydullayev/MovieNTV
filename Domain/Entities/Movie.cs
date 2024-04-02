
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Movie : Base
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Country { get; set; } = "";
    public int Duration { get; set; }
    public int Year { get; set; }
    public string Company { get; set; } = "";
    public string Director { get; set; } = "";
    public int GenreId { get; set; }

    [ForeignKey(nameof(GenreId))]
    public Genre Genre { get; set; } = null!;
}
