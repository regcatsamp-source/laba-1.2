using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Lab_rab_kalinind.a._БПИ_23_02
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Кнопка "Рассчитать доход/расход"
        private void s_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = TextBoxfam.Text.Trim();
                string category = TextBoxsum.Text.Trim().ToLower();
                string gender = TextBoxGender.Text.Trim();
                int age = 0;

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(gender))
                {
                    ResultTextBlock.Text = "Заполните все поля!";
                    return;
                }

                Person person;
                switch (category)
                {
                    case "дошкольник":
                        person = new Preschooler(name, age, gender);
                        break;
                    case "школьник":
                        person = new Schooler(name, age, gender);
                        break;
                    case "студент":
                        person = new Student(name, age, gender);
                        break;
                    case "работающий":
                        double salary = 30000; // Пример зарплаты
                        person = new Worker(name, age, gender, salary);
                        break;
                    default:
                        ResultTextBlock.Text = "Неизвестная категория!";
                        return;
                }

                ResultTextBlock.Text = $"Средний доход: {person.GetAverageIncome():0.00} ₽\n" +
                                       $"Средний расход: {person.GetAverageExpense():0.00} ₽";
            }
            catch
            {
                ResultTextBlock.Text = "Ошибка ввода данных!";
            }
        }

        // Кнопка "Вычислить стаж и дни"
        private void p_Click(object sender, RoutedEventArgs e)
        {
            string fam = TextBoxfam.Text.Trim();
            string yearText = TextBoxyear.Text.Trim();

            if (string.IsNullOrWhiteSpace(fam) || string.IsNullOrWhiteSpace(yearText))
            {
                ResultTextBlock.Text = "Заполните ФИО и год!";
                return;
            }

            DateTime start;
            if (!DateTime.TryParse(yearText, out start))
            {
                if (int.TryParse(yearText, out int year))
                    start = new DateTime(year, 1, 1);
                else
                {
                    ResultTextBlock.Text = "Введите год правильно!";
                    return;
                }
            }

            TimeSpan diff = DateTime.Today - start;
            int years = (int)(diff.Days / 365.25);
            int days = diff.Days;

            ResultTextBlock.Text = $"{fam} работает уже {years} лет\n" +
                                   $"Дней с начала работы/поступления: {days} дней";
        }

        // Ограничение ввода: только буквы для ФИО, Категории и Пола
        private void TextBoxLettersOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsLetter(c) && c != ' ' && c != '-')
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        // Ограничение ввода: только цифры для года
        private void TextBoxDigitsOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        // Привязка стандартных обработчиков
        private void TextBoxfam_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBoxLettersOnly_PreviewTextInput(sender, e);
        }

        private void TextBoxsum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBoxLettersOnly_PreviewTextInput(sender, e);
        }

        private void TextBoxGender_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBoxLettersOnly_PreviewTextInput(sender, e);
        }

        private void TextBoxyear_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBoxDigitsOnly_PreviewTextInput(sender, e);
        }

        // Смена темы на белую
        private void White_Click(object sender, RoutedEventArgs e)
        {
            ChangeTheme("Dictionary2.xaml");
        }

        // Смена темы на тёмную
        private void Black_Click(object sender, RoutedEventArgs e)
        {
            ChangeTheme("Dictionary1.xaml");
        }

        private void ChangeTheme(string themeFile)
        {
            var dictionaries = this.Resources.MergedDictionaries;
            var oldTheme = dictionaries.FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("Dictionary"));
            if (oldTheme != null)
                dictionaries.Remove(oldTheme);

            var newDict = new ResourceDictionary();
            newDict.Source = new Uri(themeFile, UriKind.Relative);
            dictionaries.Add(newDict);
        }
    }
}
