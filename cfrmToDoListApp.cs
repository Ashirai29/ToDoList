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

namespace ToDoList
{
    
    public partial class cfrmToDoList : Form
    {
        public string NewTask;
        public DateTime DueDate;
        // int tabIndex;


        public cfrmToDoList()
        {
            InitializeComponent();
            rtbxToDo.Text = "Task:".PadRight(25)+"Due Date:\n=======================================\n";
            rtbxCompletedTasks.Text = "Task:\t\t\tDate Done:\n==================================\n";
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
            
            
        }
        public  void DisplayTask(string task, DateTime _DueDate)
        {
            int TaskWidth = 25; //for good alignment not dependent on how long or short the task enterd was.
            switch (tcDays.SelectedIndex)
            {
                case 0:
                    {
                        rtbxToDo.Text += task.PadRight(TaskWidth) + _DueDate.ToShortDateString() + "\n";
                        break;
                    }
                case 1:
                    {
                        rtbxToDo.Text += task + "\t\t\t" + _DueDate.ToString() + "\n";
                        break;
                    }
                case 2:
                    {
                        rtbxToDo.Text += task + "\t\t\t" + _DueDate.ToString() + "\n";
                        break;
                    }
                case 3:
                    {
                        rtbxToDo.Text += task + "\t\t\t" + _DueDate.ToString() + "\n";
                        break;
                    }
                case 4:
                    {
                        rtbxToDo.Text += task + "\t\t\t" + _DueDate.ToString() + "\n";
                        break;
                    }
                case 5:
                    {
                        rtbxToDo.Text += task + "\t\t\t" + _DueDate.ToString() + "\n";
                        break;
                    }
                case 6:
                    {
                        rtbxToDo.Text += task + "\t\t\t" + _DueDate.ToString() + "\n";
                        break;
                    }


                default:
                    rtbxToDo.Text += task + "\t\t\t" + _DueDate.ToString() + "\n";
                    break;
            }

           
        }
        
    }
}
