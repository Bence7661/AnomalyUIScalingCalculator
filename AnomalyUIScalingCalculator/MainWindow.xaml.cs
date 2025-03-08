using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnomalyUIScalingCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly float ScreenWidth = 1920f;
        private static readonly float ScreenHeight = 1080f;

        private static readonly float OutputXScalingFactor = 1024f / ScreenWidth;
        private static readonly float OutputYScalingFactor = 768f / ScreenHeight;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (float.TryParse(XInput.Text, out float originalX) && float.TryParse(YInput.Text, out float originalY))
            {
                var (CalculatedX, CalculatedY) = CalculateNew(originalX, originalY);

                OutputX.Text = $"{CalculatedX:0}";
                OutputY.Text = $"{CalculatedY:0}";
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values for X and Y.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static (float x, float y) CalculateNew(float x, float y)
            => (x * OutputXScalingFactor, y * OutputYScalingFactor);

        private void CopySingle_Click(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border clickable)
            {
                if (clickable.Name == nameof(XClickable) && !string.IsNullOrEmpty(OutputX.Text))
                {
                    Clipboard.SetText(OutputX.Text);
                    InfoText_Trigger($"Copied: {OutputX.Text}");
                }
                else if (clickable.Name == nameof(YClickable) && !string.IsNullOrEmpty(OutputY.Text))
                {
                    Clipboard.SetText(OutputY.Text);
                    InfoText_Trigger($"Copied: {OutputY.Text}");
                }
            }
        }

        private void CopyBoth_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string xValue = OutputX.Text;
                string yValue = OutputY.Text;

                if (!string.IsNullOrEmpty(xValue) && !string.IsNullOrEmpty(yValue))
                {
                    string coordinates = $"{xValue}, {yValue}";
                    Clipboard.SetText(coordinates);
                    InfoText_Trigger($"Copied: {coordinates}");
                }
            }
        }

        private void InfoText_Trigger(string infoMessage)
        {
            var textDefault = "Info -";

            if (!string.IsNullOrEmpty(infoMessage)) 
            {
                InfoText.Text = $"{textDefault} {infoMessage}";
            }
        }
    }
}