using System;

namespace Lab_rab_kalinind.a._БПИ_23_02
{
    public abstract class Person
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public Person(string fullName, int age, string gender)
        {
            FullName = fullName;
            Age = age;
            Gender = gender;
        }

        public abstract double GetAverageIncome();
        public abstract double GetAverageExpense();
    }

    public class Preschooler : Person
    {
        public Preschooler(string fullName, int age, string gender) 
            : base(fullName, age, gender) { }

        public override double GetAverageIncome() => 0; // Дети не зарабатывают
        public override double GetAverageExpense() => 5000; // Пример расходы на питание, игрушки и т.д.
    }

    public class Schooler : Person
    {
        public Schooler(string fullName, int age, string gender) 
            : base(fullName, age, gender) { }

        public override double GetAverageIncome() => 0; // Обычно нет дохода
        public override double GetAverageExpense() => 7000; // Учебники, секции, карманные расходы
    }

    public class Student : Person
    {
        public Student(string fullName, int age, string gender) 
            : base(fullName, age, gender) { }

        public override double GetAverageIncome() => 15000; // Подработка, стипендия
        public override double GetAverageExpense() => 12000; // Проживание, еда, учеба
    }

    public class Worker : Person
    {
        public double Salary { get; set; }

        public Worker(string fullName, int age, string gender, double salary) 
            : base(fullName, age, gender) 
        {
            Salary = salary;
        }

        public override double GetAverageIncome() => Salary;
        public override double GetAverageExpense() => Salary * 0.7; // Пример: 70% уходит на расходы
    }
}
