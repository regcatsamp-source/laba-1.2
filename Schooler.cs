namespace Lab_rab_kalinind.a._БПИ_23_02
{
    public class Schooler : Person
    {
        public Schooler(string fullName, int age, string gender)
            : base(fullName, age, gender) { }

        public override double GetAverageIncome() => 0;

        public override double GetAverageExpense() => 7000;
    }
}
