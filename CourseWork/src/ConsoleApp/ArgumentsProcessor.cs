using static System.Console;
using ProcessData;

namespace ConsoleApp
{
    public static class ArgumentsProcessor
    {
        public static void Run()
        {
            string databasePath = "../ProcessData/data/database.db";
            RepositoryFacade repFacade = new RepositoryFacade(databasePath);

            IChooseStrategy categoryStrategy = new ChooseCategoryStrategy();
            Context categoryContext = new Context(categoryStrategy);

            IChooseStrategy actionStrategy = new ChooseActionStrategy();
            Context actionContext = new Context(actionStrategy);

            WriteLine("".PadRight(40, '='));
            WriteLine("Welcome to SuperNotebook app.");
            WriteLine("".PadRight(40, '='));

            while(true)
            {
                try
                {
                    string categoryResponse = categoryContext.ExecuteStrategy();

                    if (categoryResponse == "exit")
                    {
                        WriteLine("Program ending");

                        WriteLine("".PadRight(40, '='));

                        break;
                    }
                    else if (categoryResponse == "help")
                    {
                        ProcessHelp();
                        continue;
                    }

                    while (true)
                    {
                        WriteLine("".PadRight(40, '-'));

                        string actionResponse = actionContext.ExecuteStrategy();

                        if (actionResponse == "exit")
                        {
                            WriteLine("Program ending");

                            WriteLine("".PadRight(40, '='));

                            return;
                        }
                        else if (actionResponse == "help")
                        {
                            ProcessHelp();
                            continue;
                        }
                        else if (actionResponse == "back")
                        {
                            break;
                        }

                        if (actionResponse == "create")
                        {
                            ProcessCreate(categoryResponse, repFacade);
                        }
                        else if (actionResponse == "read")
                        {
                            ProcessRead(categoryResponse, repFacade);
                        }                 
                        else if (actionResponse == "update")
                        {
                            ProcessUpdate(categoryResponse, repFacade);
                        }
                        else if (actionResponse == "delete")
                        {
                            ProcessDelete(categoryResponse, repFacade);
                        }       
                        else if (actionResponse == "duplicate")
                        {
                            ProcessDuplicate(categoryResponse, repFacade);
                        }
                        else if (actionResponse == "filter")
                        {
                            ProcessFilter(categoryResponse, repFacade);
                        }
                        else if (actionResponse == "search")
                        {
                            ProcessSearch(categoryResponse, repFacade);
                        }
                        else if (actionResponse == "export")
                        {
                            ProcessExport(categoryResponse, repFacade);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.WriteLine($"[Error] - {ex.Message}");
                }

                WriteLine("".PadRight(40, '='));
            }
        }

        private static void ProcessHelp()
        {
            WriteLine("List of commands: \n" +
                      "For categories choose: 'phones', 'meetings', 'dates', 'tasks' \n" +
                      "For action choose: 'create', 'update', 'delete', 'read', 'duplicate', 'filter', 'search', 'export' \n" +
                      "In general: 'exit' for exit, 'help' for help, 'back' for back");
        }

        private static void ProcessCreate(string category, RepositoryFacade rep)
        {
            if (category == "dates")
            {
                Write("Enter date(month/day/year format): ");
                DateTime date = Convert.ToDateTime(ReadLine());

                Write("Enter description: ");
                string description = ReadLine();

                DateTime lastModified = DateTime.Now;

                DateNote dateNote = new DateNote(date, description, lastModified);

                rep.AddNote(category, dateNote);
            }
            else if (category == "phones")
            {
                Write("Enter number: ");
                string number = ReadLine();

                Write("Enter name: ");
                string name = ReadLine();

                DateTime lastModified = DateTime.Now;

                PhoneNote phoneNote = new PhoneNote(number, name, lastModified);

                rep.AddNote(category, phoneNote);
            }
            else if (category == "meetings")
            {
                Write("Enter date(month/day/year format): ");
                DateTime date = Convert.ToDateTime(ReadLine());

                Write("Enter place: ");
                string place = ReadLine();

                Write("Enter time: ");
                string time = ReadLine();

                DateTime lastModified = DateTime.Now;

                MeetingNote meetingNote = new MeetingNote(date, place, time, lastModified);

                rep.AddNote(category, meetingNote);
            }
            else if (category == "tasks")
            {
                Write("Enter title: ");
                string title = ReadLine();

                Write("Enter description: ");
                string description = ReadLine();

                Write("Enter date(month/day/year format): ");
                DateTime date = Convert.ToDateTime(ReadLine());

                DateTime lastModified = DateTime.Now;

                TaskNote taskNote = new TaskNote(title, description, date, lastModified);

                rep.AddNote(category, taskNote);
            }
        }
    
        private static void ProcessRead(string category, RepositoryFacade rep)
        {
            rep.ReadNotes(category);
        }

        private static void ProcessUpdate(string category, RepositoryFacade rep)
        {
            if (category == "dates")
            {
                Write("Enter id: ");
                int id = int.Parse(ReadLine());

                Write("Enter date(month/day/year format): ");
                DateTime date = Convert.ToDateTime(ReadLine());

                Write("Enter description: ");
                string description = ReadLine();

                DateTime lastModified = DateTime.Now;

                DateNote dateNote = new DateNote(date, description, lastModified);

                rep.UpdateNote(category, id, dateNote);
            }
            else if (category == "phones")
            {
                Write("Enter id: ");
                int id = int.Parse(ReadLine());

                Write("Enter number: ");
                string number = ReadLine();

                Write("Enter name: ");
                string name = ReadLine();

                DateTime lastModified = DateTime.Now;

                PhoneNote phoneNote = new PhoneNote(number, name, lastModified);

                rep.UpdateNote(category, id, phoneNote);
            }
            else if (category == "meetings")
            {
                Write("Enter id: ");
                int id = int.Parse(ReadLine());

                Write("Enter date(month/day/year format): ");
                DateTime date = Convert.ToDateTime(ReadLine());

                Write("Enter place: ");
                string place = ReadLine();

                Write("Enter time: ");
                string time = ReadLine();

                DateTime lastModified = DateTime.Now;

                MeetingNote meetingNote = new MeetingNote(date, place, time, lastModified);

                rep.UpdateNote(category, id, meetingNote);
            }
            else if (category == "tasks")
            {
                Write("Enter id: ");
                int id = int.Parse(ReadLine());

                Write("Enter title: ");
                string title = ReadLine();

                Write("Enter description: ");
                string description = ReadLine();

                Write("Enter date(month/day/year format): ");
                DateTime date = Convert.ToDateTime(ReadLine());

                DateTime lastModified = DateTime.Now;

                TaskNote taskNote = new TaskNote(title, description, date, lastModified);

                rep.UpdateNote(category, id, taskNote);
            }
        }
    
        private static void ProcessDelete(string category, RepositoryFacade rep)
        {
            Write("Enter id: ");
            int id = int.Parse(ReadLine());

            rep.DeleteNote(category, id);
        }
    
        private static void ProcessDuplicate(string category, RepositoryFacade rep)
        {
            Write("Enter note id to duplicate: ");
            int id = int.Parse(ReadLine());

            Object obj = rep.ReadNoteById(category, id);

            if (category == "dates")
            {
                DateNote dateNote = (DateNote)obj;
                INote duplicate = dateNote.Clone();

                rep.AddNote(category, duplicate);
            }
            else if (category == "meetings")
            {
                MeetingNote meetingNote = (MeetingNote)obj;
                INote duplicate = meetingNote.Clone();

                rep.AddNote(category, duplicate);
            }
            else if (category == "phones")
            {
                PhoneNote phoneNote = (PhoneNote)obj;
                INote duplicate = phoneNote.Clone();

                rep.AddNote(category, duplicate);
            }
            else if (category == "tasks")
            {
                TaskNote taskNote = (TaskNote)obj;
                INote duplicate = taskNote.Clone();

                rep.AddNote(category, duplicate);
            }
        }

        private static void ProcessFilter(string category, RepositoryFacade rep)
        {
            rep.ReadNotesByLastModified(category);
        }
    
        private static void ProcessSearch(string category, RepositoryFacade rep)
        {
            string searchValue = "";

            if (category == "dates")
            {
                Write("Enter description to search: ");
                searchValue = ReadLine();
            }
            else if (category == "meetings")
            {
                Write("Enter date to search (month/day/year format): ");
                searchValue = ReadLine();
            }
            else if (category == "phones")
            {
                Write("Enter name to search: ");
                searchValue = ReadLine();
            }
            else if (category == "tasks")
            {
                Write("Enter title to search: ");
                searchValue = ReadLine();
            }

            rep.ReadNotesBySearch(category, searchValue);
        }
    
        private static void ProcessExport(string category, RepositoryFacade rep)
        {
            Write("Choose export type: ");
            string exportType = ReadLine();

            if (exportType == "csv")
            {
                FileExport exporter = new FileCSVExport();
                exporter.Export(category, rep);
            }
            else if (exportType == "tsv")
            {
                FileExport exporter = new FileTSVExport();
                exporter.Export(category, rep);
            }
        }
    }


    public abstract class FileExport
    {
        public void Export(string category, RepositoryFacade rep)
        {
            string[,] data = GetData(category, rep);
            ITransformer transformer = GetTransformer();
            string transformedData = GetTransformedData(data, transformer);
            WriteData(transformedData, category);
        }

        protected abstract ITransformer GetTransformer();

        protected string[,] GetData(string category, RepositoryFacade rep)
        {
            return rep.GetAllCategoryData(category);
        }

        protected abstract string GetTransformedData(string[,] data, ITransformer transformer);

        protected abstract void WriteData(string data, string category);
    }

    public class FileCSVExport : FileExport
    {
        protected override ITransformer GetTransformer()
        {
            TransformerCreator creator = new CSVTransformerCreator();

            ITransformer transformer = creator.Create();

            return transformer;
        }

        protected override string GetTransformedData(string[,] data, ITransformer transformer)
        {
            string transformedData = transformer.Transform(data);

            return transformedData;
        }

        protected override void WriteData(string data, string category)
        {
            string path = $"./data/{category}_{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}_CSV.csv";

            File.WriteAllText(path, data);
        }
    }

    public class FileTSVExport : FileExport
    {
        protected override ITransformer GetTransformer()
        {
            TransformerCreator creator = new TSVTransformerCreator();

            ITransformer transformer = creator.Create();

            return transformer;
        }

        protected override string GetTransformedData(string[,] data, ITransformer transformer)
        {
            string transformedData = transformer.Transform(data);

            return transformedData;
        }

        protected override void WriteData(string data, string category)
        {
            string path = $"./data/{category}_{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}_TSV.tsv";

            File.WriteAllText(path, data);
        }
    }


    public abstract class TransformerCreator
    {
        public abstract ITransformer Create();
    }

    public class CSVTransformerCreator : TransformerCreator
    {
        public override ITransformer Create()
        {
            ITransformer csvTransformer = new CSVTransformer();

            return csvTransformer;
        }
    }

    public class TSVTransformerCreator : TransformerCreator
    {
        public override ITransformer Create()
        {
            ITransformer tsvTransformer = new TSVTransformer();

            return tsvTransformer;
        }
    }

    public interface ITransformer
    {
        public string Transform(string[,] data);
    }

    public class CSVTransformer : ITransformer 
    {
        public string Transform(string[,] data)
        {
            string transformedData = "";

            for (int i = 0; i < data.GetLength(0); i++)
            {
                string[] row = new string[data.GetLength(1)];

                for (int j = 0; j < data.GetLength(1); j++)
                {
                    row[j] = data[i, j];
                }

                transformedData += String.Join(',', row);
                transformedData += "\n";
            }

            return transformedData;
        }
    }

    public class TSVTransformer : ITransformer 
    {
        public string Transform(string[,] data)
        {
            string transformedData = "";

            for (int i = 0; i < data.GetLength(0); i++)
            {
                string[] row = new string[data.GetLength(1)];

                for (int j = 0; j < data.GetLength(1); j++)
                {
                    row[j] = data[i, j];
                }

                transformedData += String.Join('\t', row);
                transformedData += "\n";
            }

            return transformedData;
        }
    }
}