namespace ChatApp.Database.Models;

using ChatApp.Framework.Interfaces;

public class Profile : IDatabaseModel
{
    public int id { get; set; }
    public string? email { get; set; }
    public string? username { get; set; }
    public string? first_name { get; set; }
    public string? last_name { get; set; }
}