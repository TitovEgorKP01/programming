using Microsoft.Data.Sqlite;

namespace ProcessData;

public class DatesRepository
{
    private SqliteConnection connection;

    public DatesRepository(string databasePath)
    {
        SqliteConnection connection = new SqliteConnection($"Data Source={databasePath}");

        this.connection = connection;
    }

    public int Insert(DateNote date) 
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();

        command.CommandText = 
        @"
            INSERT INTO dates (date, description, lastModified) 
            VALUES ($date, $description, $lastModified);
            SELECT last_insert_rowid();
        ";

        command.Parameters.AddWithValue("$date", date.Date.ToString("o"));
        command.Parameters.AddWithValue("$description", date.Description);
        command.Parameters.AddWithValue("$lastModified", date.LastModified.ToString("o"));

        int insertedId = (int)(long)command.ExecuteScalar();

        connection.Close();

        return insertedId;
    }

    public DateNote[] GetAllDates()
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM dates";

        SqliteDataReader reader = command.ExecuteReader();

        List<DateNote> list = ReadDates(reader);

        reader.Close();

        connection.Close();

        DateNote[] dates = new DateNote[list.Count];
        list.CopyTo(dates);

        return dates;
    }

    public DateNote[] GetDatesByLastModified()
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM dates
                                ORDER BY lastModified";

        SqliteDataReader reader = command.ExecuteReader();

        List<DateNote> list = ReadDates(reader);

        reader.Close();

        connection.Close();

        DateNote[] dates = new DateNote[list.Count];
        list.CopyTo(dates);

        return dates;
    }
    
    public DateNote[] GetDatesByDescription(string searchValue)
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM dates
                                WHERE description LIKE '%' || $searchValue || '%'";
        command.Parameters.AddWithValue("$searchValue", searchValue);

        SqliteDataReader reader = command.ExecuteReader();

        List<DateNote> list = ReadDates(reader);

        reader.Close();

        connection.Close();

        DateNote[] dates = new DateNote[list.Count];
        list.CopyTo(dates);

        return dates;
    }

    public DateNote GetById(int id)
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM dates WHERE id = $id";

        command.Parameters.AddWithValue("$id", id);

        SqliteDataReader reader = command.ExecuteReader();

        DateNote dateNote = null;

        if (reader.Read())
        {
            dateNote = ReadDate(reader);
        }

        reader.Close();

        connection.Close();

        return dateNote;
    }

    public bool Update(int dateId, DateNote date)
    {
        connection.Open();  

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"UPDATE dates
                                SET date = $date,
                                    description = $description,
                                    lastModified = $lastModified
                                WHERE id = $dateId";
        command.Parameters.AddWithValue("$dateId", dateId);
        command.Parameters.AddWithValue("$date", date.Date.ToString("o"));
        command.Parameters.AddWithValue("$description", date.Description);
        command.Parameters.AddWithValue("$lastModified", date.LastModified.ToString("o"));

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
        command.CommandText = @"DELETE FROM dates WHERE id = $id";
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

    private static List<DateNote> ReadDates(SqliteDataReader reader)
    {
        List<DateNote> datesList = new List<DateNote>();

        while (reader.Read())
        {
            DateNote date = ReadDate(reader);

            datesList.Add(date);
        }

        return datesList;
    }

    private static DateNote ReadDate(SqliteDataReader reader)
    {
        int id = reader.GetInt32(0);
        DateTime date = reader.GetDateTime(1);
        string description = reader.GetString(2);
        DateTime lastModified = reader.GetDateTime(3);

        DateNote dateNote = new DateNote(id, date, description, lastModified);

        return dateNote;
    }
}
