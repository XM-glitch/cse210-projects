using System;
using System.Net.Mail;
using System.Reflection.PortableExecutable;

class Program
{
    private List<Video> _videos;

    public Program()
    {
        _videos = new List<Video>();
    }

    public void AddVideo(Video video)
    {
        _videos.Add(video);
    }

    public void DisplayVideos()
    {
        if (_videos.Count() == 0)
        {
            Console.WriteLine("No videos available.");
        }
        else
        {
            int count = 1;
            foreach (Video video in _videos)
            {
                Console.WriteLine($"\n{count}. Title: {video.GetTitle()}, Author: {video.GetAuthor()}, Length: {video.GetLength()} seconds, {video.GetCommentCount()} comments");
                List<Comment> comments = video.GetComments();
                if (comments.Count() == 0)
                {
                    Console.WriteLine("No comments.");
                }
                else
                {
                    foreach (Comment comment in comments)
                    {
                        Console.WriteLine($" - {comment.GetCommentDetails()}");
                    }
                }
                count++;
            }
        }
    }
    static void Main(string[] args)
    {
        Program program = new Program();

        Video video1 = new Video("Video_1", "Author_1", 100);
        Video video2 = new Video("Video_2", "Author_2", 200);
        Video video3 = new Video("Video_3", "Author_3", 300);
        Video video4 = new Video("Video_4", "Author_4", 400);

        program.AddVideo(video1);
        program.AddVideo(video2);
        program.AddVideo(video3);
        program.AddVideo(video4);

        Comment comment1 = new Comment("Comment_Author_1", "Comment_1");
        Comment comment2 = new Comment("Comment_Author_2", "Comment_2");
        Comment comment3 = new Comment("Comment_Author_3", "Comment_3");
        video1.AddComment(comment1);
        video1.AddComment(comment2);
        video1.AddComment(comment3);

        Comment comment4 = new Comment("Comment_Author_4", "Comment_4");
        Comment comment5 = new Comment("Comment_Author_5", "Comment_5");
        Comment comment6 = new Comment("Comment_Author_6", "Comment_6");
        video2.AddComment(comment4);
        video2.AddComment(comment5);
        video2.AddComment(comment6);

        Comment comment7 = new Comment("Comment_Author_7", "Comment_7");
        Comment comment8 = new Comment("Comment_Author_8", "Comment_8");
        Comment comment9 = new Comment("Comment_Author_9", "Comment_9");
        video3.AddComment(comment7);
        video3.AddComment(comment8);
        video3.AddComment(comment9);

        Comment comment10 = new Comment("Comment_Author_10", "Comment_10");
        Comment comment11 = new Comment("Comment_Author_11", "Comment_11");
        Comment comment12 = new Comment("Comment_Author_12", "Comment_12");
        video4.AddComment(comment10);
        video4.AddComment(comment11);
        video4.AddComment(comment12);

        program.DisplayVideos();
    }
}