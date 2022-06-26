using static System.Console;

namespace ProcessData;

public class ChooseActionStrategy : IChooseStrategy
{
    private string[] actions = new string[]{"create", "read", "update", "delete", "duplicate", "filter", "search", "export"};

    public string Choose()
    {
        while (true)
        {
            Write("Choose an action('help' to help, 'exit' to exit, 'back' to go back): ");

            string response = ReadLine(); 

            if (response == "exit" || response == "help" || response == "back" || ValidateAction(response))
            {
                return response;
            }
            else
            {
                WriteLine("Incorrect action entered. Please re-enter");
            }
        }
    }

    private bool ValidateAction(string action)
    {
        for (int i = 0; i < actions.Count(); i++)
        {
            if (action == actions[i])
            {
                return true;
            }
        }

        return false;
    }
}
