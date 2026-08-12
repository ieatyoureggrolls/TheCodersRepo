using TheCoders.controllers;
internal class Program()
{
    private static void Main(string[] args)
    {
        //Needed for health bar and other possible icons
        Console.OutputEncoding = System.Text.Encoding.UTF8; 
        new Runner().Run();
    }
}