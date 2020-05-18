using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTBNsGearStore.Models
{
    public class Account
    {
        private string id;
        private string password;
        private string name;
        private string phone;
        private int type;
        private double salary;
        private DateTime dateJoined;
        private string department;

        public string Id { get => id; set => id = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public int Type { get => type; set => type = value; }
        public double Salary { get => salary; set => salary = value; }
        public DateTime DateJoined { get => dateJoined; set => dateJoined = value; }
        public string Department { get => department; set => department = value; }
    }
}