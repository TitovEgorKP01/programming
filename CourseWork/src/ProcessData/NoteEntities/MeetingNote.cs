namespace ProcessData;

public class MeetingNote : INote
{
    private int id;
    private DateTime date;
    private string place;
    private string time;
    private DateTime lastModified;

    public MeetingNote(int id, DateTime date, string place, string time, DateTime lastModified)
    {
        this.id = id;
        this.date = date;
        this.place = place;
        this.time = time;
        this.lastModified = lastModified;
    }

    public MeetingNote(DateTime date, string place, string time, DateTime lastModified)
    {
        this.date = date;
        this.place = place;
        this.time = time;
        this.lastModified = lastModified;
    }

    public DateTime Date
    {
        get 
        {
            return date;
        }
    }

    public string Place
    {
        get
        {
            return place;
        }
    }

    public string Time
    {
        get
        {
            return time;
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
        return $"- id: '{id}'; date: '{date.ToShortDateString()}'; place: '{place}'; time: '{time}'; lastModified: '{lastModified.ToString()}'";
    }

    public INote Clone()
    {
        INote duplicate = new MeetingNote(id, date, place, time, DateTime.Now);
        
        return duplicate;
    }
}
