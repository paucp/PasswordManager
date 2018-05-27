namespace PasswordManager
{
    partial class ShowPasswordForm
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.labelPassword = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabelUser = new System.Windows.Forms.LinkLabel();
            this.linkLabelURL = new System.Windows.Forms.LinkLabel();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelURL = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password:";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(183, 117);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(92, 36);
            this.buttonClose.TabIndex = 33;
            this.buttonClose.TabStop = false;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonCopy
            // 
            this.buttonCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopy.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonCopy.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonCopy.FlatAppearance.BorderSize = 0;
            this.buttonCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.buttonCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCopy.Location = new System.Drawing.Point(12, 117);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(164, 36);
            this.buttonCopy.TabIndex = 32;
            this.buttonCopy.TabStop = false;
            this.buttonCopy.Text = "Copy Password";
            this.buttonCopy.UseVisualStyleBackColor = false;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(86, 33);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(60, 15);
            this.labelPassword.TabIndex = 34;
            this.labelPassword.Text = "password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 35;
            this.label2.Text = "User:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 16);
            this.label3.TabIndex = 36;
            this.label3.Text = "Url:";
            // 
            // linkLabelUser
            // 
            this.linkLabelUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelUser.AutoSize = true;
            this.linkLabelUser.Location = new System.Drawing.Point(239, 59);
            this.linkLabelUser.Name = "linkLabelUser";
            this.linkLabelUser.Size = new System.Drawing.Size(40, 16);
            this.linkLabelUser.TabIndex = 37;
            this.linkLabelUser.TabStop = true;
            this.linkLabelUser.Text = "Copy";
            this.linkLabelUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelUser_LinkClicked);
            // 
            // linkLabelURL
            // 
            this.linkLabelURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelURL.AutoSize = true;
            this.linkLabelURL.Location = new System.Drawing.Point(239, 87);
            this.linkLabelURL.Name = "linkLabelURL";
            this.linkLabelURL.Size = new System.Drawing.Size(40, 16);
            this.linkLabelURL.TabIndex = 38;
            this.linkLabelURL.TabStop = true;
            this.linkLabelURL.Text = "Copy";
            this.linkLabelURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelURL_LinkClicked);
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(86, 59);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(34, 16);
            this.labelUser.TabIndex = 39;
            this.labelUser.Text = "user";
            // 
            // labelURL
            // 
            this.labelURL.AutoSize = true;
            this.labelURL.Location = new System.Drawing.Point(86, 87);
            this.labelURL.Name = "labelURL";
            this.labelURL.Size = new System.Drawing.Size(35, 16);
            this.labelURL.TabIndex = 40;
            this.labelURL.Text = "URL";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 25);
            this.panel1.TabIndex = 41;
            // 
            // ShowPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(287, 163);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.linkLabelURL);
            this.Controls.Add(this.linkLabelUser);
            this.Controls.Add(this.labelURL);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ShowPasswordForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ShowPasswordForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabelUser;
        private System.Windows.Forms.LinkLabel linkLabelURL;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelURL;
        private System.Windows.Forms.Panel panel1;
    }
}