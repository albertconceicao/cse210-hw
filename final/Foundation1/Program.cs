using System;

class Program
{
    static void Main(string[] args)
    {
        // Create some videos
        Video video1 = new Video("Learning C#", "CodeAcademy", 1200);
        Video video2 = new Video("Advanced C# Concepts", "ProgrammingWithMosh", 1800);
        Video video3 = new Video("C# Best Practices", "CodeWithHarry", 900);

        // Add comments to video1
        video1.AddComment(new Comment("Alice", "Great video!"));
        video1.AddComment(new Comment("Bob", "Very informative."));
        video1.AddComment(new Comment("Charlie", "I learned a lot."));

        // Add comments to video2
        video2.AddComment(new Comment("Dave", "Excellent explanation."));
        video2.AddComment(new Comment("Eve", "Could you do more videos on this topic?"));
        video2.AddComment(new Comment("Frank", "This helped me understand C# better."));

        // Add comments to video3
        video3.AddComment(new Comment("Grace", "Best video on C# best practices."));
        video3.AddComment(new Comment("Heidi", "Very clear and concise."));
        video3.AddComment(new Comment("Ivan", "Thank you for this!"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information about each video and its comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment._name}: {comment._text}");
            }
            Console.WriteLine();
        }
    }
}