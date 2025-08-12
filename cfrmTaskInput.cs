using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ToDoList
{
    public partial class cfrmTaskInput : Form
    {
        private cfrmToDoList cfrmToDoList;

        public cfrmTaskInput(cfrmToDoList _cfrmToDoList)
        {
            InitializeComponent();
            cfrmToDoList = _cfrmToDoList;
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            /*cfrmToDoList _ToDoList = new cfrmToDoList(); // No longer needed
            ToDoList.NewTask = txtAddTask.Text;
            ToDoList.DueDate = dtpDueDate.Value; */
            cfrmToDoList.DisplayTask(txtAddTask.Text, dtpDueDate.Value);
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAddTask.Clear();
            dtpDueDate.ResetText();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
           // cfrmTaskInput InputForm = new cfrmTaskInput(cfrmToDoList);
            //InputForm.Close();
        }

        private void cfrmTaskInput_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtAddTask;
            //txtAddTask.Focus();
            
        }
    }
}
