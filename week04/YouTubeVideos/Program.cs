using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learn C# Basics", "CodeMaster2025", 300);
        video1.AddComment(new Comment("Felix", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Bob", "Could you explain loops next?"));
        video1.AddComment(new Comment("Eve", "Nice pacing and clear explanation."));

        Video video2 = new Video("Unity Game Development", "Codepen101", 450);
        video2.AddComment(new Comment("Charlie", "Subscribed! Great content."));
        video2.AddComment(new Comment("Dana", "This is what I needed."));
        video2.AddComment(new Comment("Frank", "More game dev tutorials please!"));

        Video video3 = new Video("How to Cook Pasta", "ChefLuigi", 240);
        video3.AddComment(new Comment("Grace", "Now I'm hungry."));
        video3.AddComment(new Comment("Hank", "Clear and simple recipe."));
        video3.AddComment(new Comment("Ivy", "Loved it!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video v in videos)
        {
            Console.WriteLine($"Title: {v.Title}");
            Console.WriteLine($"Author: {v.Author}");
            Console.WriteLine($"Length: {v.LengthSeconds} seconds");
            Console.WriteLine($"Number of Comments: {v.GetCommentCount()}");

            foreach (Comment c in v.GetComments())
            {
                Console.WriteLine($"  - {c.CommenterName}: {c.Text}");
            }

            Console.WriteLine(); // Empty line between videos
        }
    }
}

