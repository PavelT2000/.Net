using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserData
{
    internal class User
    {
        private static int currentId = 0;
        private int id;
        private string login;
        private string password;


        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
            this.id = currentId++;
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }
        public string GetPassword()
        {
            return this.password;
        }
        public string GetLogin()
        {
            return this.login;
        }
        public int GetId()
        {
            return this.id;
        }
        public void OutData()
        {
            Console.WriteLine($"Id:{id,-5}, Login:{login,-10}, password:{password,-10}\n");
        }

    }
}
