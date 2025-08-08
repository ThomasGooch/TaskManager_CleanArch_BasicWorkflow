using System;

namespace Core.Entities;

public class MyTask : Base
{

    public MyTask(string title, string? description)
    {
        Title = title;
        Description = description;
        IsCompleted = false;
    }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
}
