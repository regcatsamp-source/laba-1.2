using System;

namespace labakalinindabpi2302
{
    public class Worker
    {
        public string Name { get; set; }
        public double Oklad { get; set; }
        public DateTime StartDate { get; set; }

        public Worker(string name, double oklad, DateTime startDate)
        {
            Name = name;
            Oklad = oklad;
            StartDate = startDate;
        }

        public int GetYears()
        {
            DateTime today = DateTime.Today;
            int years = today.Year - StartDate.Year;

            if (today.Month < StartDate.Month)
                years = years - 1;
            else if (today.Month == StartDate.Month && today.Day < StartDate.Day)
                years = years - 1;

            if (years < 0)
                years = 0;

            return years;
        }

        public int GetDays()
        {
            DateTime today = DateTime.Today;
            TimeSpan razn = today - StartDate;
            int days = (int)razn.TotalDays;

            if (days < 0)
                days = 0;

            return days;
        }

        public string GetYearsMessage()
        {
            int years = GetYears();

            if (years < 1)
                return Name + " работает меньше года :(";
            else
                return Name + " работает " + years + " " + GetYearsWord(years) + ".";
        }


        private string GetYearsWord(int years)
        {
            int n = years % 100;
            if (n >= 11 && n <= 19) return "лет";
            int last = n % 10;
            if (last == 1) return "год";
            if (last >= 2 && last <= 4) return "года";
            return "лет";
        }
    }
}