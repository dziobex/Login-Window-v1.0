using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Security.Cryptography;
using System.Linq;
using System.IO;

namespace Login
{
    [Serializable]
    class User
    {
        string path;
        string usedNickname;
        string usedPassword;
        string currentFile;

        public User(string path) { this.path = path; }

        public string UsedNickname { get { return usedNickname; } }
        public string UsedPassword { get { return usedPassword; } }
        public string CurrentFile { get { return currentFile; } }

        public bool CheckForCorrectNickname(string nickname)
        {
            string[] fileNames = Directory.GetFiles(path, "*.user");
            foreach (var fileName in fileNames)
            {
                User u = new User(path);
                using (Stream reader = File.OpenRead(fileName))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    u = (User)bf.Deserialize(reader);
                }
                if (u.UsedNickname == nickname)
                    return false;
            }
            return true;
        }

        public void SaveNewUser(string nickName, string password)
        {
            using (Stream writer = File.Create(path + ("\\user" + Directory.GetFiles(path).Length.ToString() + ".user")))
            {
                BinaryFormatter bf = new BinaryFormatter();
                this.usedNickname = encryptString(nickName);
                this.usedPassword = encryptString(password);
                bf.Serialize(writer, this);
            }
            this.usedNickname = decryptString(this.usedNickname);
            this.usedPassword = decryptString(this.usedPassword);
        }

        string encryptString(string str)
        {
            byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(str);
            return Convert.ToBase64String(bytes);
        }

        string decryptString(string str)
        {
            byte[] bytes = Convert.FromBase64String(str);
            return System.Text.ASCIIEncoding.ASCII.GetString(bytes);
        }

        public bool LoadNewUser(string nickName, string password)
        {
            string[] fileNames = Directory.GetFiles(path, "*.user");
            foreach (var fileName in fileNames)
            {
                User u = new User(path);
                using (Stream reader = File.OpenRead(fileName))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    u = (User)bf.Deserialize(reader);
                }
                if (u.decryptString(u.usedNickname) == nickName & u.decryptString(u.usedPassword) == password)
                {
                    currentFile = fileName;
                    return true;
                }
            }
            return false;
        }
    }
}
