using Microsoft.Data.Sqlite;

namespace ProcessData;

public class PhonesRepository
{
    private SqliteConnection connection;

    public PhonesRepository(string databasePath)
    {
        SqliteConnection connection = new SqliteConnection($"Data Source={databasePath}");

        this.connection = connection;
    }

    public int Insert(PhoneNote phone) 
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();

        command.CommandText = 
        @"
            INSERT INTO phones (number, name, lastModified) 
            VALUES ($number, $name, $lastModified);
            SELECT last_insert_rowid();
        ";

        command.Parameters.AddWithValue("$number", phone.Number);
        command.Parameters.AddWithValue("$name", phone.Name);
        command.Parameters.AddWithValue("$lastModified", phone.LastModified.ToString("o"));

        int insertedId = (int)(long)command.ExecuteScalar();

        connection.Close();

        return insertedId;
    }

    public PhoneNote[] GetAllPhones()
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM phones";

        SqliteDataReader reader = command.ExecuteReader();

        List<PhoneNote> list = ReadPhones(reader);

        reader.Close();

        connection.Close();

        PhoneNote[] phones = new PhoneNote[list.Count];
        list.CopyTo(phones);

        return phones;
    }

    public PhoneNote GetById(int id)
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM phones WHERE id = $id";

        command.Parameters.AddWithValue("$id", id);

        SqliteDataReader reader = command.ExecuteReader();

        PhoneNote phoneNote = null;

        if (reader.Read())
        {
            phoneNote = ReadPhone(reader);
        }

        reader.Close();

        connection.Close();

        return phoneNote;
    }

    public PhoneNote[] GetPhonesByLastModified()
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM phones
                                ORDER BY lastModified";

        SqliteDataReader reader = command.ExecuteReader();

        List<PhoneNote> list = ReadPhones(reader);

        reader.Close();

        connection.Close();

        PhoneNote[] phones = new PhoneNote[list.Count];
        list.CopyTo(phones);

        return phones;
    }

    public PhoneNote[] GetPhonesByName(string searchValue)
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM phones
                                WHERE name LIKE '%' || $searchValue || '%'";
        command.Parameters.AddWithValue("$searchValue", searchValue);

        SqliteDataReader reader = command.ExecuteReader();

        List<PhoneNote> list = ReadPhones(reader);

        reader.Close();

        connection.Close();

        PhoneNote[] phones = new PhoneNote[list.Count];
        list.CopyTo(phones);

        return phones;
    }

    public bool Update(int phoneId, PhoneNote phone)
    {
        connection.Open();  

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"UPDATE phones
                                SET number = $number,
                                    name = $name,
                                    lastModified = $lastModified
                                WHERE id = $phoneId";
        command.Parameters.AddWithValue("$phoneId", phoneId);
        command.Parameters.AddWithValue("$number", phone.Number);
        command.Parameters.AddWithValue("$name", phone.Name);
        command.Parameters.AddWithValue("$lastModified", phone.LastModified.ToString("o"));

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
        command.CommandText = @"DELETE FROM phones WHERE id = $id";
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

    private static List<PhoneNote> ReadPhones(SqliteDataReader reader)
    {
        List<PhoneNote> phonesList = new List<PhoneNote>();

        while (reader.Read())
        {
            PhoneNote phone = ReadPhone(reader);

            phonesList.Add(phone);
        }

        return phonesList;
    }

    private static PhoneNote ReadPhone(SqliteDataReader reader)
    {
        int id = reader.GetInt32(0);
        string number = reader.GetString(1);
        string name = reader.GetString(2);
        DateTime lastModified = reader.GetDateTime(3);

        PhoneNote phone = new PhoneNote(id, number, name, lastModified);

        return phone;
    }
}
