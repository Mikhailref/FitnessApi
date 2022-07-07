namespace Fitness_club_API.Models
{
    public class Employees : People
    {
        public string Department { get; set; }

        public Employees(string department)
        {
            Department = department;
        }

        public Employees()
        {
        }
    }
}

    
