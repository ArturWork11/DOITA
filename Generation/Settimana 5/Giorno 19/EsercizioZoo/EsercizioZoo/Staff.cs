using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioZoo
{
    internal class Staff : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int WorkYears { get; set; }
        public string StaffCage { get; set; }

        protected Staff() { }

        public Staff(int id,string name,string surname, DateTime dateOfBirth, int workYears, string staffCage ) : base (id) 
        {
                Name = name;
                Surname = surname;
                DateOfBirth = dateOfBirth;
                WorkYears = workYears;
                StaffCage = staffCage;
        }

        public override string ToString()
        {
            return base .ToString() + $"\nName: {Name} \nSurname: {Surname} \nDate of Birth: {DateOfBirth.ToString("dd/mm/yyyy")} \nYears of work: {WorkYears} \nStaff cage: {StaffCage} ";
        }

        public int Eta()
        {
            DateTime today = DateTime.Today;
            int age = (today.Year - DateOfBirth.Year);
            if (today.Month < DateOfBirth.Month)
            {
                age -= 1;
            }
            else if (today.Month == DateOfBirth.Month && today.Day < DateOfBirth.Day)
            { 
                age -= 1;
            }

            return age;
        }
    }   

} 
