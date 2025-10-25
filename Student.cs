namespace Lab_rab_kalinind.a._БПИ_23_02
{
    public class Student : Person
    {
        public Student(string fullName, int age, string gender)
            : base(fullName, age, gender) { }

        public override double GetAverageIncome() => 15000;

        public override double GetAverageExpense() => 12000;
    }
}
