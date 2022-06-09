
[System.Serializable]
public class Player
{
    public string Login;
    public string Password;
    public decimal TotalPlayerBalance;
    public string ConfirmPassword;
    public Player(string login, string password, decimal totalplayerbalace, string confirmPassword)
    {
        this.Login = login;
        this.Password = password;
        this.TotalPlayerBalance = totalplayerbalace;
        this.ConfirmPassword = confirmPassword;
    }
}


