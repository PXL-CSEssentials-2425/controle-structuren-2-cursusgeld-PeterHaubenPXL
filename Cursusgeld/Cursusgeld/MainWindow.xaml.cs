using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cursusgeld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const double HourFee = 1.5;

        int lessonHours = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            bool isYear = int.TryParse(yearTextBox.Text, out int year);
            bool isLeapYear = false;

            double registrationFee;

            if (isYear)
            {
                if (year % 4 == 0)
                {
                    if (year % 100 == 0)
                    {
                        if (year % 400 == 0)
                        {
                            isLeapYear = true;
                        }
                        else
                        {
                            isLeapYear = false;
                        }
                    }
                    else
                    {
                        isLeapYear = true;
                    }
                }
                else
                {
                    isLeapYear = false;
                }

                if (isNumberLabel.Visibility==Visibility.Visible)
                {
                    if (isYear)
                    {
                        if (isLeapYear)
                        {
                            isLeapYearLabel.Visibility = Visibility.Visible;

                            registrationFeeTextBox.Text = ((lessonHours + 1) * HourFee).ToString();
                        }
                        else
                        {
                            isLeapYearLabel.Visibility = Visibility.Collapsed;

                            registrationFeeTextBox.Text = (lessonHours * HourFee).ToString();
                        }
                    }
                }
            }
        }

        private void testNumButton_Click(object sender, RoutedEventArgs e)
        {
            bool isNumber = int.TryParse(lessonHoursTextBox.Text, out lessonHours);

            if (isNumber)
            {
                isNumberLabel.Visibility = Visibility.Visible;
                calculateButton.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Geef 'Aantal lesuren' in", "Foutieve ingave");

                lessonHoursTextBox.SelectAll();
                lessonHoursTextBox.Focus();

                isNumberLabel.Visibility = Visibility.Collapsed;
                calculateButton.IsEnabled = false;
            }
        }

        private void yearTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isLeapYearLabel.Visibility = Visibility.Collapsed;
        }

        private void lessonHoursTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isNumberLabel.Visibility = Visibility.Collapsed;

            calculateButton.IsEnabled = false;
        }
    }

}