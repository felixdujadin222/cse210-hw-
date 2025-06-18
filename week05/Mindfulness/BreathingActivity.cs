// BreathingActivity.cs
using System;

namespace MindfulnessApp
{
    public class BreathingActivity : MindfulnessActivity
    {
        public BreathingActivity() : base(
            "Breathing Activity",
            "This activity will help you relax by guiding you through slow, deep breathing.")
        { }

        public override void Run()
        {
            DisplayStartingMessage();           // intro

            PauseWithMessage("Find a comfortable position  ", 3);

            DateTime end = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < end)
            {
                Console.Write("Breathe in  ");
                ShowProgressDots("", 4);        // inhale 4 s

                Console.Write("Hold       ");
                ShowCountdown(3);               // hold 3 s

                Console.Write("Breathe out ");
                ShowProgressDots("", 6);        // exhale 6 s

                Console.WriteLine();
            }

            DisplayEndingMessage();             // outro
        }
    }
}
