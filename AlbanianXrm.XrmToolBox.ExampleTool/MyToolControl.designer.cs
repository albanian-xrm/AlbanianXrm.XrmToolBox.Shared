using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbanianXrm.XrmToolBox.ExampleTool
{
  partial  class MyToolControl
    {
        private void InitializeComponent()
        {
            this.btnSyncAction = new System.Windows.Forms.Button();
            this.btnAsyncAction = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSyncAction
            // 
            this.btnSyncAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSyncAction.Location = new System.Drawing.Point(3, 3);
            this.btnSyncAction.Name = "btnSyncAction";
            this.btnSyncAction.Size = new System.Drawing.Size(517, 26);
            this.btnSyncAction.TabIndex = 0;
            this.btnSyncAction.Text = "Synchronous Background Action";
            this.btnSyncAction.UseVisualStyleBackColor = true;
            this.btnSyncAction.Click += new System.EventHandler(this.btnSyncAction_Click);
            // 
            // btnAsyncAction
            // 
            this.btnAsyncAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAsyncAction.Location = new System.Drawing.Point(3, 35);
            this.btnAsyncAction.Name = "btnAsyncAction";
            this.btnAsyncAction.Size = new System.Drawing.Size(517, 26);
            this.btnAsyncAction.TabIndex = 1;
            this.btnAsyncAction.Text = "Asynchronous Background Action";
            this.btnAsyncAction.UseVisualStyleBackColor = true;
            this.btnAsyncAction.Click += new System.EventHandler(this.btnAsyncAction_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnSyncAction, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAsyncAction, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listBox1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(523, 315);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 67);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(517, 245);
            this.listBox1.TabIndex = 2;
            // 
            // MyToolControl
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MyToolControl";
            this.Size = new System.Drawing.Size(523, 315);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnSyncAction;
        private System.Windows.Forms.Button btnAsyncAction;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox listBox1;
    }
}
