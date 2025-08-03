using System.ComponentModel.DataAnnotations;

namespace FilmNet.Models;

public class Film
{
    public int Id { get; set; }
    
    [Required]
    public string Name{ get; set; } = null!;
    
    [Required]
    [Range (1700, 3000, ErrorMessage = "Invalid year")]
    public int Year { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;

}