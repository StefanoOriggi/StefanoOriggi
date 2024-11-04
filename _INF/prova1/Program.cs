namespace prova1;
class Program
{
    public static string ReverseString(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    static void Main(string[] args)
    {
        string reversed = ReverseString("example");
        Console.WriteLine(reversed);
    }  
}
