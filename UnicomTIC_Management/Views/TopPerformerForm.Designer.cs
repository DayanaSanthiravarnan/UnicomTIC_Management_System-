namespace UnicomTIC_Management.Views
{
    partial class TopPerformerForm
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
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.cmbExam = new System.Windows.Forms.ComboBox();
            this.dgvTopPerformers = new System.Windows.Forms.DataGridView();
            this.btnLoadTopPerformers = new System.Windows.Forms.Button();
            this.btnSaveToTopPerformers = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopPerformers)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSubject
            // 
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(183, 31);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(121, 21);
            this.cmbSubject.TabIndex = 0;
            this.cmbSubject.SelectedIndexChanged += new System.EventHandler(this.cmbSubject_SelectedIndexChanged);
            // 
            // cmbExam
            // 
            this.cmbExam.FormattingEnabled = true;
            this.cmbExam.Location = new System.Drawing.Point(183, 88);
            this.cmbExam.Name = "cmbExam";
            this.cmbExam.Size = new System.Drawing.Size(121, 21);
            this.cmbExam.TabIndex = 1;
            // 
            // dgvTopPerformers
            // 
            this.dgvTopPerformers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopPerformers.Location = new System.Drawing.Point(183, 228);
            this.dgvTopPerformers.Name = "dgvTopPerformers";
            this.dgvTopPerformers.Size = new System.Drawing.Size(240, 150);
            this.dgvTopPerformers.TabIndex = 2;
            this.dgvTopPerformers.SelectionChanged += new System.EventHandler(this.dgvTopPerformers_SelectionChanged);
            // 
            // btnLoadTopPerformers
            // 
            this.btnLoadTopPerformers.Location = new System.Drawing.Point(85, 160);
            this.btnLoadTopPerformers.Name = "btnLoadTopPerformers";
            this.btnLoadTopPerformers.Size = new System.Drawing.Size(158, 23);
            this.btnLoadTopPerformers.TabIndex = 3;
            this.btnLoadTopPerformers.Text = "LoadTopPerformers";
            this.btnLoadTopPerformers.UseVisualStyleBackColor = true;
            this.btnLoadTopPerformers.Click += new System.EventHandler(this.btnLoadTopPerformers_Click);
            // 
            // btnSaveToTopPerformers
            // 
            this.btnSaveToTopPerformers.Location = new System.Drawing.Point(294, 160);
            this.btnSaveToTopPerformers.Name = "btnSaveToTopPerformers";
            this.btnSaveToTopPerformers.Size = new System.Drawing.Size(75, 23);
            this.btnSaveToTopPerformers.TabIndex = 4;
            this.btnSaveToTopPerformers.Text = "SaveToTopPerformers";
            this.btnSaveToTopPerformers.UseVisualStyleBackColor = true;
            this.btnSaveToTopPerformers.Click += new System.EventHandler(this.btnSaveToTopPerformers_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Subject";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Exam";
            // 
            // TopPerformerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveToTopPerformers);
            this.Controls.Add(this.btnLoadTopPerformers);
            this.Controls.Add(this.dgvTopPerformers);
            this.Controls.Add(this.cmbExam);
            this.Controls.Add(this.cmbSubject);
            this.Name = "TopPerformerForm";
            this.Text = "TopPerformerForm";
            this.Load += new System.EventHandler(this.TopPerformerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopPerformers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.ComboBox cmbExam;
        private System.Windows.Forms.DataGridView dgvTopPerformers;
        private System.Windows.Forms.Button btnLoadTopPerformers;
        private System.Windows.Forms.Button btnSaveToTopPerformers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}