namespace ChatApp.Database.Models;

using ChatApp.Framework.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class Profile : IDatabaseModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(320)]
    [DefaultValue("")]
    public string Email { get; set; } = default!;

    [Required]
    [StringLength(30)]
    [DefaultValue("")]
    public string Username { get; set; } = default!;

    [Required]
    [StringLength(30)]
    [DefaultValue("")]
    public string FirstName { get; set; } = default!;

    [Required]
    [StringLength(30)]
    [DefaultValue("")]
    public string LastName { get; set; } = default!;
}