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
        string sDay;
       

        public cfrmToDoList(cTaskManagment _ManageTask)
        {
            InitializeComponent();
            ManageTask = _ManageTask;
            //rtbxSundayToDo.Text = "Task:".PadRight(25)+"Due Date:\n=======================================\n";
            //rtbxSundayCompletedTasks.Text = "Task:\t\t\tDate Done:\n==================================\n";
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
            //rtbxSundayToDo.Text += "1 done"+ tabIndex.ToString(); Some manual debugging
            InputForm.Show();
            LoadTasksIntoRichTextBox();
            
            
            
        }
        public  void DisplayTask(string task, DateTime _DueDate)
        {
            //rtbxSundayToDo.Text += ManageTask.DisplayTask(tcDays.SelectedIndex,task,_DueDate);
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
           


            // int ifind = rtbxSundayToDo.Find(sFind);
            //rtbxSundayToDo.Select(ifind,35);
            // rtbxSundayToDo.SelectionFont = new Font( rtbxSundayToDo.SelectionFont ?? rtbxSundayToDo.Font, FontStyle.Strikeout);
            // rtbxSundayToDo.Text[ifind].ToString();



        }
        public void LoadTasksIntoRichTextBox()
        {
            string path = @"C:\Users\AAHla\Documents\CraftCode Studios\To Do List\ToDoList\TaskTracker.txt";
            RichTextBox[] dayBoxes = new RichTextBox[2] { rtbxSundayToDo, rtbxMondayToDo };
            RichTextBox[] TaskDoneBoxes = new RichTextBox[2] { rtbxSundayCompletedTasks, rtbxMondayToDo };
            RichTextBox rtbTD = dayBoxes[0];
            RichTextBox rtbCT = dayBoxes[0];
            if (!File.Exists(path))
            {
                return; // no file yet
            }
           
            
            switch (tcDays.SelectedIndex)
            {
                case 0:
                    sDay = "Sunday";
                    rtbTD = dayBoxes[0];
                    rtbCT = TaskDoneBoxes[0];
                    break;
                case 1:
                    sDay = "Monday";
                    rtbTD = dayBoxes[1];
                    rtbCT = TaskDoneBoxes[1];
                    break;
                case 2:
                    sDay = "Tuesday";
                    rtbTD = dayBoxes[2];
                    rtbCT = TaskDoneBoxes[2];
                    break;
                case 3:
                    sDay = "Wednesday";
                    rtbTD = dayBoxes[3];
                    rtbCT = TaskDoneBoxes[3];
                    break;
                case 4:
                    sDay = "Thursday";
                    rtbTD = dayBoxes[4];
                    rtbCT = TaskDoneBoxes[4];
                    break;
                case 5:
                    sDay = "Friday";
                    rtbTD = dayBoxes[5];
                    rtbCT = TaskDoneBoxes[5];
                    break;
                case 6:
                    sDay = "Saturday";
                    rtbTD = dayBoxes[6];
                    rtbCT = TaskDoneBoxes[6];
                    break;

            }
            // string rtb = "rtbx" + sDay + "ToDo";

            // RichTextBox rtb = //"rtbx" + sDay + "ToDo";
            rtbTD.Clear();
            rtbTD.Text = "Task:".PadRight(25) + "Due Date:\n====================================\n";
            rtbCT.Clear();
            rtbCT.Text = "Task:".PadRight(25)+ "Date Done:\n==================================\n";
            int iLineCount = 0;
            int iTrueCount = 0;
            int iFalseCount = 0;
            foreach (string line in File.ReadAllLines(path))
            {
                if (line.Contains(sDay))
                {
                    iLineCount++;
                    if (line.StartsWith("T!"))
                    {

                        // Remove the "T!" tag before displaying
                        string displayLine = line.Substring(2);
                        string sTask = displayLine.Substring(0, line.IndexOf('@') - 2);
                        string sDate = displayLine.Substring(line.IndexOf('@') - 1);
                        rtbCT.AppendText(sTask.PadRight(25) + sDate + Environment.NewLine);
                        // Apply strikethrough formatting
                        rtbTD.SelectionStart = rtbxSundayToDo.TextLength; // move cursor to the end of the line
                        rtbTD.SelectionFont = new Font(rtbxSundayToDo.Font, FontStyle.Strikeout);
                        rtbTD.AppendText(sTask.PadRight(25) + sDate + Environment.NewLine);
                        rtbTD.SelectionFont = rtbxSundayToDo.Font; // reset to normal for next line
                                                                   // iLineCount++;
                        iTrueCount++;
                    }
                    else if (line.StartsWith("F!"))
                    {

                        iFalseCount++;
                        // Remove the "F!" tag before displaying
                        string displayLine = line.Substring(2);
                        string sTask = displayLine.Substring(0, line.IndexOf('@') - 2);
                        string sDate = displayLine.Substring(line.IndexOf('@') - 1);
                        // Display normally
                        rtbTD.SelectionFont = new Font(rtbxSundayToDo.Font, FontStyle.Regular);
                        rtbTD.AppendText(sTask.PadRight(25) + sDate + Environment.NewLine);
                    }
                }
               
               
               
                


            }
            if (iLineCount==0)
            {
                iLineCount = 1;
            }
            double dProgress = ((double)iTrueCount / iLineCount) * 100;

            if (dProgress == 100)
            {
                pbrProgress.Value = 100;
                //MessageBox.Show($"True: {iTrueCount}, Total: {iLineCount}, Progress: {dProgress}");// Was used for debbuging purposes, iTrueCount& iLineCount were constantly 
                string imagePath = Path.Combine(Application.StartupPath, "images", "missionDone.jpg");

                if (File.Exists(imagePath))
                {
                    pbxProcess.Image = Image.FromFile(imagePath);
                    pbxProcess.SizeMode = PictureBoxSizeMode.Zoom; // keeps aspect ratio
                    pbxProcess.AutoSize = false; // prevents resizing
                }
                else
                {
                    MessageBox.Show("Image not found at: " + imagePath);
                }

            }
            else if (dProgress > 99)
            {
                pbrProgress.Value = 99;
                string imagePath = Path.Combine(Application.StartupPath, "images", "happy.jpg");

                if (File.Exists(imagePath))
                {
                    pbxProcess.Image = Image.FromFile(imagePath);
                    pbxProcess.SizeMode = PictureBoxSizeMode.Zoom; // keeps aspect ratio
                    pbxProcess.AutoSize = false; // prevents resizing
                }
                else
                {
                    MessageBox.Show("Image not found at: " + imagePath);
                }

            }
            else if (dProgress==50)
            {
                pbrProgress.Value = (int)dProgress;
                string imagePath = Path.Combine(Application.StartupPath, "images", "chill.jpg");

                if (File.Exists(imagePath))
                {
                    pbxProcess.Image = Image.FromFile(imagePath);
                    pbxProcess.SizeMode = PictureBoxSizeMode.Zoom; // keeps aspect ratio
                    pbxProcess.AutoSize = false; // prevents resizing
                }
                
            }
            else if (dProgress == 0)
            {
                pbrProgress.Value = (int)dProgress;
                string imagePath = Path.Combine(Application.StartupPath, "images", "sleepy.jpg");

                if (File.Exists(imagePath))
                {
                    pbxProcess.Image = Image.FromFile(imagePath);
                    pbxProcess.SizeMode = PictureBoxSizeMode.Zoom; // keeps aspect ratio
                    pbxProcess.AutoSize = false; // prevents resizing
                }
            }
            else
            {
                pbrProgress.Value = (int)dProgress;
                string imagePath = Path.Combine(Application.StartupPath, "images", "happy.jpg");

                if (File.Exists(imagePath))
                {
                    pbxProcess.Image = Image.FromFile(imagePath);
                    pbxProcess.SizeMode = PictureBoxSizeMode.Zoom; // keeps aspect ratio
                    pbxProcess.AutoSize = false; // prevents resizing
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ManageTask.DeleteTask(Interaction.InputBox("What task are you deleting:", "Delete a task"));
            LoadTasksIntoRichTextBox();
        }
    }
}
