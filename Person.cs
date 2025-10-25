namespace Lab_rab_kalinind.a._БПИ_23_02
{
    public abstract class Person
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        protected Person(string fullName, int age, string gender)
        {
            FullName = fullName;
            Age = age;
            Gender = gender;
        }

        public abstract double GetAverageIncome();
        public abstract double GetAverageExpense();
    }
}
