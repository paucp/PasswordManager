namespace PasswordManager
{
    partial class EntryForm
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
            this.textBoxPWRepeat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.checkBoxShowPasswords = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPWRepeat
            // 
            this.textBoxPWRepeat.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.textBoxPWRepeat.Location = new System.Drawing.Point(143, 248);
            this.textBoxPWRepeat.MaxLength = 128;
            this.textBoxPWRepeat.Name = "textBoxPWRepeat";
            this.textBoxPWRepeat.Size = new System.Drawing.Size(306, 23);
            this.textBoxPWRepeat.TabIndex = 23;
            this.textBoxPWRepeat.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "Repeat Password:*";
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(143, 156);
            this.textBoxURL.MaxLength = 256;
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(306, 23);
            this.textBoxURL.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "URL: ";
            // 
            // textBoxComment
            // 
            this.textBoxComment.Location = new System.Drawing.Point(143, 117);
            this.textBoxComment.MaxLength = 256;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(306, 23);
            this.textBoxComment.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Comment:";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(143, 78);
            this.textBoxUser.MaxLength = 128;
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(306, 23);
            this.textBoxUser.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "User:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(143, 40);
            this.textBoxName.MaxLength = 128;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(306, 23);
            this.textBoxName.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Entry name:*\r\n";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(-2, -3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(537, 30);
            this.panel2.TabIndex = 24;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.textBoxPassword.Location = new System.Drawing.Point(143, 202);
            this.textBoxPassword.MaxLength = 128;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(306, 23);
            this.textBoxPassword.TabIndex = 21;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Password:*";
            // 
            // buttonAccept
            // 
            this.buttonAccept.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonAccept.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonAccept.FlatAppearance.BorderSize = 0;
            this.buttonAccept.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.buttonAccept.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccept.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAccept.Location = new System.Drawing.Point(357, 333);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(92, 34);
            this.buttonAccept.TabIndex = 31;
            this.buttonAccept.TabStop = false;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = false;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(259, 333);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(92, 34);
            this.buttonCancel.TabIndex = 30;
            this.buttonCancel.TabStop = false;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(15, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(238, 32);
            this.button1.TabIndex = 32;
            this.button1.TabStop = false;
            this.button1.Text = "Generate random password";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 294);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 17);
            this.label7.TabIndex = 33;
            this.label7.Text = "Random password length";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(179, 286);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(90, 23);
            this.numericUpDown1.TabIndex = 34;
            this.numericUpDown1.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // checkBoxShowPasswords
            // 
            this.checkBoxShowPasswords.AutoSize = true;
            this.checkBoxShowPasswords.Location = new System.Drawing.Point(297, 290);
            this.checkBoxShowPasswords.Name = "checkBoxShowPasswords";
            this.checkBoxShowPasswords.Size = new System.Drawing.Size(126, 21);
            this.checkBoxShowPasswords.TabIndex = 35;
            this.checkBoxShowPasswords.Text = "Show Passwords";
            this.checkBoxShowPasswords.UseVisualStyleBackColor = true;
            this.checkBoxShowPasswords.CheckedChanged += new System.EventHandler(this.checkBoxShowPasswords_CheckedChanged);
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(469, 381);
            this.Controls.Add(this.checkBoxShowPasswords);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxPWRepeat);
            this.Controls.Add(this.textBoxURL);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "EntryForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EntryForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPWRepeat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox checkBoxShowPasswords;
    }
}