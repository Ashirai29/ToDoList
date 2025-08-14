using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;

namespace ToDoList
{
    
    public partial class cfrmToDoList : Form
    {
        public string NewTask;
        public DateTime DueDate;
        private cTaskManagment ManageTask;
        cTaskManagment cManageTask = new cTaskManagment();
        // int tabIndex;


        public cfrmToDoList(cTaskManagment _ManageTask)
        {
            InitializeComponent();
            ManageTask = _ManageTask;
            //rtbxToDo.Text = "Task:".PadRight(25)+"Due Date:\n=======================================\n";
            rtbxCompletedTasks.Text = "Task:\t\t\tDate Done:\n==================================\n";
            LoadTasksIntoRichTextBox();
        }

        private void tcDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string NewTask = Interaction.InputBox("What task is to be added('Task,Due Date'):", "Add Task");
            //int tabIndex = tcDays.SelectedIndex;
            cfrmTaskInput InputForm = new cfrmTaskInput(this);
            //rtbxToDo.Text += "1 done"+ tabIndex.ToString(); Some manual debugging
            InputForm.Show();
            LoadTasksIntoRichTextBox();
            
            
            
        }
        public  void DisplayTask(string task, DateTime _DueDate)
        {
            //rtbxToDo.Text += ManageTask.DisplayTask(tcDays.SelectedIndex,task,_DueDate);
            ManageTask.DisplayTask(tcDays.SelectedIndex, task, _DueDate);
           
            LoadTasksIntoRichTextBox();// Ensures rtbx is updated in real time


        }

        private void btnTaskDone_Click(object sender, EventArgs e)
        {
            string sFind = Interaction.InputBox("What task have you completed:", "Task Complition");
            //int iLen = sFind.Length;
            // int iTxtFileFind = 
            ManageTask.MarkTaskAsDone(sFind);
            LoadTasksIntoRichTextBox();
           // int ifind = rtbxToDo.Find(sFind);
            //rtbxToDo.Select(ifind,35);
           // rtbxToDo.SelectionFont = new Font( rtbxToDo.SelectionFont ?? rtbxToDo.Font, FontStyle.Strikeout);
           // rtbxToDo.Text[ifind].ToString();
            

             
        }
        public void LoadTasksIntoRichTextBox()
        {
            string path = @"C:\Users\AAHla\Documents\CraftCode Studios\To Do List\ToDoList\TaskTracker.txt";

            if (!File.Exists(path))
            {
                return; // no file yet
            }

            rtbxToDo.Clear();
            rtbxToDo.Text = "Task:".PadRight(25) + "Due Date:\n=======================================\n";
            foreach (string line in File.ReadAllLines(path))
            {
                if (line.StartsWith("T!"))
                {
                    // Remove the "T!" tag before displaying
                    string displayLine = line.Substring(2);
                    string sTask = displayLine.Substring(0, line.IndexOf('@')-2);
                    string sDate = displayLine.Substring(line.IndexOf('@') - 1);
                    
                    // Apply strikethrough formatting
                    rtbxToDo.SelectionFont = new Font(rtbxToDo.Font, FontStyle.Strikeout);
                    rtbxToDo.AppendText(sTask.PadRight(25)+sDate + Environment.NewLine);
                    rtbxToDo.SelectionFont = rtbxToDo.Font; // reset to normal for next line
                }
                else if (line.StartsWith("F!"))
                {
                    // Remove the "F!" tag before displaying
                    string displayLine = line.Substring(2);
                    string sTask = displayLine.Substring(0, line.IndexOf('@') - 2);
                    string sDate = displayLine.Substring(line.IndexOf('@') - 1);
                    // Display normally
                    rtbxToDo.SelectionFont = new Font(rtbxToDo.Font, FontStyle.Regular);
                    rtbxToDo.AppendText(sTask.PadRight(25) + sDate + Environment.NewLine);
                }
            }
        }



    }
}
