using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToDoList
{
    public class cTaskManagment
    {
        string sDay;
        string path = @"C:\Users\AAHla\Documents\CraftCode Studios\To Do List\ToDoList\TaskTracker.txt";
        //StreamWriter swTaskLists = new StreamWriter(@"C:\Users\AAHla\Documents\CraftCode Studios\To Do List\ToDoList\TaskTracker.txt", true);
        //StreamReader srTaskLists = new StreamReader(@"C:\Users\AAHla\Documents\CraftCode Studios\To Do List\ToDoList\TaskTracker.txt", true);
        public  void AddRecord(string _Task, DateTime _DueDate, Boolean _bFlag, int iDay)
        {
            
            try
            {
                //string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"../../Infor.txt"));
                // string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\AAHla\Documents\CraftCode Studios\To Do List\ToDoList.txt");
                //string path = @"C:\Users\AAHla\Documents\CraftCode Studios\To Do List\ToDoList\TaskTracker.txt";
                if (!File.Exists(path))
                {
                    using (File.Create(path)) {}
                }
                
                switch (iDay)
                {
                    case 0: sDay = "Sunday";
                        break;
                    case 1:
                        sDay = "Monday";
                        break;
                    case 2:
                        sDay = "Tuesday";
                        break;
                    case 3:
                        sDay = "Wednesday";
                        break;
                    case 4:
                        sDay = "Thursday";
                        break;
                    case 5:
                        sDay = "Friday";
                        break;
                    case 6:
                        sDay = "Saturday";
                        break;

                }
                using (StreamWriter swTaskLists = new StreamWriter(path, true))
                {
                    if (_bFlag)
                    {
                        swTaskLists.WriteLine("T!" + _Task + "@" + _DueDate.ToShortDateString()+ "#" + sDay);
                    }
                    else
                    {
                        swTaskLists.WriteLine("F!"+_Task + "@" + _DueDate.ToShortDateString() + "#" + sDay);
                    }
                   
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Nope", ex);
            }

        }

        public /*string*/void  DisplayTask(int iIndex,string task, DateTime _DueDate)//make this call Add to ritch edit method instead of returning a value
        {
            int TaskWidth = 25; //for good alignment not dependent on how long or short the task enterd was.
            string sRecord;
            switch (iIndex)
            {
                case 0:
                    {
                       
                        AddRecord(task, _DueDate, false,0);
                        
                       // sRecord = task.PadRight(TaskWidth) + _DueDate.ToShortDateString() + "\n"; not needed anymore
                       
                        //  AddRecord(task,_DueDate,false);
                        break;
                    }
                case 1:
                    {
                        AddRecord(task, _DueDate, false,1);
                        sRecord = task.PadRight(TaskWidth) + _DueDate.ToShortDateString() + "\n";
                        break;
                    }
                case 2:
                    {
                        AddRecord(task, _DueDate, false,2);
                        sRecord = task.PadRight(TaskWidth) + _DueDate.ToShortDateString() + "\n";
                        break;
                    }
                case 3:
                    {
                        AddRecord(task, _DueDate, false,3);
                        sRecord = task.PadRight(TaskWidth) + _DueDate.ToShortDateString() + "\n";
                        break;
                    }
                case 4:
                    {
                        AddRecord(task, _DueDate, false,4);
                        sRecord = task.PadRight(TaskWidth) + _DueDate.ToShortDateString() + "\n";
                        break;
                    }
                case 5:
                    {
                        AddRecord(task, _DueDate, false,5);
                        sRecord = task.PadRight(TaskWidth) + _DueDate.ToShortDateString() + "\n";
                        break;
                    }
                case 6:
                    {
                        AddRecord(task, _DueDate, false,6);
                        sRecord = task.PadRight(TaskWidth) + _DueDate.ToShortDateString() + "\n";
                        break;
                    }
                                    
            }

           // return sRecord;
        }
        public void MarkTaskAsDone(string _Task)
        {
            try
            {
                //string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"../../Infor.txt"));
                // string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\AAHla\Documents\CraftCode Studios\To Do List\ToDoList.txt");
                // string path = @"C:\Users\AAHla\Documents\CraftCode Studios\To Do List\ToDoList\TaskTracker.txt";
                if (!File.Exists(path))
                {
                    using (File.Create(path)) { }
                }
                // Read all lines into memory
                var lines = File.ReadAllLines(path).ToList();

                // Find the task and mark it done
                for (int i = 0; i < lines.Count; i++)
                {
                    string sCompare = lines[i].ToUpper();
                    if (sCompare.Contains(_Task.ToUpper()))//Ensuring that task can still be recognized if written in different casing
                    {
                        lines[i] = "T!" + lines[i].Substring(2); // prepend T! to mark done
                    }
                }

                // Write all lines back to the file
                File.WriteAllLines(path, lines);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Nope", ex);
            }

        }
        public void DeleteTask(string _task)
        {
            if (File.Exists(path))
            {
                // Read all lines into a list
                var lines = File.ReadAllLines(path).ToList();

                // Remove only the line where the task name before the '@' matches exactly
                lines.RemoveAll(line =>
                {
                    // Ensure the line is in the correct format
                    if (!line.Contains("@") || line.Length < 3)// A safety check so the code doesn’t crash if the file has An empty line;; A line without @ in it ;A line too short to even have the F!or T! prefix
                        return false;
                   

                    // Remove the F! or T! prefix
                    string taskName = line.Split('@')[0].Substring(2);

                    // Compare task name with the given one (case-insensitive)
                    return taskName.Equals(_task, StringComparison.OrdinalIgnoreCase);
                });

                // Write updated list back to the file
                File.WriteAllLines(path, lines);
            }
        }



    }
}
