namespace UIForm
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
            this.descriptionTxt = new System.Windows.Forms.TextBox();
            this.createBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.listBtn = new System.Windows.Forms.Button();
            this.prevBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.completedChb = new System.Windows.Forms.CheckBox();
            this.newBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // descriptionTxt
            // 
            this.descriptionTxt.Location = new System.Drawing.Point(25, 37);
            this.descriptionTxt.Name = "descriptionTxt";
            this.descriptionTxt.Size = new System.Drawing.Size(294, 20);
            this.descriptionTxt.TabIndex = 0;
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(26, 120);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(75, 23);
            this.createBtn.TabIndex = 3;
            this.createBtn.Text = "Create";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(129, 120);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 4;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            // 
            // listBtn
            // 
            this.listBtn.Location = new System.Drawing.Point(129, 179);
            this.listBtn.Name = "listBtn";
            this.listBtn.Size = new System.Drawing.Size(75, 23);
            this.listBtn.TabIndex = 5;
            this.listBtn.Text = "List";
            this.listBtn.UseVisualStyleBackColor = true;
            this.listBtn.Click += new System.EventHandler(this.listBtn_Click);
            // 
            // prevBtn
            // 
            this.prevBtn.Location = new System.Drawing.Point(25, 179);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(75, 23);
            this.prevBtn.TabIndex = 6;
            this.prevBtn.Text = "<<";
            this.prevBtn.UseVisualStyleBackColor = true;
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(244, 179);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(75, 23);
            this.nextBtn.TabIndex = 7;
            this.nextBtn.Text = ">>";
            this.nextBtn.UseVisualStyleBackColor = true;
            // 
            // completedChb
            // 
            this.completedChb.AutoSize = true;
            this.completedChb.Location = new System.Drawing.Point(25, 76);
            this.completedChb.Name = "completedChb";
            this.completedChb.Size = new System.Drawing.Size(76, 17);
            this.completedChb.TabIndex = 9;
            this.completedChb.Text = "Completed";
            this.completedChb.UseVisualStyleBackColor = true;
            this.completedChb.CheckedChanged += new System.EventHandler(this.completedChb_CheckedChanged);
            // 
            // newBtn
            // 
            this.newBtn.Location = new System.Drawing.Point(244, 120);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(75, 23);
            this.newBtn.TabIndex = 10;
            this.newBtn.Text = "New";
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 257);
            this.Controls.Add(this.newBtn);
            this.Controls.Add(this.completedChb);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.prevBtn);
            this.Controls.Add(this.listBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.descriptionTxt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox descriptionTxt;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button listBtn;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.CheckBox completedChb;
        private System.Windows.Forms.Button newBtn;
    }
}

