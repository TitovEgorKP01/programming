using static System.Console;

namespace ProcessData;

public class ChooseCategoryStrategy : IChooseStrategy
{
    private string[] categories = new string[]{"dates", "meetings", "phones", "tasks"};

    public string Choose()
    {
        while (true)
        {
            Write("Choose a category('help' to help, 'exit' to exit): ");

            string response = ReadLine(); 

            if (response == "exit" || response == "help" || ValidateNoteCategory(response))
            {
                return response;
            }
            else
            {
                WriteLine("Incorrect category entered. Please re-enter");
            }
        }
    }

    private bool ValidateNoteCategory(string category)
    {
        for (int i = 0; i < categories.Count(); i++)
        {
            if (category == categories[i])
            {
                return true;
            }
        }

        return false;
    }
}
