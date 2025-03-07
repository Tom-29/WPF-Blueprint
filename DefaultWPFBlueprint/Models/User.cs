using System.ComponentModel.DataAnnotations;

namespace DefaultWPFBlueprint.Models;

public class User
{
    public long Id { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string PasswordHash { get; set; }
}