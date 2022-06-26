namespace ProcessData;

public class PhoneNote : INote
{
    private int id;
    private string number;
    private string name;
    private DateTime lastModified;

    public PhoneNote(int id, string number, string name, DateTime lastModified)
    {
        this.id = id;
        this.number = number;
        this.name = name;
        this.lastModified = lastModified;
    }

    public PhoneNote(string number, string name, DateTime lastModified)
    {
        this.number = number;
        this.name = name;
        this.lastModified = lastModified;
    }

    public string Number
    {
        get
        {
            return number;
        }
    }

    public string Name
    {
        get
        {
            return name;
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
        return $"- id: '{id}'; number: '{number}'; name: '{name}'; lastModified: '{lastModified.ToString()}'";
    }

    public INote Clone()
    {
        INote duplicate = new PhoneNote(id, number, name, DateTime.Now);
        
        return duplicate;
    }
}
