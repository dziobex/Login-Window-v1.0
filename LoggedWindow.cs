using System;
using System.IO;
using System.Windows.Forms;

namespace Login
{
    public partial class LoggedWindow : Form
    {
        Random randomizer;
        string path = Path.GetDirectoryName(Application.StartupPath) + "\\files";

        public LoggedWindow(string nickName, string currentFile)
        {
            InitializeComponent();
            randomizer = new Random();
            info.Text = "hey " + nickName + " how are you? ;p";
            creationDate.Text = "(btw your account was created in " + File.GetCreationTime(currentFile).ToString() + ")";
            getRandomText(nickName);
            getRandomGif();
        }

        void getRandomGif()
        {
            string[] files = Directory.GetFiles(path, "*.gif");
            mainImage.Load(files[randomizer.Next(files.Length)]);
        }
        
        void getRandomText(string nickName)
        {
            string[] randoms = new string[3]
            {
                "hey " + nickName + " how are you? ;p",
                "nice to meet you, " + nickName + "!",
                "here is your gif, " + nickName + ":"
            };
            info.Text = randoms[randomizer.Next(3)];
        }
    }
}
