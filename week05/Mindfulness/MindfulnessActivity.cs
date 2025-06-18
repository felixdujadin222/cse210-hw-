// MindfulnessActivity.cs
using System;
using System.Threading;

namespace MindfulnessApp          //  <-- use this same namespace everywhere
{
    /// <summary>
    /// Base class containing common UI and helper animations
    /// for all mindfulness activities.
    /// </summary>
    public abstract class MindfulnessActivity
    {
        // ---------- protected fields ----------
        protected string _name;
        protected string _description;
        protected int    _duration;

        // ---------- ctor ----------
        protected MindfulnessActivity(string name, string description)
        {
            _name        = name;
            _description = description;
        }

        // ---------- public template helpers ----------
        protected void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"--- {_name} ---");
            Console.WriteLine(_description);
            Console.Write("\nHow long, in seconds, would you like this activity to last? ");
            _duration = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
        }

        protected void DisplayEndingMessage()
        {
            Console.WriteLine("\nWell done!");
            ShowSpinner(2);
            Console.WriteLine($"You completed the {_name} for {_duration} seconds.");
            ShowSpinner(3);
        }

        // ---------- helper animations ----------
        protected void ShowSpinner(int seconds)
        {
            string[] spin = { "|", "/", "-", "\\" };
            DateTime end  = DateTime.Now.AddSeconds(seconds);
            int idx = 0;
            while (DateTime.Now < end)
            {
                Console.Write(spin[idx]);
                Thread.Sleep(200);
                Console.Write("\b \b");
                idx = (idx + 1) % spin.Length;
            }
        }

        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }

        protected void PauseWithMessage(string msg, int spinnerSeconds)
        {
            Console.Write(msg);
            ShowSpinner(spinnerSeconds);
            Console.WriteLine();
        }

        protected void ShowProgressDots(string label, int seconds)
        {
            Console.Write(label);
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        // ---------- force derived classes to implement ----------
        public abstract void Run();
    }
}
