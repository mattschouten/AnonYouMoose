namespace AnonYouMoose
{
    partial class Form1
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
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnAnonymize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(427, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drag some Word documents or a directory containing Word documents onto this windo" +
    "w.";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(12, 38);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(440, 20);
            this.txtPath.TabIndex = 1;
            // 
            // btnAnonymize
            // 
            this.btnAnonymize.Location = new System.Drawing.Point(15, 64);
            this.btnAnonymize.Name = "btnAnonymize";
            this.btnAnonymize.Size = new System.Drawing.Size(75, 23);
            this.btnAnonymize.TabIndex = 2;
            this.btnAnonymize.Text = "Anonymize";
            this.btnAnonymize.UseVisualStyleBackColor = true;
            this.btnAnonymize.Click += new System.EventHandler(this.btnAnonymize_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 262);
            this.Controls.Add(this.btnAnonymize);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Anon, You Moose!";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnAnonymize;
    }
}

