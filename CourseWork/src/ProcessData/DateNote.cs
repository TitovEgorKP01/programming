namespace ProcessData;

public class DateNote : INote
{
    private int id;
    private DateTime date;
    private string description;
    private DateTime lastModified;

    public DateNote(int id, DateTime date, string description, DateTime lastModified)
    {
        this.id = id;
        this.date = date;
        this.description = description;
        this.lastModified = lastModified;
    }

    public DateNote(DateTime date, string description, DateTime lastModified)
    {
        this.date = date;
        this.description = description;
        this.lastModified = lastModified;
    }

    public DateTime Date
    {
        get
        {
            return date;
        }
    }

    public string Description
    {
        get
        {
            return description;
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
        return $"- id: '{id}'; date: '{date.ToShortDateString()}'; description: '{description}'; lastModified: '{lastModified.ToString()}'";
    }

    public INote Clone()
    {
        INote duplicate = new DateNote(id, date, description, DateTime.Now);
        
        return duplicate;
    }
}
