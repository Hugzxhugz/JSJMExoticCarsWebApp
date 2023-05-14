namespace JSJMClientApplication;

public class UpdateUserBuilder
{
    private GetInputClass _getInputClass = new GetInputClass();
        
    public void UpdateUserName(User user)
    {
        string name = _getInputClass.GetString("Please enter the updated name of the user:");
        user.Name = name;
    }
        
    public void UpdateUserPassword(User user)
    {
        string password = _getInputClass.GetString("Please enter the updated password of the user:");
        user.Password = password;
    }
        
    public void UpdateUserFunds(User user)
    {
        int funds = _getInputClass.GetInt("Please enter the updated funds of the user:");
        user.Funds = funds;
    }
    
    public void UpdateUser(User user)
    {
        Console.WriteLine("Select the field you want to update:");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Password");
        Console.WriteLine("3. Funds");
        
        int choice = _getInputClass.GetInt("Enter your choice:");

        switch (choice)
        {
            case 1:
                UpdateUserName(user);
                break;
            case 2:
                UpdateUserPassword(user);
                break;
            case 3:
                UpdateUserFunds(user);
                break;
            
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
}