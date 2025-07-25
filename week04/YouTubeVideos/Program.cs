using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Create first video
        Video video1 = new Video("How to Cook Jollof Rice", "NaijaChef", 600);
        video1.AddComment(new Comment("Ada", "Great recipe!"));
        video1.AddComment(new Comment("Kunle", "My wife loved it."));
        video1.AddComment(new Comment("Chuka", "Please do fried rice next!"));
        videos.Add(video1);

        // Create second video
        Video video2 = new Video("Top 5 Programming Languages in 2025", "TechTalks", 480);
        video2.AddComment(new Comment("Sarah", "Python for the win!"));
        video2.AddComment(new Comment("James", "Go is underrated."));
        video2.AddComment(new Comment("Mariam", "JavaScript all the way."));
        videos.Add(video2);

        // Create third video
        Video video3 = new Video("Lagos Street Food Tour", "UrbanExplorer", 720);
        video3.AddComment(new Comment("Tomiwa", "Now I’m hungry 😋"));
        video3.AddComment(new Comment("Kofi", "Love the editing."));
        video3.AddComment(new Comment("Fatima", "Can’t wait to visit Lagos!"));
        videos.Add(video3);

        // Create fourth video
        Video video4 = new Video("Introduction to C#", "CodeMaster", 900);
        video4.AddComment(new Comment("Ali", "This was super helpful."));
        video4.AddComment(new Comment("Zainab", "Can you do OOP next?"));
        video4.AddComment(new Comment("Pedro", "Very well explained!"));
        videos.Add(video4);

        // Display all videos and their comments
        foreach (var video in videos)
        {
            Console.WriteLine($"\nTitle: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetAllComments())
            {
                Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
            }
        }
    }
}
