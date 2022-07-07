namespace Fitness_club_API.Models
{
    public class People
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Image { get; set; }

        public People(int id, string firstName, string secondName, string image)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            Image = image;
        }

        public People()
        {
        }
    }
}
