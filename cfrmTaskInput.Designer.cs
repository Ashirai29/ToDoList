
namespace ToDoList
{
    partial class cfrmTaskInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.lblTasktoAdd = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.txtAddTask = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Location = new System.Drawing.Point(186, 153);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(248, 22);
            this.dtpDueDate.TabIndex = 0;
            // 
            // lblTasktoAdd
            // 
            this.lblTasktoAdd.AutoSize = true;
            this.lblTasktoAdd.Location = new System.Drawing.Point(63, 72);
            this.lblTasktoAdd.Name = "lblTasktoAdd";
            this.lblTasktoAdd.Size = new System.Drawing.Size(87, 17);
            this.lblTasktoAdd.TabIndex = 1;
            this.lblTasktoAdd.Text = "Task to add:";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(63, 158);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(90, 21);
            this.lblDueDate.TabIndex = 2;
            this.lblDueDate.Text = "Due Date:";
            // 
            // txtAddTask
            // 
            this.txtAddTask.Location = new System.Drawing.Point(186, 64);
            this.txtAddTask.Name = "txtAddTask";
            this.txtAddTask.Size = new System.Drawing.Size(248, 22);
            this.txtAddTask.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(322, 223);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 51);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add Task";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(194, 223);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 51);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel\\Done";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(66, 223);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(112, 51);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cfrmTaskInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 302);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtAddTask);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.lblTasktoAdd);
            this.Controls.Add(this.dtpDueDate);
            this.Name = "cfrmTaskInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Task";
            this.Load += new System.EventHandler(this.cfrmTaskInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label lblTasktoAdd;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.TextBox txtAddTask;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
    }
}