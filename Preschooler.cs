namespace Lab_rab_kalinind.a._БПИ_23_02
{
    public class Preschooler : Person
    {
        public Preschooler(string fullName, int age, string gender)
            : base(fullName, age, gender) { }

        public override double GetAverageIncome() => 0;

        public override double GetAverageExpense() => 5000; // расходы семьи
    }
}
