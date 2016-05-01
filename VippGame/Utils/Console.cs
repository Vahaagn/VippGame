namespace VippGame.Utils
{
    public static class Console
    {
        public static void WriteLine(string text)
        {
            System.Console.WriteLine(text);
        }

        public static void WriteLine(string format, params object[] objects)
        {
            System.Console.WriteLine(format, objects);
        }
    }
}