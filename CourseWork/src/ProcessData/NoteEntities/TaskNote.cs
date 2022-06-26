namespace ProcessData;


public class TaskNote : INote
{
    private int id;
    private string title;
    private string description;
    private DateTime date;
    private DateTime lastModified;

    public TaskNote(int id, string title, string description, DateTime date, DateTime lastModified)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.date = date;
        this.lastModified = lastModified;
    }

    public TaskNote(string title, string description, DateTime date, DateTime lastModified)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.lastModified = lastModified;
    }

    public string Title
    {
        get
        {
            return title;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }
    }

    public DateTime Date
    {
        get
        {
            return date;
        }
    }

    public DateTime LastModified
    {
        get
        {
            return lastModified;
        }
    }

    public override string ToString()
    {
        return $"- id: '{id}'; title: '{title}'; description: '{description}'; date: '{date.ToShortDateString()}'; lastModified: '{lastModified.ToString()}'";
    }

    public INote Clone()
    {
        INote duplicate = new TaskNote(id, title, description, date, DateTime.Now);
        
        return duplicate;
    }
}