using System;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Login
{
    public partial class NewAccount : Form
    {
        User user;
        string h = System.IO.Path.GetDirectoryName(Application.StartupPath) + "\\users";
        string password;

        public NewAccount()
        {
            InitializeComponent();
            user = new User(h);
            passwordBox.PasswordChar = '*';
            passwordBox.MaxLength = 20;
        }

        private void loginBox_TextChanged(object sender, EventArgs e)
        {
            string[] fileNames = Directory.GetFiles(h, "*.user");
            try
            {
                if (!user.CheckForCorrectNickname(loginBox.Text))
                    throw new LoginUsed();
                else
                {
                    errorProvider1.Clear();
                    createNewAccountBtn.Enabled = true;
                    return;
                }
            }
            catch (LoginUsed lu)
            {
                errorProvider1.SetError(loginBox, lu.Message);
                createNewAccountBtn.Enabled = false;
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

        private void createNewAccountBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!password.Any(c => char.IsDigit(c)))
                    throw new NoLetters();
                else
                    errorProvider1.Clear();
                if (!password.Any(c => !Char.IsLetterOrDigit(c)))
                    throw new NoSymbols();
                else
                    errorProvider1.Clear();
                if (password == loginBox.Text)
                    throw new TheSamePasswordAndNickname();
            }
            catch (NoLetters nl)
            {
                errorProvider1.SetError(passwordBox, nl.Message);
                return;
            }
            catch (NoSymbols ns)
            {
                errorProvider1.SetError(passwordBox, ns.Message);
                return;
            }
            catch (TheSamePasswordAndNickname tspau)
            {
                errorProvider1.SetError(passwordBox, tspau.Message);
                return;
            }
            user.SaveNewUser(loginBox.Text, password);
            MessageBox.Show("You account was saved.");
            this.Close();
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
