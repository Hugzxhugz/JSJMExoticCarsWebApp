using JSJMClientApplication.Interface;

namespace JSJMClientApplication;

public class UserBuilder : IUserBuilder
{
    private GetInputClass _getInputClass = new GetInputClass();
    
    public string SetUserName()
    {
        string Name = _getInputClass.GetString("Please enter the user's name:");
        return Name;
    }

    public string SetUserPassword()
    {
        string Password = _getInputClass.GetString("Please enter the user's password:");
        return Password;
    }

    public int SetUserFunds()
    {
        int Funds = _getInputClass.GetInt("Please enter amount of funds to add:");
        return Funds;
    }

    public User CreateUser()
    {
        string name = SetUserName();
        string password = SetUserPassword();
        int funds = SetUserFunds();

        User user = new User();
        user.Name = name;
        user.Password = password;
        user.Funds = funds;

        return user;
    }
}