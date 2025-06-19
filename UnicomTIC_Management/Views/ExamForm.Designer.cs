namespace UnicomTIC_Management.Views
{
    partial class ExamForm
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
            this.txtExamName = new System.Windows.Forms.TextBox();
            this.txtMaxMarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbExamType = new System.Windows.Forms.ComboBox();
            this.mbSubject = new System.Windows.Forms.ComboBox();
            this.comboCourse = new System.Windows.Forms.ComboBox();
            this.dgvExams = new System.Windows.Forms.DateTimePicker();
            this.examsView = new System.Windows.Forms.DataGridView();
            this.cmbCourse = new System.Windows.Forms.Label();
            this.cmbSubject = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.examsView)).BeginInit();
            this.SuspendLayout();
            // 
            // txtExamName
            // 
            this.txtExamName.Location = new System.Drawing.Point(275, 58);
            this.txtExamName.Name = "txtExamName";
            this.txtExamName.Size = new System.Drawing.Size(100, 20);
            this.txtExamName.TabIndex = 0;
            // 
            // txtMaxMarks
            // 
            this.txtMaxMarks.Location = new System.Drawing.Point(275, 84);
            this.txtMaxMarks.Name = "txtMaxMarks";
            this.txtMaxMarks.Size = new System.Drawing.Size(100, 20);
            this.txtMaxMarks.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ExamName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "MaxMarks";
            // 
            // cmbExamType
            // 
            this.cmbExamType.FormattingEnabled = true;
            this.cmbExamType.Location = new System.Drawing.Point(275, 185);
            this.cmbExamType.Name = "cmbExamType";
            this.cmbExamType.Size = new System.Drawing.Size(121, 21);
            this.cmbExamType.TabIndex = 4;
            // 
            // mbSubject
            // 
            this.mbSubject.FormattingEnabled = true;
            this.mbSubject.Location = new System.Drawing.Point(275, 150);
            this.mbSubject.Name = "mbSubject";
            this.mbSubject.Size = new System.Drawing.Size(121, 21);
            this.mbSubject.TabIndex = 5;
            // 
            // comboCourse
            // 
            this.comboCourse.FormattingEnabled = true;
            this.comboCourse.Location = new System.Drawing.Point(275, 118);
            this.comboCourse.Name = "comboCourse";
            this.comboCourse.Size = new System.Drawing.Size(121, 21);
            this.comboCourse.TabIndex = 6;
            this.comboCourse.SelectedIndexChanged += new System.EventHandler(this.comboCourse_SelectedIndexChanged);
            // 
            // dgvExams
            // 
            this.dgvExams.Location = new System.Drawing.Point(275, 214);
            this.dgvExams.Name = "dgvExams";
            this.dgvExams.Size = new System.Drawing.Size(200, 20);
            this.dgvExams.TabIndex = 7;
            this.dgvExams.ValueChanged += new System.EventHandler(this.dgvExams_ValueChanged);
            // 
            // examsView
            // 
            this.examsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.examsView.Location = new System.Drawing.Point(235, 288);
            this.examsView.Name = "examsView";
            this.examsView.Size = new System.Drawing.Size(240, 150);
            this.examsView.TabIndex = 8;
            this.examsView.SelectionChanged += new System.EventHandler(this.examsView_SelectionChanged);
            // 
            // cmbCourse
            // 
            this.cmbCourse.AutoSize = true;
            this.cmbCourse.Location = new System.Drawing.Point(201, 121);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(40, 13);
            this.cmbCourse.TabIndex = 9;
            this.cmbCourse.Text = "Course";
            // 
            // cmbSubject
            // 
            this.cmbSubject.AutoSize = true;
            this.cmbSubject.Location = new System.Drawing.Point(201, 153);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(43, 13);
            this.cmbSubject.TabIndex = 10;
            this.cmbSubject.Text = "Subject";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "ExamType";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "ExamDate";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(165, 254);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(257, 254);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(350, 254);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(444, 254);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ExamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.cmbCourse);
            this.Controls.Add(this.examsView);
            this.Controls.Add(this.dgvExams);
            this.Controls.Add(this.comboCourse);
            this.Controls.Add(this.mbSubject);
            this.Controls.Add(this.cmbExamType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaxMarks);
            this.Controls.Add(this.txtExamName);
            this.Name = "ExamForm";
            this.Text = "ExamForm";
            ((System.ComponentModel.ISupportInitialize)(this.examsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtExamName;
        private System.Windows.Forms.TextBox txtMaxMarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbExamType;
        private System.Windows.Forms.ComboBox mbSubject;
        private System.Windows.Forms.ComboBox comboCourse;
        private System.Windows.Forms.DateTimePicker dgvExams;
        private System.Windows.Forms.DataGridView examsView;
        private System.Windows.Forms.Label cmbCourse;
        private System.Windows.Forms.Label cmbSubject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
    }
}