namespace Lab_rab_kalinind.a._БПИ_23_02
{
    public class Worker : Person
    {
        public double Salary { get; set; }

        public Worker(string fullName, int age, string gender, double salary)
            : base(fullName, age, gender)
        {
            Salary = salary;
        }

        public override double GetAverageIncome() => Salary;

        public override double GetAverageExpense() => Salary * 0.7; // примерное распределение
    }
}
