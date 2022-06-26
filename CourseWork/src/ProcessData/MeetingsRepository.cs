using Microsoft.Data.Sqlite;

namespace ProcessData;

public class MeetingsRepository
{
    private SqliteConnection connection;

    public MeetingsRepository(string databasePath)
    {
        SqliteConnection connection = new SqliteConnection($"Data Source={databasePath}");

        this.connection = connection;
    }

    public int Insert(MeetingNote meeting) 
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();

        command.CommandText = 
        @"
            INSERT INTO meetings (date, place, time, lastModified) 
            VALUES ($date, $place, $time, $lastModified);
            SELECT last_insert_rowid();
        ";

        command.Parameters.AddWithValue("$date", meeting.Date.ToString("o"));
        command.Parameters.AddWithValue("$place", meeting.Place);
        command.Parameters.AddWithValue("$time", meeting.Time);
        command.Parameters.AddWithValue("$lastModified", meeting.LastModified.ToString("o"));

        int insertedId = (int)(long)command.ExecuteScalar();

        connection.Close();

        return insertedId;
    }

    public MeetingNote[] GetAllMeeting()
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM meetings";

        SqliteDataReader reader = command.ExecuteReader();

        List<MeetingNote> list = ReadMeetings(reader);

        reader.Close();

        connection.Close();

        MeetingNote[] meetings = new MeetingNote[list.Count];
        list.CopyTo(meetings);

        return meetings;
    }

    public MeetingNote GetById(int id)
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM meetings WHERE id = $id";

        command.Parameters.AddWithValue("$id", id);

        SqliteDataReader reader = command.ExecuteReader();

        MeetingNote meetingNote = null;

        if (reader.Read())
        {
            meetingNote = ReadMeeting(reader);
        }

        reader.Close();

        connection.Close();

        return meetingNote;
    }

    public MeetingNote[] GetMeetingsByLastModified()
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM meetings
                                ORDER BY lastModified";

        SqliteDataReader reader = command.ExecuteReader();

        List<MeetingNote> list = ReadMeetings(reader);

        reader.Close();

        connection.Close();

        MeetingNote[] meetings = new MeetingNote[list.Count];
        list.CopyTo(meetings);

        return meetings;
    }

    public MeetingNote[] GetMeetingsByDate(string searchValue)
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM meetings
                                WHERE date LIKE $searchValue || '%'";
        command.Parameters.AddWithValue("$searchValue", searchValue);

        SqliteDataReader reader = command.ExecuteReader();

        List<MeetingNote> list = ReadMeetings(reader);

        reader.Close();

        connection.Close();

        MeetingNote[] meetings = new MeetingNote[list.Count];
        list.CopyTo(meetings);

        return meetings;
    }

    public bool Update(int meetingId, MeetingNote meeting)
    {
        connection.Open();  

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"UPDATE meetings
                                SET date = $date,
                                    place = $place,
                                    time = $time,
                                    lastModified = $lastModified
                                WHERE id = $dateId";
        command.Parameters.AddWithValue("$dateId", meetingId);
        command.Parameters.AddWithValue("$date", meeting.Date.ToString("o"));
        command.Parameters.AddWithValue("$place", meeting.Place);
        command.Parameters.AddWithValue("$time", meeting.Time);
        command.Parameters.AddWithValue("$lastModified", meeting.LastModified.ToString("o"));

        int nChanged = command.ExecuteNonQuery();

        bool isUpdated = false;

        if (nChanged != 0)
        {
            isUpdated = true;
        }

        connection.Close();

        return isUpdated;
    }

    public bool DeleteById(int id)
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"DELETE FROM tasks WHERE id = $id";
        command.Parameters.AddWithValue("$id", id);

        int deletedCount = command.ExecuteNonQuery();

        bool isDeleted = false;

        if (deletedCount != 0)
        {
            isDeleted = true;
        }

        connection.Close();

        return isDeleted;
    }

    private static List<MeetingNote> ReadMeetings(SqliteDataReader reader)
    {
        List<MeetingNote> meetingsList = new List<MeetingNote>();

        while (reader.Read())
        {
            MeetingNote meeting = ReadMeeting(reader);

            meetingsList.Add(meeting);
        }

        return meetingsList;
    }

    private static MeetingNote ReadMeeting(SqliteDataReader reader)
    {
        int id = reader.GetInt32(0);
        DateTime date = reader.GetDateTime(1);
        string place = reader.GetString(2);
        string time = reader.GetString(3);
        DateTime lastModified = reader.GetDateTime(4);

        MeetingNote meetingNote = new MeetingNote(id, date, place, time, lastModified);

        return meetingNote;
    }
}
