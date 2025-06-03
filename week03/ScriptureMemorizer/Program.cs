// Program.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Clear();
        Scripture scripture = ScriptureLibrary.GetRandomScripture(); // Random scripture from library

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); // Hides 3 words at a time
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are now hidden. Goodbye!");
    }
}

// Reference.cs
public class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int VerseStart { get; private set; }
    public int? VerseEnd { get; private set; }

    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verse;
        VerseEnd = null;
    }

    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
    }

    public override string ToString()
    {
        return VerseEnd == null ? $"{Book} {Chapter}:{VerseStart}" : $"{Book} {Chapter}:{VerseStart}-{VerseEnd}";
    }
}

// Word.cs
public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}

// Scripture.cs
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private static Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ')
                     .Select(word => new Word(word))
                     .ToList();
    }

    public void HideRandomWords(int count)
    {
        var unhiddenWords = _words.Where(w => !w.IsHidden()).ToList();
        int toHide = Math.Min(count, unhiddenWords.Count);

        for (int i = 0; i < toHide; i++)
        {
            int index = _random.Next(unhiddenWords.Count);
            unhiddenWords[index].Hide();
            unhiddenWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        string text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference}\n{text}";
    }
}

// ScriptureLibrary.cs
public static class ScriptureLibrary
{
    private static List<Scripture> _scriptures;

    static ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();

        // Load from file
        if (File.Exists("scriptures.txt"))
        {
            var lines = File.ReadAllLines("scriptures.txt");
            foreach (var line in lines)
            {
                // Format: Book Chapter:Verse[-Verse]|Text
                var parts = line.Split('|');
                var refPart = parts[0];
                var text = parts[1];

                var bookChapter = refPart.Split(' ')[0];
                var refDetails = refPart.Substring(bookChapter.Length + 1).Split(':');
                var chapter = int.Parse(refDetails[0]);
                var verses = refDetails[1].Split('-');

                Reference reference;
                if (verses.Length == 1)
                    reference = new Reference(bookChapter, chapter, int.Parse(verses[0]));
                else
                    reference = new Reference(bookChapter, chapter, int.Parse(verses[0]), int.Parse(verses[1]));

                _scriptures.Add(new Scripture(reference, text));
            }
        }
        else
        {
            // Default scripture
            _scriptures.Add(new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."));
        }
    }

    public static Scripture GetRandomScripture()
    {
        Random rnd = new Random();
        return _scriptures[rnd.Next(_scriptures.Count)];
    }
}
