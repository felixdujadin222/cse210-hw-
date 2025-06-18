using System;
using System.Collections.Generic;

namespace MindfulnessApp
{
    public class ReflectionActivity : MindfulnessActivity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "How did you feel when it was complete?",
            "What did you learn about yourself?",
            "How can you apply this lesson in the future?"
        };

        public ReflectionActivity()
            : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience.")
        {
        }

        public override void Run()
        {
            Start();

            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine($"--- {GetRandomPrompt()} ---");
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadLine();

            Console.WriteLine("Now ponder on each of the following questions:");
            ShowSpinner(2);

            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            int i = 0;
            while (DateTime.Now < endTime)
            {
                Console.WriteLine(GetRandomQuestion(i));
                ShowSpinner(3);
                i++;
            }

            End();
        }

        private string GetRandomPrompt()
        {
            Random rand = new Random();
            return _prompts[rand.Next(_prompts.Count)];
        }

        private string GetRandomQuestion(int index)
        {
            return _questions[index % _questions.Count];
        }
    }
}
