using FileSupport;
using StringOperations;

if (args.Length > 0)
{
    if (args.Length < 2)
    {
        Console.WriteLine("Please specify a results text file as output");
    }
    else
    {
        var stringOperations = new FileArgumentsHandler();
        var palindrome = new Palindrome(stringOperations);
        var wordCount = palindrome.GetPalindromesFromFile(args[0], args[1]);

        Console.WriteLine("{0} Palindromes added to {1}", wordCount.ToString(), args[1]);

    }
}
else
{
    Console.WriteLine("Please specify a Words file as input and a results text file as output");
}