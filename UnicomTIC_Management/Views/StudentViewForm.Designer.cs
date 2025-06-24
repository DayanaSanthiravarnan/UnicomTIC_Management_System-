namespace UnicomTIC_Management.Views
{
    partial class StudentViewForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblMainGroupID = new System.Windows.Forms.Label();
            this.lblCourseID = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblNIC = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblSubGroupID = new System.Windows.Forms.Label();
            this.dgvTimetable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimetable)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(148, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(197, 26);
            this.lblName.TabIndex = 11;
            // 
            // lblMainGroupID
            // 
            this.lblMainGroupID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainGroupID.Location = new System.Drawing.Point(148, 139);
            this.lblMainGroupID.Name = "lblMainGroupID";
            this.lblMainGroupID.Size = new System.Drawing.Size(111, 26);
            this.lblMainGroupID.TabIndex = 14;
            // 
            // lblCourseID
            // 
            this.lblCourseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseID.Location = new System.Drawing.Point(148, 113);
            this.lblCourseID.Name = "lblCourseID";
            this.lblCourseID.Size = new System.Drawing.Size(111, 26);
            this.lblCourseID.TabIndex = 15;
            // 
            // lblContact
            // 
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(148, 87);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(111, 26);
            this.lblContact.TabIndex = 16;
            // 
            // lblNIC
            // 
            this.lblNIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNIC.Location = new System.Drawing.Point(148, 61);
            this.lblNIC.Name = "lblNIC";
            this.lblNIC.Size = new System.Drawing.Size(111, 26);
            this.lblNIC.TabIndex = 17;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(148, 35);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(244, 26);
            this.lblEmail.TabIndex = 18;
            // 
            // lblSubGroupID
            // 
            this.lblSubGroupID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubGroupID.Location = new System.Drawing.Point(148, 165);
            this.lblSubGroupID.Name = "lblSubGroupID";
            this.lblSubGroupID.Size = new System.Drawing.Size(111, 26);
            this.lblSubGroupID.TabIndex = 19;
            // 
            // dgvTimetable
            // 
            this.dgvTimetable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimetable.Location = new System.Drawing.Point(431, 9);
            this.dgvTimetable.Name = "dgvTimetable";
            this.dgvTimetable.Size = new System.Drawing.Size(357, 205);
            this.dgvTimetable.TabIndex = 20;
            // 
            // StudentViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvTimetable);
            this.Controls.Add(this.lblSubGroupID);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblNIC);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblCourseID);
            this.Controls.Add(this.lblMainGroupID);
            this.Controls.Add(this.lblName);
            this.Name = "StudentViewForm";
            this.Text = "StudentViewForm";
            this.Load += new System.EventHandler(this.StudentViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimetable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMainGroupID;
        private System.Windows.Forms.Label lblCourseID;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblNIC;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblSubGroupID;
        private System.Windows.Forms.DataGridView dgvTimetable;
    }
}