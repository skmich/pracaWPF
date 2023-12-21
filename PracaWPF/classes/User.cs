using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaWPF.classes
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public string Mail { get; set; }
        public int Telephone { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public User()
        {

        }

        public User(int id, string name, string surname, string birthDate, string mail, int telephone, string password, bool isAdmin)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.BirthDate = birthDate;
            this.Mail = mail;
            this.Telephone = telephone;
            this.Password = password;
            this.IsAdmin = isAdmin;
        }
    }
}
