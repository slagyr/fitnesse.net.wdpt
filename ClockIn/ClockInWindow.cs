using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClockIn
{
	public class ClockInWindow : System.Windows.Forms.Form, ClockInView
	{
		public System.Windows.Forms.Label usernameLabel;
		public System.Windows.Forms.TextBox usernameTextBox;
		public System.Windows.Forms.Label passwordLabel;
		public System.Windows.Forms.TextBox passwordTextBox;
		public System.Windows.Forms.Button loginButton;
		public System.Windows.Forms.TextBox loginMessageTextBox;
		public System.Windows.Forms.GroupBox loginGroupBox;
		public System.Windows.Forms.Label currentUserLabel;
		public System.Windows.Forms.Label clockedInLabel;
		public System.Windows.Forms.Label clockedInAnswerLabel;
		public System.Windows.Forms.Label clockedInTimeAnswerLabel;
		public System.Windows.Forms.Label clockedInTimeLabel;
		public System.Windows.Forms.Label clockedOutTimeAnswerLabel;
		public System.Windows.Forms.Label clockedOutTimeLabel;
		public System.Windows.Forms.Label hoursWorkedAnswerLabel;
		public System.Windows.Forms.Label hoursWorkedLabel;
		private System.ComponentModel.Container components = null;
		private LoginListener loginListener;

		public ClockInWindow()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.usernameTextBox = new System.Windows.Forms.TextBox();
			this.usernameLabel = new System.Windows.Forms.Label();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.loginButton = new System.Windows.Forms.Button();
			this.loginMessageTextBox = new System.Windows.Forms.TextBox();
			this.loginGroupBox = new System.Windows.Forms.GroupBox();
			this.hoursWorkedAnswerLabel = new System.Windows.Forms.Label();
			this.hoursWorkedLabel = new System.Windows.Forms.Label();
			this.clockedOutTimeAnswerLabel = new System.Windows.Forms.Label();
			this.clockedOutTimeLabel = new System.Windows.Forms.Label();
			this.clockedInTimeAnswerLabel = new System.Windows.Forms.Label();
			this.clockedInTimeLabel = new System.Windows.Forms.Label();
			this.clockedInAnswerLabel = new System.Windows.Forms.Label();
			this.clockedInLabel = new System.Windows.Forms.Label();
			this.currentUserLabel = new System.Windows.Forms.Label();
			this.loginGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// usernameTextBox
			// 
			this.usernameTextBox.Location = new System.Drawing.Point(80, 16);
			this.usernameTextBox.Name = "usernameTextBox";
			this.usernameTextBox.Size = new System.Drawing.Size(128, 20);
			this.usernameTextBox.TabIndex = 0;
			this.usernameTextBox.Text = "";
			this.usernameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			// 
			// usernameLabel
			// 
			this.usernameLabel.Location = new System.Drawing.Point(8, 16);
			this.usernameLabel.Name = "usernameLabel";
			this.usernameLabel.Size = new System.Drawing.Size(64, 24);
			this.usernameLabel.TabIndex = 1;
			this.usernameLabel.Text = "Username:";
			this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// passwordLabel
			// 
			this.passwordLabel.Location = new System.Drawing.Point(8, 48);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(64, 24);
			this.passwordLabel.TabIndex = 3;
			this.passwordLabel.Text = "Password:";
			this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Location = new System.Drawing.Point(80, 48);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.PasswordChar = '*';
			this.passwordTextBox.Size = new System.Drawing.Size(128, 20);
			this.passwordTextBox.TabIndex = 2;
			this.passwordTextBox.Text = "";
			this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			// 
			// loginButton
			// 
			this.loginButton.Location = new System.Drawing.Point(120, 80);
			this.loginButton.Name = "loginButton";
			this.loginButton.Size = new System.Drawing.Size(88, 24);
			this.loginButton.TabIndex = 4;
			this.loginButton.Text = "Login";
			this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
			// 
			// loginMessageTextBox
			// 
			this.loginMessageTextBox.BackColor = System.Drawing.SystemColors.Control;
			this.loginMessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.loginMessageTextBox.Location = new System.Drawing.Point(8, 120);
			this.loginMessageTextBox.Name = "loginMessageTextBox";
			this.loginMessageTextBox.Size = new System.Drawing.Size(200, 13);
			this.loginMessageTextBox.TabIndex = 5;
			this.loginMessageTextBox.Text = "Please login";
			this.loginMessageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// loginGroupBox
			// 
			this.loginGroupBox.Controls.Add(this.hoursWorkedAnswerLabel);
			this.loginGroupBox.Controls.Add(this.hoursWorkedLabel);
			this.loginGroupBox.Controls.Add(this.clockedOutTimeAnswerLabel);
			this.loginGroupBox.Controls.Add(this.clockedOutTimeLabel);
			this.loginGroupBox.Controls.Add(this.clockedInTimeAnswerLabel);
			this.loginGroupBox.Controls.Add(this.clockedInTimeLabel);
			this.loginGroupBox.Controls.Add(this.clockedInAnswerLabel);
			this.loginGroupBox.Controls.Add(this.clockedInLabel);
			this.loginGroupBox.Controls.Add(this.currentUserLabel);
			this.loginGroupBox.Location = new System.Drawing.Point(224, 8);
			this.loginGroupBox.Name = "loginGroupBox";
			this.loginGroupBox.Size = new System.Drawing.Size(232, 136);
			this.loginGroupBox.TabIndex = 6;
			this.loginGroupBox.TabStop = false;
			this.loginGroupBox.Text = "Current User";
			// 
			// hoursWorkedAnswerLabel
			// 
			this.hoursWorkedAnswerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.hoursWorkedAnswerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hoursWorkedAnswerLabel.Location = new System.Drawing.Point(128, 104);
			this.hoursWorkedAnswerLabel.Name = "hoursWorkedAnswerLabel";
			this.hoursWorkedAnswerLabel.Size = new System.Drawing.Size(96, 16);
			this.hoursWorkedAnswerLabel.TabIndex = 8;
			this.hoursWorkedAnswerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// hoursWorkedLabel
			// 
			this.hoursWorkedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.hoursWorkedLabel.Location = new System.Drawing.Point(8, 104);
			this.hoursWorkedLabel.Name = "hoursWorkedLabel";
			this.hoursWorkedLabel.Size = new System.Drawing.Size(112, 16);
			this.hoursWorkedLabel.TabIndex = 7;
			this.hoursWorkedLabel.Text = "Hours Worked:";
			this.hoursWorkedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// clockedOutTimeAnswerLabel
			// 
			this.clockedOutTimeAnswerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.clockedOutTimeAnswerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.clockedOutTimeAnswerLabel.Location = new System.Drawing.Point(128, 88);
			this.clockedOutTimeAnswerLabel.Name = "clockedOutTimeAnswerLabel";
			this.clockedOutTimeAnswerLabel.Size = new System.Drawing.Size(96, 16);
			this.clockedOutTimeAnswerLabel.TabIndex = 6;
			this.clockedOutTimeAnswerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// clockedOutTimeLabel
			// 
			this.clockedOutTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.clockedOutTimeLabel.Location = new System.Drawing.Point(8, 88);
			this.clockedOutTimeLabel.Name = "clockedOutTimeLabel";
			this.clockedOutTimeLabel.Size = new System.Drawing.Size(112, 16);
			this.clockedOutTimeLabel.TabIndex = 5;
			this.clockedOutTimeLabel.Text = "Clock Out Time:";
			this.clockedOutTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// clockedInTimeAnswerLabel
			// 
			this.clockedInTimeAnswerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.clockedInTimeAnswerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.clockedInTimeAnswerLabel.Location = new System.Drawing.Point(128, 72);
			this.clockedInTimeAnswerLabel.Name = "clockedInTimeAnswerLabel";
			this.clockedInTimeAnswerLabel.Size = new System.Drawing.Size(96, 16);
			this.clockedInTimeAnswerLabel.TabIndex = 4;
			this.clockedInTimeAnswerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// clockedInTimeLabel
			// 
			this.clockedInTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.clockedInTimeLabel.Location = new System.Drawing.Point(8, 72);
			this.clockedInTimeLabel.Name = "clockedInTimeLabel";
			this.clockedInTimeLabel.Size = new System.Drawing.Size(112, 16);
			this.clockedInTimeLabel.TabIndex = 3;
			this.clockedInTimeLabel.Text = "Clock In Time:";
			this.clockedInTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// clockedInAnswerLabel
			// 
			this.clockedInAnswerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.clockedInAnswerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.clockedInAnswerLabel.Location = new System.Drawing.Point(128, 56);
			this.clockedInAnswerLabel.Name = "clockedInAnswerLabel";
			this.clockedInAnswerLabel.Size = new System.Drawing.Size(96, 16);
			this.clockedInAnswerLabel.TabIndex = 2;
			this.clockedInAnswerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// clockedInLabel
			// 
			this.clockedInLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.clockedInLabel.Location = new System.Drawing.Point(8, 56);
			this.clockedInLabel.Name = "clockedInLabel";
			this.clockedInLabel.Size = new System.Drawing.Size(112, 16);
			this.clockedInLabel.TabIndex = 1;
			this.clockedInLabel.Text = "Clocked In:";
			this.clockedInLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// currentUserLabel
			// 
			this.currentUserLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.currentUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.currentUserLabel.Location = new System.Drawing.Point(8, 16);
			this.currentUserLabel.Name = "currentUserLabel";
			this.currentUserLabel.Size = new System.Drawing.Size(216, 32);
			this.currentUserLabel.TabIndex = 0;
			this.currentUserLabel.Text = "None";
			this.currentUserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ClockInWindow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 150);
			this.Controls.Add(this.loginGroupBox);
			this.Controls.Add(this.loginMessageTextBox);
			this.Controls.Add(this.loginButton);
			this.Controls.Add(this.passwordLabel);
			this.Controls.Add(this.passwordTextBox);
			this.Controls.Add(this.usernameLabel);
			this.Controls.Add(this.usernameTextBox);
			this.MaximumSize = new System.Drawing.Size(472, 184);
			this.MinimumSize = new System.Drawing.Size(472, 184);
			this.Name = "ClockInWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ClockIn";
			this.loginGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion]

		private void loginButton_Click(object sender, System.EventArgs e)
		{
			if(loginListener != null)
				loginListener.LoginAttempted(usernameTextBox.Text, passwordTextBox.Text);
			usernameTextBox.Text = "";
			passwordTextBox.Text = "";
			usernameTextBox.Focus();
		}

		private void textBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
				loginButton.PerformClick();
		}

		public void Clear()
		{
			currentUserLabel.Text = "";
			clockedInAnswerLabel.Text = "";
			clockedInTimeAnswerLabel.Text = "";
			clockedOutTimeAnswerLabel.Text = "";
			hoursWorkedAnswerLabel.Text = "";
		}

		public string Username
		{
			set { currentUserLabel.Text = value; }
		}

		public bool ClockedIn
		{
			set { clockedInAnswerLabel.Text = value ? "Yes" : "No"; }
		}

		public DateTime ClockInTime
		{
			set { clockedInTimeAnswerLabel.Text = value.ToString("H:mm"); }
		}

		public DateTime ClockOutTime
		{
			set { clockedOutTimeAnswerLabel.Text = value.ToString("H:mm"); }
		}

		public double HoursWorked
		{
			set { hoursWorkedAnswerLabel.Text = value.ToString("#0.0"); }
		}

		public bool ValidLogin
		{
			set
			{
				if(value)
				{
					loginMessageTextBox.Text = "Valid Login";
					loginMessageTextBox.ForeColor = Color.Green;
				}
				else
				{
					loginMessageTextBox.Text = "Invalid Login";
					loginMessageTextBox.ForeColor = Color.Red;
				}

			}
		}

		public LoginListener LoginListener
		{
			set { loginListener = value; }
		}
	}
}
