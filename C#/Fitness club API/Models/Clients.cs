namespace Fitness_club_API.Models
{
    //ENUM
    //https://www.youtube.com/watch?v=YAgXX20o2Qg
    public class Clients:People
    {
        public Gender gender { get; set; }

        public enum Gender
        {
            Unknown = 0,
            Male = 1,
            Female = 2,
        }

        public Clients(Gender gender)
        {
            this.gender = gender;
        }

        public Clients()
        {
        }

    }
}
