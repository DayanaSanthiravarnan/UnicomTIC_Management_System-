namespace UnicomTIC_Management.Views
{
    partial class TimeSlotForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.Label();
            this.dgvTimeSlots = new System.Windows.Forms.DataGridView();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tpEndTime = new System.Windows.Forms.DateTimePicker();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeSlots)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "StartTime\t";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.AutoSize = true;
            this.dtpEndTime.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.dtpEndTime.Location = new System.Drawing.Point(111, 104);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(49, 13);
            this.dtpEndTime.TabIndex = 1;
            this.dtpEndTime.Text = "EndTime";
            // 
            // dgvTimeSlots
            // 
            this.dgvTimeSlots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeSlots.Location = new System.Drawing.Point(167, 246);
            this.dgvTimeSlots.Name = "dgvTimeSlots";
            this.dgvTimeSlots.Size = new System.Drawing.Size(384, 173);
            this.dgvTimeSlots.TabIndex = 2;
            this.dgvTimeSlots.SelectionChanged += new System.EventHandler(this.dgvTimeSlots_SelectionChanged);
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "\"dd/MM/yyyy hh:mm tt\"";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(232, 64);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(200, 20);
            this.dtpStartTime.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(128, 160);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tpEndTime
            // 
            this.tpEndTime.CustomFormat = "\"dd/MM/yyyy hh:mm tt\"";
            this.tpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tpEndTime.Location = new System.Drawing.Point(232, 97);
            this.tpEndTime.Name = "tpEndTime";
            this.tpEndTime.Size = new System.Drawing.Size(200, 20);
            this.tpEndTime.TabIndex = 5;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(256, 160);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(376, 160);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // TimeSlotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tpEndTime);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.dgvTimeSlots);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.label1);
            this.Name = "TimeSlotForm";
            this.Text = "TimeSlotForm";
            this.Load += new System.EventHandler(this.TimeSlotForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeSlots)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label dtpEndTime;
        private System.Windows.Forms.DataGridView dgvTimeSlots;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DateTimePicker tpEndTime;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}