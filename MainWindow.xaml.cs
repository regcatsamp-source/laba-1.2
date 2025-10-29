using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab_rab_kalinind.a._БПИ_23_02
{
    public partial class MainWindow : Window
    {
        private bool isDarkTheme = false; // текущая тема

        public MainWindow()
        {
            InitializeComponent();
        }

        // ======== Валидация ========
        private void TextBoxLettersOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
                if (!char.IsLetter(c) && c != ' ' && c != '-')
                    e.Handled = true;
        }

        private void TextBoxDigitsOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
                if (!char.IsDigit(c))
                    e.Handled = true;
        }

        // ======== Категория ========
        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryComboBox.SelectedItem is ComboBoxItem selected)
            {
                string category = selected.Content.ToString();
                bool isPreschooler = category == "Дошкольник";
                TextBoxIncome.IsEnabled = !isPreschooler;
                if (isPreschooler)
                    TextBoxIncome.Text = "";
            }
        }

        // ======== Показ итога ========
        private void ShowTotals_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(TextBoxIncome.Text, out double income);
            double.TryParse(TextBoxExpense.Text, out double expense);

            string name = TextBoxfam.Text.Trim();
            string gender = TextBoxGender.Text.Trim();
            string category = (CategoryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "не выбрана";

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(gender))
            {
                ResultTextBlock.Text = "Введите ФИО и пол!";
                return;
            }

            // 🔥 Проверка на превышение расхода
            if (TextBoxIncome.IsEnabled && expense > income)
            {
                // Тематическое сообщение
                ResultTextBlock.Text = "💸 Вы тратите больше, чем зарабатываете!\nПроверьте свои расходы и попробуйте снова.";
                ResultTextBlock.Foreground = System.Windows.Media.Brushes.Red;

                // Альтернатива: всплывающее окно
                // MessageBox.Show("Вы тратите больше, чем зарабатываете!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Если всё в порядке — восстанавливаем стандартный цвет
            ResultTextBlock.Foreground = System.Windows.Media.Brushes.Black;

            string result = $"{name} ({gender}), категория: {category}\n";

            if (!TextBoxIncome.IsEnabled)
                result += $"Доход недоступен для данной категории\n";
            else
                result += $"Доход: {income:0.00} ₽\n";

            result += $"Расход: {expense:0.00} ₽";

            ResultTextBlock.Text = result;
        }

        // ======== Переключатель темы ========
        private void ThemeButton_Click(object sender, RoutedEventArgs e)
        {
            if (isDarkTheme)
            {
                // Переключаем на белую тему
                ChangeTheme("Dictionary2.xaml");
                ThemeButton.Content = "Тёмная тема";
                isDarkTheme = false;
            }
            else
            {
                // Переключаем на тёмную тему
                ChangeTheme("Dictionary1.xaml");
                ThemeButton.Content = "Белая тема";
                isDarkTheme = true;
            }
        }

        private void ChangeTheme(string themeFile)
        {
            try
            {
                var dictionaries = this.Resources.MergedDictionaries;

                // Удаляем старую тему, если есть
                var oldTheme = dictionaries.FirstOrDefault(d =>
                    d.Source != null &&
                    (d.Source.OriginalString.Contains("Dictionary1") || d.Source.OriginalString.Contains("Dictionary2")));

                if (oldTheme != null)
                    dictionaries.Remove(oldTheme);

                // Подключаем новую
                var newDict = new ResourceDictionary
                {
                    Source = new Uri(themeFile, UriKind.Relative)
                };
                dictionaries.Add(newDict);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке темы: " + ex.Message);
            }
        }
    }
}
