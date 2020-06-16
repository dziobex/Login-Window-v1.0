using System;
using System.Windows.Forms;

namespace Login
{
    public partial class MainWindow : Form
    {
        User user;
        string h = System.IO.Path.GetDirectoryName(Application.StartupPath) + "\\users";
        string password;

        public MainWindow()
        {
            InitializeComponent();
            user = new User(h);
            passwordBox.PasswordChar = '*';
            passwordBox.MaxLength = 20;
        }

        private void createNewAccountBtn_Click(object sender, EventArgs e)
        {
            NewAccount na = new NewAccount();
            na.Show();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (user.LoadNewUser(loginBox.Text, password))
            {
                LoggedWindow lw = new LoggedWindow(loginBox.Text, user.CurrentFile);
                lw.Show();
            }
            else
            {
                loginBox.Text = "";
                passwordBox.Text = "";
                MessageBox.Show("Invalid nickname or password.");
            }
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            if (passwordBox.Text.Length > 0)
            {
                if (!showPassword.Checked)
                {
                    passwordBox.PasswordChar = '\0';
                    password = passwordBox.Text;
                    passwordBox.PasswordChar = '*';
                }
                else
                    password = passwordBox.Text;
            }
        }

        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword.Checked)
                passwordBox.PasswordChar = '\0';
            else
                passwordBox.PasswordChar = '*';
        }
    }
}
