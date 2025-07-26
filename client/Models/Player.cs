public class Player
{
    public int PlayerID { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int PhoneNumber { get; set; }
    public List<Game>? Games { get; set; }
}