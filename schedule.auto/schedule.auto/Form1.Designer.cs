namespace schedule.auto
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            rTBConsoleLog = new RichTextBox();
            btnAddJob = new Button();
            btnStartAllJob = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnStopAllJob = new Button();
            SuspendLayout();
            // 
            // rTBConsoleLog
            // 
            rTBConsoleLog.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rTBConsoleLog.Location = new Point(836, 39);
            rTBConsoleLog.Name = "rTBConsoleLog";
            rTBConsoleLog.Size = new Size(864, 658);
            rTBConsoleLog.TabIndex = 0;
            rTBConsoleLog.Text = "";
            // 
            // btnAddJob
            // 
            btnAddJob.Location = new Point(12, 12);
            btnAddJob.Name = "btnAddJob";
            btnAddJob.Size = new Size(75, 23);
            btnAddJob.TabIndex = 2;
            btnAddJob.Text = "Thêm Job";
            btnAddJob.UseVisualStyleBackColor = true;
            btnAddJob.Click += btnAddJob_Click;
            // 
            // btnStartAllJob
            // 
            btnStartAllJob.Location = new Point(93, 12);
            btnStartAllJob.Name = "btnStartAllJob";
            btnStartAllJob.Size = new Size(75, 23);
            btnStartAllJob.TabIndex = 3;
            btnStartAllJob.Text = "Chạy tất cả";
            btnStartAllJob.UseVisualStyleBackColor = true;
            btnStartAllJob.Click += btnStartAllJob_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(12, 39);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(818, 658);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // btnStopAllJob
            // 
            btnStopAllJob.Location = new Point(174, 12);
            btnStopAllJob.Name = "btnStopAllJob";
            btnStopAllJob.Size = new Size(75, 23);
            btnStopAllJob.TabIndex = 5;
            btnStopAllJob.Text = "Dừng tất cả";
            btnStopAllJob.UseVisualStyleBackColor = true;
            btnStopAllJob.Click += btnStopAllJob_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1712, 709);
            Controls.Add(btnStopAllJob);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btnStartAllJob);
            Controls.Add(btnAddJob);
            Controls.Add(rTBConsoleLog);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            Text = "Techplus";
            Shown += Form1_Shown;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rTBConsoleLog;
        private Button btnAddJob;
        private Button btnStartAllJob;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnStopAllJob;
    }
}