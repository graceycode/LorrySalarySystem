namespace LorrySalarySystem_dev
{
    partial class ResetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPassword));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtcurrpassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnSubmitPW = new System.Windows.Forms.Button();
            this.txtnewpassword2 = new System.Windows.Forms.TextBox();
            this.txtnewpassword = new System.Windows.Forms.TextBox();
            this.lblnewpassword2 = new System.Windows.Forms.Label();
            this.lblnewpassword = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.txtusername);
            this.groupBox1.Controls.Add(this.txtcurrpassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblMessage);
            this.groupBox1.Controls.Add(this.btnSubmitPW);
            this.groupBox1.Controls.Add(this.txtnewpassword2);
            this.groupBox1.Controls.Add(this.txtnewpassword);
            this.groupBox1.Controls.Add(this.lblnewpassword2);
            this.groupBox1.Controls.Add(this.lblnewpassword);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(71, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 241);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reset Password";
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(162, 37);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(208, 22);
            this.txtusername.TabIndex = 9;
            // 
            // txtcurrpassword
            // 
            this.txtcurrpassword.Location = new System.Drawing.Point(162, 71);
            this.txtcurrpassword.Name = "txtcurrpassword";
            this.txtcurrpassword.PasswordChar = '*';
            this.txtcurrpassword.Size = new System.Drawing.Size(208, 22);
            this.txtcurrpassword.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Username :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Current Password : ";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Maroon;
            this.lblMessage.Location = new System.Drawing.Point(66, 171);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(51, 16);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "label3";
            this.lblMessage.Visible = false;
            // 
            // btnSubmitPW
            // 
            this.btnSubmitPW.Location = new System.Drawing.Point(294, 186);
            this.btnSubmitPW.Name = "btnSubmitPW";
            this.btnSubmitPW.Size = new System.Drawing.Size(75, 30);
            this.btnSubmitPW.TabIndex = 13;
            this.btnSubmitPW.Text = "Submit";
            this.btnSubmitPW.UseVisualStyleBackColor = true;
            this.btnSubmitPW.Click += new System.EventHandler(this.btnSubmitPW_Click);
            // 
            // txtnewpassword2
            // 
            this.txtnewpassword2.Location = new System.Drawing.Point(161, 136);
            this.txtnewpassword2.Name = "txtnewpassword2";
            this.txtnewpassword2.PasswordChar = '*';
            this.txtnewpassword2.Size = new System.Drawing.Size(208, 22);
            this.txtnewpassword2.TabIndex = 12;
            // 
            // txtnewpassword
            // 
            this.txtnewpassword.Location = new System.Drawing.Point(161, 104);
            this.txtnewpassword.Name = "txtnewpassword";
            this.txtnewpassword.PasswordChar = '*';
            this.txtnewpassword.Size = new System.Drawing.Size(208, 22);
            this.txtnewpassword.TabIndex = 11;
            // 
            // lblnewpassword2
            // 
            this.lblnewpassword2.AutoSize = true;
            this.lblnewpassword2.Location = new System.Drawing.Point(38, 140);
            this.lblnewpassword2.Name = "lblnewpassword2";
            this.lblnewpassword2.Size = new System.Drawing.Size(110, 16);
            this.lblnewpassword2.TabIndex = 1;
            this.lblnewpassword2.Text = "Retype Again :";
            // 
            // lblnewpassword
            // 
            this.lblnewpassword.AutoSize = true;
            this.lblnewpassword.Location = new System.Drawing.Point(32, 104);
            this.lblnewpassword.Name = "lblnewpassword";
            this.lblnewpassword.Size = new System.Drawing.Size(118, 16);
            this.lblnewpassword.TabIndex = 0;
            this.lblnewpassword.Text = "New Password :";
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 261);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ResetPassword";
            this.Text = "Reset Password";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtcurrpassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnSubmitPW;
        private System.Windows.Forms.TextBox txtnewpassword2;
        private System.Windows.Forms.TextBox txtnewpassword;
        private System.Windows.Forms.Label lblnewpassword2;
        private System.Windows.Forms.Label lblnewpassword;
    }
}