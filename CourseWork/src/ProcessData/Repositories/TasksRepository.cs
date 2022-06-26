using Microsoft.Data.Sqlite;

namespace ProcessData;

public class TasksRepository
{
    private SqliteConnection connection;

    public TasksRepository(string databasePath)
    {
        SqliteConnection connection = new SqliteConnection($"Data Source={databasePath}");

        this.connection = connection;
    }

    public int Insert(TaskNote task) 
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();

        command.CommandText = 
        @"
            INSERT INTO tasks (title, description, date, lastModified) 
            VALUES ($title, $description, $date, $lastModified);
            SELECT last_insert_rowid();
        ";

        command.Parameters.AddWithValue("$title", task.Title);
        command.Parameters.AddWithValue("$description", task.Description);
        command.Parameters.AddWithValue("$date", task.Date.ToString("o"));
        command.Parameters.AddWithValue("$lastModified", task.LastModified.ToString("o"));

        int insertedId = (int)(long)command.ExecuteScalar();

        connection.Close();

        return insertedId;
    }

    public TaskNote[] GetAllTasks()
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM tasks";

        SqliteDataReader reader = command.ExecuteReader();

        List<TaskNote> list = ReadTasks(reader);

        reader.Close();

        connection.Close();

        TaskNote[] tasks = new TaskNote[list.Count];
        list.CopyTo(tasks);

        return tasks;
    }

    public TaskNote GetById(int id)
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM tasks WHERE id = $id";

        command.Parameters.AddWithValue("$id", id);

        SqliteDataReader reader = command.ExecuteReader();

        TaskNote taskNote = null;

        if (reader.Read())
        {
            taskNote = ReadTask(reader);
        }

        reader.Close();

        connection.Close();

        return taskNote;
    }

    public TaskNote[] GetTasksByLastModified()
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM tasks
                                ORDER BY lastModified";

        SqliteDataReader reader = command.ExecuteReader();

        List<TaskNote> list = ReadTasks(reader);

        reader.Close();

        connection.Close();

        TaskNote[] tasks = new TaskNote[list.Count];
        list.CopyTo(tasks);

        return tasks;
    }

    public TaskNote[] GetTasksByTitle(string searchValue)
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM tasks
                                WHERE title LIKE '%' || $searchValue || '%'";
        command.Parameters.AddWithValue("$searchValue", searchValue);

        SqliteDataReader reader = command.ExecuteReader();

        List<TaskNote> list = ReadTasks(reader);

        reader.Close();

        connection.Close();

        TaskNote[] tasks = new TaskNote[list.Count];
        list.CopyTo(tasks);

        return tasks;
    }

    public bool Update(int taskId, TaskNote task)
    {
        connection.Open();  

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"UPDATE tasks
                                SET title = $title,
                                    description = $description,
                                    date = $date,
                                    lastModified = $lastModified
                                WHERE id = $dateId";
        command.Parameters.AddWithValue("$dateId", taskId);
        command.Parameters.AddWithValue("$title", task.Date);
        command.Parameters.AddWithValue("$description", task.Description);
        command.Parameters.AddWithValue("$date", task.Date.ToString("o"));
        command.Parameters.AddWithValue("$lastModified", task.LastModified.ToString("o"));

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

    private static List<TaskNote> ReadTasks(SqliteDataReader reader)
    {
        List<TaskNote> tasksList = new List<TaskNote>();

        while (reader.Read())
        {
            TaskNote task = ReadTask(reader);

            tasksList.Add(task);
        }

        return tasksList;
    }

    private static TaskNote ReadTask(SqliteDataReader reader)
    {
        int id = reader.GetInt32(0);
        string title = reader.GetString(1);
        string description = reader.GetString(2);
        DateTime date = reader.GetDateTime(3);
        DateTime lastModified = reader.GetDateTime(4);

        TaskNote taskNote = new TaskNote(id, title, description, date, lastModified);

        return taskNote;
    }
}