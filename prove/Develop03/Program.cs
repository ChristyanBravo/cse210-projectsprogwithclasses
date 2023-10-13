using System;
using System.Collections.Generic;

class Word
{
    public string Text { get; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }
}

class ScriptureReference
{
    public string Reference { get; }

    public ScriptureReference(string reference)
    {
        Reference = reference;
    }
}

class Scripture
{
    private readonly List<Word> words;
    private readonly ScriptureReference reference;

    public Scripture(string reference, string text)
    {
        this.reference = new ScriptureReference(reference);
        words = new List<Word>();
        string[] wordArray = text.Split(' ');
        foreach (var word in wordArray)
        {
            words.Add(new Word(word));
        }
    }

    public void HideRandomWords()
    {
        Random random = new();
        int wordsToHide = random.Next(1, words.Count + 1);
        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = random.Next(words.Count);
            words[randomIndex].IsHidden = true;
        }
    }

    public bool AllWordsHidden()
    {
        foreach (var word in words)
        {
            if (!word.IsHidden)
            {
                return false;
            }
        }
        return true;
    }

    public override string ToString()
    {
        string scriptureText = "";
        foreach (var word in words)
        {
            scriptureText += word.IsHidden ? "_ _ _ _ _ _" : word.Text;
            scriptureText += " ";
        }
        return $"{reference.Reference} - {scriptureText}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        string scriptureReference = "Alma 5:14";
        string scriptureText = "And now behold, I ask of you, my brethren of the church, have ye aspiritually been bborn of God? Have ye received his image in your countenances? Have ye experienced this mighty cchange in your hearts?";

        Scripture scripture = new(scriptureReference, scriptureText);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture);
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords();

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine("All words are hidden. Press Enter to exit.");
                Console.ReadLine();
                break;
            }
        }
    }
}
