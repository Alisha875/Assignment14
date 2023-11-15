using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a piece of text:");
        string inputText = Console.ReadLine();

        // 1. Word Count
        int wordCount = CountWords(inputText);
        Console.WriteLine($"Word Count: {wordCount}");

        // 2. Email Validation
        List<string> emailAddresses = ValidateEmailAddresses(inputText);
        Console.WriteLine("Email Addresses found:");
        foreach (var email in emailAddresses)
        {
            Console.WriteLine(email);
        }

        // 3. Mobile Number Extraction
        List<string> mobileNumbers = ExtractMobileNumbers(inputText);
        Console.WriteLine("Mobile Numbers found:");
        foreach (var number in mobileNumbers)
        {
            Console.WriteLine(number);
        }

        // 4. Custom Regex Search
        Console.WriteLine("Enter custom regex pattern:");
        string customRegexPattern = Console.ReadLine();
        List<string> customRegexResults = PerformCustomRegexSearch(inputText, customRegexPattern);
        Console.WriteLine("Custom Regex Search Results:");
        foreach (var result in customRegexResults)
        {
            Console.WriteLine(result);
        }
        Console.ReadKey();
    }

    // Method to count words in the input text
    static int CountWords(string text)
    {
        string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    // Method to validate email addresses in the input text
    static List<string> ValidateEmailAddresses(string text)
    {
        List<string> emailAddresses = new List<string>();
        string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
        MatchCollection matches = Regex.Matches(text, emailPattern);
        foreach (Match match in matches)
        {
            emailAddresses.Add(match.Value);
        }
        return emailAddresses;
    }

    // Method to extract mobile numbers from the input text
    static List<string> ExtractMobileNumbers(string text)
    {
        List<string> mobileNumbers = new List<string>();
        string mobileNumberPattern = @"\b\d{10}\b";
        MatchCollection matches = Regex.Matches(text, mobileNumberPattern);
        foreach (Match match in matches)
        {
            mobileNumbers.Add(match.Value);
        }
        return mobileNumbers;
    }

    // Method to perform a custom regex search in the input text
    static List<string> PerformCustomRegexSearch(string text, string pattern)
    {
        List<string> customRegexResults = new List<string>();
        MatchCollection matches = Regex.Matches(text, pattern);
        foreach (Match match in matches)
        {
            customRegexResults.Add(match.Value);
        }
        return customRegexResults;
    }
}
