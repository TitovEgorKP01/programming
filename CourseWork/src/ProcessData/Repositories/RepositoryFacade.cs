namespace ProcessData;

public class RepositoryFacade
{
    private DatesRepository _datesRep;
    private MeetingsRepository _meetingsRep;
    private PhonesRepository _phonesRep;
    private TasksRepository _tasksRep;
    private string[] types = new string[]{"dates", "meetings", "phones", "tasks"};

    public RepositoryFacade(string databasePath)
    {
        _datesRep = new DatesRepository(databasePath);
        _meetingsRep = new MeetingsRepository(databasePath);
        _phonesRep = new PhonesRepository(databasePath);
        _tasksRep = new TasksRepository(databasePath);
    }

    public void AddNote<T>(string noteType, T note)
    {
        ValidateNoteType(noteType);

        if (noteType == "dates")
        {
            _datesRep.Insert(note as DateNote);
        }
        else if (noteType == "phones")
        {
            _phonesRep.Insert(note as PhoneNote);
        }
        else if (noteType == "meetings")
        {
            _meetingsRep.Insert(note as MeetingNote);
        }
        else if (noteType == "tasks")
        {
            _tasksRep.Insert(note as TaskNote);
        }
    }

    public void UpdateNote<T>(string noteType, int noteId, T note)
    {
        ValidateNoteType(noteType);

        if (noteType == "dates")
        {
            _datesRep.Update(noteId, note as DateNote);
        }
        else if (noteType == "phones")
        {
            _phonesRep.Update(noteId, note as PhoneNote);
        }
        else if (noteType == "meetings")
        {
            _meetingsRep.Update(noteId, note as MeetingNote);
        }
        else if (noteType == "tasks")
        {
            _tasksRep.Update(noteId, note as TaskNote);
        }
    }

    public void ReadNotes(string noteType)
    {
        ValidateNoteType(noteType);

        if (noteType == "dates")
        {
            PrintMass(_datesRep.GetAllDates());
        }
        else if (noteType == "phones")
        {
            PrintMass(_phonesRep.GetAllPhones());
        }
        else if (noteType == "meetings")
        {
            PrintMass(_meetingsRep.GetAllMeeting());
        }
        else if (noteType == "tasks")
        {
            PrintMass(_tasksRep.GetAllTasks());
        }
    }

    public object ReadNoteById(string noteType, int id)
    {
        ValidateNoteType(noteType);

        if (noteType == "dates")
        {
            return _datesRep.GetById(id);
        }
        else if (noteType == "phones")
        {
            return _phonesRep.GetById(id);
        }
        else if (noteType == "meetings")
        {
            return _meetingsRep.GetById(id);
        }
        else if (noteType == "tasks")
        {
            return _tasksRep.GetById(id);
        }

        return null;
    }

    public void ReadNotesByLastModified(string noteType)
    {
        ValidateNoteType(noteType);

        if (noteType == "dates")
        {
            PrintMass(_datesRep.GetDatesByLastModified());
        }
        else if (noteType == "phones")
        {
            PrintMass(_phonesRep.GetPhonesByLastModified());
        }
        else if (noteType == "meetings")
        {
            PrintMass(_meetingsRep.GetMeetingsByLastModified());
        }
        else if (noteType == "tasks")
        {
            PrintMass(_tasksRep.GetTasksByLastModified());
        }
    }

    public void ReadNotesBySearch(string noteType, string searchValue)
    {
        ValidateNoteType(noteType);

        if (noteType == "dates")
        {
            PrintMass(_datesRep.GetDatesByDescription(searchValue));
        }
        else if (noteType == "phones")
        {
            PrintMass(_phonesRep.GetPhonesByName(searchValue));
        }
        else if (noteType == "meetings")
        {
            PrintMass(_meetingsRep.GetMeetingsByDate(searchValue));
        }
        else if (noteType == "tasks")
        {
            PrintMass(_tasksRep.GetTasksByTitle(searchValue));
        }
    }

    public void DeleteNote(string noteType, int noteId)
    {
        ValidateNoteType(noteType);

        if (noteType == "dates")
        {
            _datesRep.DeleteById(noteId);
        }
        else if (noteType == "phones")
        {
            _phonesRep.DeleteById(noteId);
        }
        else if (noteType == "meetings")
        {
            _meetingsRep.DeleteById(noteId);
        }
        else if (noteType == "tasks")
        {
            _tasksRep.DeleteById(noteId);
        }
    }

    public string[,] GetAllCategoryData(string noteType)
    {
        ValidateNoteType(noteType);

        string[,] allData = null;

        if (noteType == "dates")
        {
            DateNote[] mass = _datesRep.GetAllDates();

            allData = new string[mass.Length, 3];

            for (int i = 0; i < mass.Length; i++)
            {
                allData[i, 0] = mass[i].Date.ToShortDateString();
                allData[i, 1] = mass[i].Description;
                allData[i, 2] = mass[i].LastModified.ToString();
            }
        }
        else if (noteType == "phones")
        {
            PhoneNote[] mass = _phonesRep.GetAllPhones();

            allData = new string[mass.Length, 3];

            for (int i = 0; i < mass.Length; i++)
            {
                allData[i, 0] = mass[i].Number;
                allData[i, 1] = mass[i].Name;
                allData[i, 2] = mass[i].LastModified.ToString();
            }
        }
        else if (noteType == "meetings")
        {
            MeetingNote[] mass = _meetingsRep.GetAllMeeting();

            allData = new string[mass.Length, 4];

            for (int i = 0; i < mass.Length; i++)
            {
                allData[i, 0] = mass[i].Date.ToShortDateString();
                allData[i, 1] = mass[i].Place;
                allData[i, 2] = mass[i].Time;
                allData[i, 3] = mass[i].LastModified.ToString();
            }
        }
        else if (noteType == "tasks")
        {
            TaskNote[] mass = _tasksRep.GetAllTasks();

            allData = new string[mass.Length, 4];

            for (int i = 0; i < mass.Length; i++)
            {
                allData[i, 0] = mass[i].Title;
                allData[i, 1] = mass[i].Description;
                allData[i, 2] = mass[i].Date.ToShortDateString();
                allData[i, 3] = mass[i].LastModified.ToString();
            }
        }

        return allData;
    }

    private void ValidateNoteType(string type)
    {
        for (int i = 0; i < types.Count(); i++)
        {
            if (type == types[i])
            {
                return;
            }
        }

        throw new ArgumentException("Invalid type");
    }

    private static void PrintMass<T>(T[] mass)
    {
        for (int i = 0; i < mass.Length; i++)
        {
            Console.WriteLine(mass[i].ToString());
        }
    }
}


