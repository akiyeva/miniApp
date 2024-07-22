namespace miniApp.Helpers
{
    public static class Color
    {
        public static void WriteLine(string text, ConsoleColor color) 
        { 
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
