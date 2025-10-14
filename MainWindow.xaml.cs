using labakalinindabpi2302;
using System;
using System.Windows;

namespace Lab_rab_kalinind.a._БПИ_23_02
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void s_Click(object sender, RoutedEventArgs e)
        {
            string fam = TextBoxfam.Text;
            string sumText = TextBoxsum.Text;
            string yearText = TextBoxyear.Text;

            if (fam == "")
            {
                MessageBox.Show("Введите фамилию!");
                return;
            }

            // Парсим оклад
            double oklad = 0;
            bool ok = double.TryParse(sumText, out oklad);
            if (!ok)
                oklad = 0;

            DateTime start;
            bool dateOk = DateTime.TryParse(yearText, out start);
            if (!dateOk)
            {
                int god;
                bool yearOk = int.TryParse(yearText, out god);
                if (yearOk)
                    start = new DateTime(god, 1, 1);
                else
                {
                    MessageBox.Show("Введите год или дату правильно!");
                    return;
                }
            }

            Worker rab = new Worker(fam, oklad, start);
            string result = rab.GetYearsMessage();
            ResultTextBlock.Text = result;
        }

        private void p_Click(object sender, RoutedEventArgs e)
        {
            string fam = TextBoxfam.Text;
            string yearText = TextBoxyear.Text;

            if (fam == "")
            {
                MessageBox.Show("Введите фамилию!");
                return;
            }

            DateTime start;
            bool dateOk = DateTime.TryParse(yearText, out start);
            if (!dateOk)
            {
                int god;
                bool yearOk = int.TryParse(yearText, out god);
                if (yearOk)
                    start = new DateTime(god, 1, 1);
                else
                {
                    MessageBox.Show("Введите год или дату правильно!");
                    return;
                }
            }

            Worker rab = new Worker(fam, 0, start);
            string result = fam + " работает уже " + rab.GetDays() + " дней!";
            ResultTextBlock.Text = result;
        }
    }
}