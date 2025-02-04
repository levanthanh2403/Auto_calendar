namespace schedule.auto.Control
{
    partial class ListTasks
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListTasks));
            txtIpSource = new TextBox();
            label1 = new Label();
            txtPathSource = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtPathDestination = new TextBox();
            txtIpDestination = new TextBox();
            cbbFrequency = new ComboBox();
            label5 = new Label();
            txtDateExec = new TextBox();
            label6 = new Label();
            txtTimeExec = new TextBox();
            label7 = new Label();
            label8 = new Label();
            cbbStatus = new ComboBox();
            btnClosed = new Button();
            txtJobName = new TextBox();
            label9 = new Label();
            txtJobId = new TextBox();
            label10 = new Label();
            folderBrowserSource = new FolderBrowserDialog();
            folderBrowserDestination = new FolderBrowserDialog();
            btnFolderDestination = new Button();
            btnFolderSource = new Button();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            lbDateExec = new Label();
            label20 = new Label();
            label21 = new Label();
            btnSave = new Button();
            SuspendLayout();
            // 
            // txtIpSource
            // 
            txtIpSource.Location = new Point(5, 66);
            txtIpSource.Name = "txtIpSource";
            txtIpSource.Size = new Size(190, 23);
            txtIpSource.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 48);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 1;
            label1.Text = "IP máy nguồn";
            // 
            // txtPathSource
            // 
            txtPathSource.Location = new Point(201, 66);
            txtPathSource.Name = "txtPathSource";
            txtPathSource.Size = new Size(486, 23);
            txtPathSource.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(201, 48);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 2;
            label2.Text = "Thư mục nguồn";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(201, 92);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 6;
            label3.Text = "Thư mục đích";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(5, 92);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 5;
            label4.Text = "IP máy đích";
            // 
            // txtPathDestination
            // 
            txtPathDestination.Location = new Point(201, 110);
            txtPathDestination.Name = "txtPathDestination";
            txtPathDestination.Size = new Size(486, 23);
            txtPathDestination.TabIndex = 4;
            // 
            // txtIpDestination
            // 
            txtIpDestination.Location = new Point(5, 110);
            txtIpDestination.Name = "txtIpDestination";
            txtIpDestination.Size = new Size(190, 23);
            txtIpDestination.TabIndex = 3;
            // 
            // cbbFrequency
            // 
            cbbFrequency.FormattingEnabled = true;
            cbbFrequency.Location = new Point(5, 154);
            cbbFrequency.Name = "cbbFrequency";
            cbbFrequency.Size = new Size(190, 23);
            cbbFrequency.TabIndex = 6;
            cbbFrequency.SelectionChangeCommitted += cbbFrequency_SelectionChangeCommitted;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(5, 136);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 6;
            label5.Text = "Tần suất";
            // 
            // txtDateExec
            // 
            txtDateExec.Location = new Point(201, 154);
            txtDateExec.Name = "txtDateExec";
            txtDateExec.Size = new Size(190, 23);
            txtDateExec.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(201, 136);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 5;
            label6.Text = "Ngày chạy";
            // 
            // txtTimeExec
            // 
            txtTimeExec.Location = new Point(397, 154);
            txtTimeExec.Name = "txtTimeExec";
            txtTimeExec.Size = new Size(190, 23);
            txtTimeExec.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(397, 136);
            label7.Name = "label7";
            label7.Size = new Size(53, 15);
            label7.TabIndex = 5;
            label7.Text = "Giờ chạy";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(593, 136);
            label8.Name = "label8";
            label8.Size = new Size(59, 15);
            label8.TabIndex = 6;
            label8.Text = "Trạng thái";
            // 
            // cbbStatus
            // 
            cbbStatus.Enabled = false;
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Location = new Point(593, 154);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(190, 23);
            cbbStatus.TabIndex = 5;
            cbbStatus.SelectedValueChanged += cbbStatus_SelectedValueChanged;
            // 
            // btnClosed
            // 
            btnClosed.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            btnClosed.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnClosed.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnClosed.FlatStyle = FlatStyle.Flat;
            btnClosed.Image = (Image)resources.GetObject("btnClosed.Image");
            btnClosed.Location = new Point(758, 4);
            btnClosed.Name = "btnClosed";
            btnClosed.Size = new Size(25, 23);
            btnClosed.TabIndex = 9;
            btnClosed.UseVisualStyleBackColor = true;
            btnClosed.Click += btnClosed_Click;
            // 
            // txtJobName
            // 
            txtJobName.Location = new Point(5, 22);
            txtJobName.Name = "txtJobName";
            txtJobName.Size = new Size(190, 23);
            txtJobName.TabIndex = 0;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(5, 4);
            label9.Name = "label9";
            label9.Size = new Size(45, 15);
            label9.TabIndex = 1;
            label9.Text = "Tên job";
            // 
            // txtJobId
            // 
            txtJobId.Enabled = false;
            txtJobId.Location = new Point(201, 22);
            txtJobId.Name = "txtJobId";
            txtJobId.Size = new Size(386, 23);
            txtJobId.TabIndex = 0;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(201, 4);
            label10.Name = "label10";
            label10.Size = new Size(45, 15);
            label10.TabIndex = 1;
            label10.Text = "Mã Job";
            // 
            // btnFolderDestination
            // 
            btnFolderDestination.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            btnFolderDestination.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnFolderDestination.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnFolderDestination.FlatStyle = FlatStyle.Flat;
            btnFolderDestination.Image = (Image)resources.GetObject("btnFolderDestination.Image");
            btnFolderDestination.Location = new Point(758, 109);
            btnFolderDestination.Name = "btnFolderDestination";
            btnFolderDestination.Size = new Size(25, 24);
            btnFolderDestination.TabIndex = 10;
            btnFolderDestination.UseVisualStyleBackColor = true;
            btnFolderDestination.Visible = false;
            btnFolderDestination.Click += btnFolderDestination_Click;
            // 
            // btnFolderSource
            // 
            btnFolderSource.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            btnFolderSource.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnFolderSource.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnFolderSource.FlatStyle = FlatStyle.Flat;
            btnFolderSource.Image = (Image)resources.GetObject("btnFolderSource.Image");
            btnFolderSource.Location = new Point(758, 65);
            btnFolderSource.Name = "btnFolderSource";
            btnFolderSource.Size = new Size(25, 24);
            btnFolderSource.TabIndex = 9;
            btnFolderSource.UseVisualStyleBackColor = true;
            btnFolderSource.Visible = false;
            btnFolderSource.Click += btnFolderSource_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.Red;
            label11.Location = new Point(54, 4);
            label11.Name = "label11";
            label11.Size = new Size(20, 15);
            label11.TabIndex = 11;
            label11.Text = "(*)";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = Color.Red;
            label12.Location = new Point(252, 4);
            label12.Name = "label12";
            label12.Size = new Size(20, 15);
            label12.TabIndex = 12;
            label12.Text = "(*)";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = Color.Red;
            label13.Location = new Point(92, 48);
            label13.Name = "label13";
            label13.Size = new Size(20, 15);
            label13.TabIndex = 13;
            label13.Text = "(*)";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ForeColor = Color.Red;
            label14.Location = new Point(299, 48);
            label14.Name = "label14";
            label14.Size = new Size(20, 15);
            label14.TabIndex = 14;
            label14.Text = "(*)";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.ForeColor = Color.Red;
            label15.Location = new Point(80, 92);
            label15.Name = "label15";
            label15.Size = new Size(20, 15);
            label15.TabIndex = 15;
            label15.Text = "(*)";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.ForeColor = Color.Red;
            label16.Location = new Point(287, 92);
            label16.Name = "label16";
            label16.Size = new Size(20, 15);
            label16.TabIndex = 16;
            label16.Text = "(*)";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.ForeColor = Color.Red;
            label17.Location = new Point(658, 136);
            label17.Name = "label17";
            label17.Size = new Size(20, 15);
            label17.TabIndex = 17;
            label17.Text = "(*)";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.ForeColor = Color.Red;
            label18.Location = new Point(62, 136);
            label18.Name = "label18";
            label18.Size = new Size(20, 15);
            label18.TabIndex = 18;
            label18.Text = "(*)";
            // 
            // lbDateExec
            // 
            lbDateExec.AutoSize = true;
            lbDateExec.ForeColor = Color.Red;
            lbDateExec.Location = new Point(270, 136);
            lbDateExec.Name = "lbDateExec";
            lbDateExec.Size = new Size(20, 15);
            lbDateExec.TabIndex = 19;
            lbDateExec.Text = "(*)";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.ForeColor = Color.Red;
            label20.Location = new Point(456, 136);
            label20.Name = "label20";
            label20.Size = new Size(20, 15);
            label20.TabIndex = 20;
            label20.Text = "(*)";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(534, 136);
            label21.Name = "label21";
            label21.Size = new Size(50, 15);
            label21.TabIndex = 21;
            label21.Text = "HH:mm";
            // 
            // btnSave
            // 
            btnSave.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            btnSave.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSave.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.Location = new Point(727, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(25, 23);
            btnSave.TabIndex = 22;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ListTasks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btnSave);
            Controls.Add(label21);
            Controls.Add(label20);
            Controls.Add(lbDateExec);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(btnFolderDestination);
            Controls.Add(btnFolderSource);
            Controls.Add(btnClosed);
            Controls.Add(cbbStatus);
            Controls.Add(label8);
            Controls.Add(cbbFrequency);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(txtPathDestination);
            Controls.Add(txtTimeExec);
            Controls.Add(txtDateExec);
            Controls.Add(txtIpDestination);
            Controls.Add(label2);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label1);
            Controls.Add(txtJobId);
            Controls.Add(txtJobName);
            Controls.Add(txtPathSource);
            Controls.Add(txtIpSource);
            Name = "ListTasks";
            Size = new Size(791, 183);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIpSource;
        private Label label1;
        private TextBox txtPathSource;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtPathDestination;
        private TextBox txtIpDestination;
        private ComboBox cbbFrequency;
        private Label label5;
        private TextBox txtDateExec;
        private Label label6;
        private TextBox txtTimeExec;
        private Label label7;
        private Label label8;
        private ComboBox cbbStatus;
        private Button btnClosed;
        private TextBox txtJobName;
        private Label label9;
        private TextBox txtJobId;
        private Label label10;
        private FolderBrowserDialog folderBrowserSource;
        private FolderBrowserDialog folderBrowserDestination;
        private Button btnFolderSource;
        private Button btnFolderDestination;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label lbDateExec;
        private Label label20;
        private Label label21;
        private Button btnSave;
    }
}
