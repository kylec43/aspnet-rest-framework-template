namespace ChatApp.Database.Models;
public class Profile {
    public int id { get; set; }
    public string? email { get; set; }
    public string? username { get; set; }
    public string? first_name { get; set; }
    public string? last_name { get; set; }
}