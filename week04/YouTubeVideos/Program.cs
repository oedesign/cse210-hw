using System;
using System.Collections.Generic;

class Comment
{
    private string _name;
    private string _text;

    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    public void Display()
    {
        Console.WriteLine($"- {_name}: {_text}");
    }
}

class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (Comment c in _comments)
        {
            c.Display();
        }
        Console.WriteLine(); // For spacing between videos
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Intro to C#", "CodeAcademy", 600);
        video1.AddComment(new Comment("Alice", "This video is very helpful!"));
        video1.AddComment(new Comment("Bob", "Loved the explanations."));
        video1.AddComment(new Comment("Cathy", "Can you cover loops next?"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Abstraction in OOP", "TechExplained", 720);
        video2.AddComment(new Comment("Daniel", "Now I understand abstraction."));
        video2.AddComment(new Comment("Eva", "Thanks for this clear content."));
        video2.AddComment(new Comment("Frank", "Do you have one on encapsulation?"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("C# Project Demo", "DevMaster", 880);
        video3.AddComment(new Comment("Grace", "This was so motivating!"));
        video3.AddComment(new Comment("Henry", "Please share source code."));
        video3.AddComment(new Comment("Isaac", "Really clean UI!"));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("Understanding Classes", "LearnDotNet", 540);
        video4.AddComment(new Comment("Jenny", "This cleared all my doubts."));
        video4.AddComment(new Comment("Kevin", "Subscribed for more!"));
        video4.AddComment(new Comment("Laura", "Nice visuals."));
        videos.Add(video4);

        // Display all videos
        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}
