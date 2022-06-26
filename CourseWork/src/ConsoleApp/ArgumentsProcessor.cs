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
                        WriteLine("".PadRight(40, '='));
                        WriteLine("Program ending");
                        WriteLine("".PadRight(40, '='));
                        break;
                    }
                    else if (categoryResponse == "help")
                    {
                        WriteLine("".PadRight(65, '-'));
                        ProcessHelp();
                        WriteLine("".PadRight(65, '-'));
                        continue;
                    }

                    while (true)
                    {
                        WriteLine("".PadRight(65, '-'));
                        string actionResponse = actionContext.ExecuteStrategy();
                        WriteLine("".PadRight(65, '-'));

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
                      "".PadRight(40, '~') + "\n" +
                      "For categories choose: 'phones', 'meetings', 'dates', 'tasks' \n" +
                      "For action choose: 'create', 'update', 'delete', 'read', 'duplicate', 'filter', 'search', 'export' \n" +
                      "In general: 'exit' for exit, 'help' for help, 'back' for back");
        }

        private static void ProcessCreate(string category, RepositoryFacade rep)
        {
            int insertedId = 0;

            if (category == "dates")
            {
                Write("Enter date(month/day/year format): ");
                DateTime date = Convert.ToDateTime(ReadLine());

                Write("Enter description: ");
                string description = ReadLine();

                DateTime lastModified = DateTime.Now;

                DateNote dateNote = new DateNote(date, description, lastModified);

                insertedId = rep.AddNote(category, dateNote);
            }
            else if (category == "phones")
            {
                Write("Enter number: ");
                string number = ReadLine();

                Write("Enter name: ");
                string name = ReadLine();

                DateTime lastModified = DateTime.Now;

                PhoneNote phoneNote = new PhoneNote(number, name, lastModified);

                insertedId = rep.AddNote(category, phoneNote);
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

                insertedId = rep.AddNote(category, meetingNote);
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

                insertedId = rep.AddNote(category, taskNote);
            }

            if (insertedId != 0) Console.WriteLine("- Entity inserted -");
            else Console.WriteLine("- Entity not inserted -");
        }
    
        private static void ProcessRead(string category, RepositoryFacade rep)
        {
            WriteLine($"Table {category} records: ");
            WriteLine("".PadRight(20, '~'));

            rep.ReadNotes(category);
        }

        private static void ProcessUpdate(string category, RepositoryFacade rep)
        {
            bool updated = false;

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

                updated = rep.UpdateNote(category, id, dateNote);
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

                updated = rep.UpdateNote(category, id, phoneNote);
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

                updated = rep.UpdateNote(category, id, meetingNote);
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

                updated = rep.UpdateNote(category, id, taskNote);
            }

            if (updated) Console.WriteLine("- Entity updated -");
            else Console.WriteLine("- Entity not updated -");
        }
    
        private static void ProcessDelete(string category, RepositoryFacade rep)
        {
            Write("Enter id: ");
            int id = int.Parse(ReadLine());

            bool deleted = false;

            deleted = rep.DeleteNote(category, id);

            if (deleted) Console.WriteLine("- Entity deleted -");
            else Console.WriteLine("- Entity not deleted -");
        }
    
        private static void ProcessDuplicate(string category, RepositoryFacade rep)
        {
            Write("Enter note id to duplicate: ");
            int id = int.Parse(ReadLine());

            Object obj = rep.ReadNoteById(category, id);

            int duplicatedId = 0;

            if (category == "dates")
            {
                DateNote dateNote = (DateNote)obj;
                INote duplicate = dateNote.Clone();

                duplicatedId = rep.AddNote(category, duplicate);
            }
            else if (category == "meetings")
            {
                MeetingNote meetingNote = (MeetingNote)obj;
                INote duplicate = meetingNote.Clone();

                duplicatedId = rep.AddNote(category, duplicate);
            }
            else if (category == "phones")
            {
                PhoneNote phoneNote = (PhoneNote)obj;
                INote duplicate = phoneNote.Clone();

                duplicatedId = rep.AddNote(category, duplicate);
            }
            else if (category == "tasks")
            {
                TaskNote taskNote = (TaskNote)obj;
                INote duplicate = taskNote.Clone();

                duplicatedId = rep.AddNote(category, duplicate);
            }

            if (duplicatedId != 0) Console.WriteLine("- Entity duplicated -");
            else Console.WriteLine("- Entity not duplicated -");
        }

        private static void ProcessFilter(string category, RepositoryFacade rep)
        {
            WriteLine("Results of filtring by lastModified option: ");
            WriteLine("".PadRight(40, '~'));

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
                Write("Enter date to search (year-month-day format): ");
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
            
            WriteLine("Results of search: ");
            WriteLine("".PadRight(20, '~'));
            
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

            WriteLine("Data was exported to 'date' directory");
        }
    }
}