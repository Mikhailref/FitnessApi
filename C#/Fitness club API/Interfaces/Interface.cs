using Fitness_club_API.Models;
using System.Runtime.InteropServices;

namespace Fitness_club_API.Interfaces
{
    public interface IDataBase
    {
        (Employees, List<Employees>) EmployeesReader([Optional] int Id);
        (Clients, List<Clients>) ClientsReader([Optional] int Id);
        void Writer(Clients client, Employees employee);
        void Eraser(int Id, string TypeOfPerson);
      
    }
}
