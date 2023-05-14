namespace JSJMClientApplication;

public class GetInputClass
{
    public int GetInt(string message)
    {
        int returnInt;
        while (true)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            try
            {
                returnInt = int.Parse(input);
                break;
            }
            catch (Exception)
            {
                Console.WriteLine("Please write a number.");
            }
        }
        return returnInt;
    }

    public string GetString(string message)
    {
        string returnString;
        while (true)
        {
            Console.WriteLine(message);
            returnString = Console.ReadLine();
            if (string.IsNullOrEmpty(returnString))
            {
                Console.WriteLine("Please actually write something.");
            }
            else
            {
                break;
            }
        }
        return returnString;
    }

    public bool GetYesNo(string message)
    {
        while (true)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            if (input.Equals("y"))
            {
                return true;
            }
            else if (input.Equals("n"))
            {
                return false;
            }
            Console.WriteLine("y or n, please");
        }
    }
}