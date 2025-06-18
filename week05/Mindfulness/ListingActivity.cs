// ListingActivity.cs
using System;
using System.Collections.Generic;

namespace MindfulnessApp
{
    public class ListingActivity : MindfulnessActivity
    {
        private List<string> _prompts = new List<string>
        {
            "List as many things as you can that you are grateful for.",
            "List the people who have helped you in life.",
            "List your personal strengths.",
            "List activities that make you happy."
        };

        public ListingActivity() : base(
            "Listing Activity",
            "This activity will help you reflect on the positive aspects of your life by listing them.")
        { }

        public override void Run()
        {
            DisplayStartingMessage();

            string prompt = _prompts[new Random().Next(_prompts.Count)];
            Console.WriteLine($"\n--- {prompt} ---");
            PauseWithMessage("\nStart listing items when ready. Press Enter after each one.", 3);

            List<string> responses = new List<string>();
            DateTime end = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < end)
            {
                Console.Write("> ");
                if (Console.KeyAvailable)
                {
                    string input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        responses.Add(input);
                    }
                }
            }

            Console.WriteLine($"\nYou listed {responses.Count} items!");
            DisplayEndingMessage();
        }
    }
}
