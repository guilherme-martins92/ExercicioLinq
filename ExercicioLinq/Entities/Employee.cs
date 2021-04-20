
namespace ExercicioLinq.Entities
{
    class Employee
    {
        public string Name { get; set; }
        public string email { get; set; }
        public double Salary { get; set; }

        public Employee(string name, string email, double salary)
        {
            Name = name;
            this.email = email;
            Salary = salary;
        }
    }
}
