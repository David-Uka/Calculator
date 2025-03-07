using Microsoft.Maui.Controls;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        private string _currentEntry = "0";
        private string _operator;
        private double _firstNumber;
        private bool _isSecondNumber;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnDigitButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            var digit = button.Text;

            if (_currentEntry == "0" || _isSecondNumber)
            {
                _currentEntry = digit;
                _isSecondNumber = false;
            }
            else
            {
                _currentEntry += digit;
            } 

            DisplayLabel.Text = _currentEntry;
        }

        private void OnDecimalButtonClick(object sender, EventArgs e)
        {
            if (!_currentEntry.Contains("."))
            {
                _currentEntry += ".";
            }

            DisplayLabel.Text = _currentEntry;
        }

        private void OnOperatorButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            _operator = button.Text;
            _firstNumber = double.Parse(_currentEntry);
            _isSecondNumber = true;
        }

        private void OnEqualButtonClick(object sender, EventArgs e)
        {
            var secondNumber = double.Parse(_currentEntry);
            double result;

            switch (_operator)
            {
                case "+":
                    result = _firstNumber + secondNumber;
                    break;
                case "-":
                    result = _firstNumber - secondNumber;
                    break;
                case "*":
                    result = _firstNumber * secondNumber;
                    break;
                case "/":
                    result = _firstNumber / secondNumber;
                    break;
                default:
                    return;
            }

            _currentEntry = result.ToString();
            DisplayLabel.Text = _currentEntry;
            _isSecondNumber = true;
        }

        private void OnClearButtonClick(object sender, EventArgs e)
        {
            _currentEntry = "0";
            _firstNumber = 0;
            _operator = null;
            _isSecondNumber = false;
            DisplayLabel.Text = _currentEntry;
        }
    }
}