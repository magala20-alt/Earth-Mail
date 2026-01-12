namespace Postal_Management_System.Presentation.views
{
    partial class LoginView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            usernameTxt = new RichTextBox();
            passwordTxt = new TextBox();
            loginBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // usernameTxt
            // 
            usernameTxt.Location = new Point(71, 119);
            usernameTxt.Name = "usernameTxt";
            usernameTxt.Size = new Size(428, 43);
            usernameTxt.TabIndex = 0;
            usernameTxt.Text = "";
            // 
            // passwordTxt
            // 
            passwordTxt.Location = new Point(71, 222);
            passwordTxt.Name = "passwordTxt";
            passwordTxt.Size = new Size(428, 43);
            passwordTxt.TabIndex = 1;
            passwordTxt.Text = "";
            // 
            // loginBtn
            // 
            loginBtn.FlatStyle = FlatStyle.Flat;
            loginBtn.Font = new Font("Cooper Black", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginBtn.Location = new Point(224, 289);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(120, 46);
            loginBtn.TabIndex = 2;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cooper Black", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(77, 87);
            label1.Name = "label1";
            label1.Size = new Size(84, 17);
            label1.TabIndex = 3;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cooper Black", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(71, 187);
            label2.Name = "label2";
            label2.Size = new Size(101, 17);
            label2.TabIndex = 4;
            label2.Text = "Password**";
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(588, 384);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(loginBtn);
            Controls.Add(passwordTxt);
            Controls.Add(usernameTxt);
            Name = "LoginView";
            Text = "LoginView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox usernameTxt;
        private TextBox passwordTxt;
        private Button loginBtn;
        private Label label1;
        private Label label2;
    }
}