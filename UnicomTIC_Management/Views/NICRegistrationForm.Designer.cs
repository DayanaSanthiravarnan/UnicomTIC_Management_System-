namespace UnicomTIC_Management.Views
{
    partial class NICRegistrationForm
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
            this.txtNIC = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnMarkUsed = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvNICs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNICs)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNIC
            // 
            this.txtNIC.Location = new System.Drawing.Point(224, 34);
            this.txtNIC.Name = "txtNIC";
            this.txtNIC.Size = new System.Drawing.Size(100, 20);
            this.txtNIC.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(162, 96);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnMarkUsed
            // 
            this.btnMarkUsed.Location = new System.Drawing.Point(263, 96);
            this.btnMarkUsed.Name = "btnMarkUsed";
            this.btnMarkUsed.Size = new System.Drawing.Size(75, 23);
            this.btnMarkUsed.TabIndex = 2;
            this.btnMarkUsed.Text = "MarkUsed";
            this.btnMarkUsed.UseVisualStyleBackColor = true;
            this.btnMarkUsed.Click += new System.EventHandler(this.btnMarkUsed_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "NIC_NO";
            // 
            // dgvNICs
            // 
            this.dgvNICs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNICs.Location = new System.Drawing.Point(162, 197);
            this.dgvNICs.Name = "dgvNICs";
            this.dgvNICs.Size = new System.Drawing.Size(295, 150);
            this.dgvNICs.TabIndex = 4;
            // 
            // NICRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvNICs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMarkUsed);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNIC);
            this.Name = "NICRegistrationForm";
            this.Text = "NICRegistrationForm";
            this.Load += new System.EventHandler(this.NICRegistrationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNICs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNIC;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnMarkUsed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvNICs;
    }
}