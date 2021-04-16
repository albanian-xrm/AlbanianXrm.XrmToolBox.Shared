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
            this.btnSyncI0R0W = new System.Windows.Forms.Button();
            this.btnAsyncI0R0W = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnSyncI1R0W = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSyncI0R0W
            // 
            this.btnSyncI0R0W.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSyncI0R0W.Location = new System.Drawing.Point(303, 3);
            this.btnSyncI0R0W.Name = "btnSyncI0R0W";
            this.btnSyncI0R0W.Size = new System.Drawing.Size(294, 26);
            this.btnSyncI0R0W.TabIndex = 0;
            this.btnSyncI0R0W.Text = "Synchronous Background Action";
            this.btnSyncI0R0W.UseVisualStyleBackColor = true;
            this.btnSyncI0R0W.Click += new System.EventHandler(this.btnSyncI0R0W_Click);
            // 
            // btnAsyncI0R0W
            // 
            this.btnAsyncI0R0W.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAsyncI0R0W.Location = new System.Drawing.Point(303, 131);
            this.btnAsyncI0R0W.Name = "btnAsyncI0R0W";
            this.btnAsyncI0R0W.Size = new System.Drawing.Size(294, 26);
            this.btnAsyncI0R0W.TabIndex = 1;
            this.btnAsyncI0R0W.Text = "Asynchronous Background Action";
            this.btnAsyncI0R0W.UseVisualStyleBackColor = true;
            this.btnAsyncI0R0W.Click += new System.EventHandler(this.btnAsyncI0R0W_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnSyncI1R0W, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSyncI0R0W, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAsyncI0R0W, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.listBox1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1042, 479);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(603, 3);
            this.listBox1.Name = "listBox1";
            this.tableLayoutPanel1.SetRowSpan(this.listBox1, 9);
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 2;
            // 
            // btnSyncI1R0W
            // 
            this.btnSyncI1R0W.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSyncI1R0W.Location = new System.Drawing.Point(303, 35);
            this.btnSyncI1R0W.Name = "btnSyncI1R0W";
            this.btnSyncI1R0W.Size = new System.Drawing.Size(294, 26);
            this.btnSyncI1R0W.TabIndex = 3;
            this.btnSyncI1R0W.Text = "Synchronous Background Action";
            this.btnSyncI1R0W.UseVisualStyleBackColor = true;
            this.btnSyncI1R0W.Click += new System.EventHandler(this.btnSyncI1R0W_Click);
            // 
            // MyToolControl
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MyToolControl";
            this.Size = new System.Drawing.Size(1042, 479);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnSyncI0R0W;
        private System.Windows.Forms.Button btnAsyncI0R0W;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnSyncI1R0W;
    }
}
