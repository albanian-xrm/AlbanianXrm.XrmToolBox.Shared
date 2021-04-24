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
            this.btnSyncI0R1W = new System.Windows.Forms.Button();
            this.btnAsyncI1R0W = new System.Windows.Forms.Button();
            this.btnSyncI1R0 = new System.Windows.Forms.Button();
            this.btnSyncI0R0 = new System.Windows.Forms.Button();
            this.btnSyncI1R0W = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnSyncI1R1W = new System.Windows.Forms.Button();
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
            this.btnSyncI0R0W.Text = "Sync Without Argument Without Result Progress";
            this.btnSyncI0R0W.UseVisualStyleBackColor = true;
            this.btnSyncI0R0W.Click += new System.EventHandler(this.BtnSyncI0R0W_Click);
            // 
            // btnAsyncI0R0W
            // 
            this.btnAsyncI0R0W.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAsyncI0R0W.Location = new System.Drawing.Point(303, 131);
            this.btnAsyncI0R0W.Name = "btnAsyncI0R0W";
            this.btnAsyncI0R0W.Size = new System.Drawing.Size(294, 26);
            this.btnAsyncI0R0W.TabIndex = 1;
            this.btnAsyncI0R0W.Text = "Async Without Argument Without Result Progress";
            this.btnAsyncI0R0W.UseVisualStyleBackColor = true;
            this.btnAsyncI0R0W.Click += new System.EventHandler(this.BtnAsyncI0R0W_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnSyncI1R1W, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSyncI0R1W, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAsyncI1R0W, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnSyncI1R0, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSyncI0R0, 0, 0);
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
            // btnSyncI0R1W
            // 
            this.btnSyncI0R1W.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSyncI0R1W.Location = new System.Drawing.Point(303, 67);
            this.btnSyncI0R1W.Name = "btnSyncI0R1W";
            this.btnSyncI0R1W.Size = new System.Drawing.Size(294, 26);
            this.btnSyncI0R1W.TabIndex = 7;
            this.btnSyncI0R1W.Text = "Sync Without Argument With Result Progress";
            this.btnSyncI0R1W.UseVisualStyleBackColor = true;
            this.btnSyncI0R1W.Click += new System.EventHandler(this.BtnSyncI0R1W_Click);
            // 
            // btnAsyncI1R0W
            // 
            this.btnAsyncI1R0W.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAsyncI1R0W.Location = new System.Drawing.Point(303, 163);
            this.btnAsyncI1R0W.Name = "btnAsyncI1R0W";
            this.btnAsyncI1R0W.Size = new System.Drawing.Size(294, 26);
            this.btnAsyncI1R0W.TabIndex = 6;
            this.btnAsyncI1R0W.Text = "Async With Argument Without Result Progress";
            this.btnAsyncI1R0W.UseVisualStyleBackColor = true;
            this.btnAsyncI1R0W.Click += new System.EventHandler(this.BtnAsyncI1R0W_Click);
            // 
            // btnSyncI1R0
            // 
            this.btnSyncI1R0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSyncI1R0.Location = new System.Drawing.Point(3, 35);
            this.btnSyncI1R0.Name = "btnSyncI1R0";
            this.btnSyncI1R0.Size = new System.Drawing.Size(294, 26);
            this.btnSyncI1R0.TabIndex = 5;
            this.btnSyncI1R0.Text = "Sync With Argument Without Result";
            this.btnSyncI1R0.UseVisualStyleBackColor = true;
            this.btnSyncI1R0.Click += new System.EventHandler(this.BtnSyncI1R0_Click);
            // 
            // btnSyncI0R0
            // 
            this.btnSyncI0R0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSyncI0R0.Location = new System.Drawing.Point(3, 3);
            this.btnSyncI0R0.Name = "btnSyncI0R0";
            this.btnSyncI0R0.Size = new System.Drawing.Size(294, 26);
            this.btnSyncI0R0.TabIndex = 4;
            this.btnSyncI0R0.Text = "Sync Without Argument Without Result";
            this.btnSyncI0R0.UseVisualStyleBackColor = true;
            this.btnSyncI0R0.Click += new System.EventHandler(this.BtnSyncI0R0_Click);
            // 
            // btnSyncI1R0W
            // 
            this.btnSyncI1R0W.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSyncI1R0W.Location = new System.Drawing.Point(303, 35);
            this.btnSyncI1R0W.Name = "btnSyncI1R0W";
            this.btnSyncI1R0W.Size = new System.Drawing.Size(294, 26);
            this.btnSyncI1R0W.TabIndex = 3;
            this.btnSyncI1R0W.Text = "Sync With Argument Without Result Progress";
            this.btnSyncI1R0W.UseVisualStyleBackColor = true;
            this.btnSyncI1R0W.Click += new System.EventHandler(this.BtnSyncI1R0W_Click);
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
            // btnSyncI1R1W
            // 
            this.btnSyncI1R1W.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSyncI1R1W.Location = new System.Drawing.Point(303, 99);
            this.btnSyncI1R1W.Name = "btnSyncI1R1W";
            this.btnSyncI1R1W.Size = new System.Drawing.Size(294, 26);
            this.btnSyncI1R1W.TabIndex = 9;
            this.btnSyncI1R1W.Text = "Sync With Argument With Result Progress";
            this.btnSyncI1R1W.UseVisualStyleBackColor = true;
            this.btnSyncI1R1W.Click += new System.EventHandler(this.BtnSyncI1R1W_Click);
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
        private System.Windows.Forms.Button btnSyncI0R0;
        private System.Windows.Forms.Button btnSyncI1R0;
        private System.Windows.Forms.Button btnAsyncI1R0W;
        private System.Windows.Forms.Button btnSyncI0R1W;
        private System.Windows.Forms.Button btnSyncI1R1W;
    }
}
