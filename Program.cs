/*Ashley Ashirai Hlatshwayo
 Project Started:12 August 2025*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            cTaskManagment myTaskManager = new cTaskManagment();// Made it so i can pass the required object below
            Application.Run(new cfrmToDoList(myTaskManager));
        }
    }
}
