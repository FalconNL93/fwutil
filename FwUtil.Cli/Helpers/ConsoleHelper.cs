namespace FwUtil.Cli.Helpers;

public static class ConsoleHelper
{
    public static bool YesNo(string text)
    {
        ConsoleKey response;
        do
        {
            Console.Write(text);
            response = Console.ReadKey(false).Key;
            if (response != ConsoleKey.Enter) Console.WriteLine();
        } while (response != ConsoleKey.Y && response != ConsoleKey.N);

        return response == ConsoleKey.Y;
    }
}