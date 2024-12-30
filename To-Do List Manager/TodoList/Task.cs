using System;
using System.Collections.Generic;
using System.Linq;
public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
}

public class HandLeTask
{
    private static HandLeTask gi;
    public static HandLeTask gI()
    {

        if (gi == null) gi = new HandLeTask();
        return gi;
    }
    public void CreateTask(User user, string title, string description, DateTime dueDate)
    {
        int newId = user.Tasks.Count > 0 ? user.Tasks.Max(t => t.Id) + 1 : 1;
        user.Tasks.Add(new Task
        {
            Id = newId,
            Title = title,
            Description = description,
            DueDate = dueDate,
            IsCompleted = false
        });
    }
    public bool MarkTaskCompleted(User user, int taskId)
    {
        var task = user.Tasks.FirstOrDefault(t => t.Id == taskId);
        if (task == null)
            return false;

        task.IsCompleted = true;
        return true;
    }
    public List<Task> FilterTasks(User user, bool isCompleted)
    {
        return user.Tasks.Where(t => t.IsCompleted == isCompleted).ToList();
    }
    public void AddTask(User user, string title, string description, DateTime dueDate)
    {
        int newId = user.Tasks.Count > 0 ? user.Tasks.Max(t => t.Id) + 1 : 1;
        user.Tasks.Add(new Task
        {
            Id = newId,
            Title = title,
            Description = description,
            DueDate = dueDate,
            IsCompleted = false
        });
    }
    public bool UpdateTask(User user, int taskId, string title, string description, DateTime dueDate)
    {
        var task = user.Tasks.FirstOrDefault(t => t.Id == taskId);
        if (task == null)
            return false;

        task.Title = title;
        task.Description = description;
        task.DueDate = dueDate;
        return true;
    }
    public bool DeleteTask(User user, int taskId)
    {
        var task = user.Tasks.FirstOrDefault(t => t.Id == taskId);
        if (task == null)
            return false;

        user.Tasks.Remove(task);
        return true;
    }
}