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
        private void TextBoxfam_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (char.IsDigit(c))
                {
                    e.Handled = true;
                }
            }
        }
        private void TextBoxsum_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) && c != ',' && c != '.')
                {
                    e.Handled = true;
                    return;
                }
            }
            var textBox = sender as System.Windows.Controls.TextBox;
            if (textBox != null)
            {
                string currentText = textBox.Text;
                if ((e.Text == "," || e.Text == ".") && (currentText.Contains(",") || currentText.Contains(".")))
                {
                    e.Handled = true;
                }
            }
        }
        private void White_Click(object sender, RoutedEventArgs e)
        {
            ChangeTheme("Dictionary2.xaml");
        }

        private void Black_Click(object sender, RoutedEventArgs e)
        {
            ChangeTheme("Dictionary1.xaml");
        }

        private void ChangeTheme(string themeFile)
        {
            var dictionaries = this.Resources.MergedDictionaries;

            var oldTheme = dictionaries
                .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("Dictionary"));
            if (oldTheme != null)
                dictionaries.Remove(oldTheme);

            var newDict = new ResourceDictionary();
            newDict.Source = new Uri(themeFile, UriKind.Relative);
            dictionaries.Add(newDict);
        }
    }
}
