
namespace MauiApp4
{
    public partial class MainPage : ContentPage
    {
        private double firstNumber;
        private string operatorSymbol;
        private bool isOperatorPressed = false;
        private double secondNumber = 0;
        private string history = "";

        public MainPage()
        {
            InitializeComponent();
        }

        private void NumberButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string number = button.Text;

            if (isOperatorPressed)
            {
                Display.Text = number;
                //isOperatorPressed = false;
            }
            else
            {

                if (Display.Text == "0" && button.Text != ",")
                    Display.Text = "";

                Display.Text += number;
            }
        }

        private void OperatorButton_Clicked(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            operatorSymbol = button.Text;


            firstNumber = Convert.ToDouble(Display.Text);
            isOperatorPressed = true;
        }

        private void EqualButton_Clicked(object sender, EventArgs e)
        {
            secondNumber = Convert.ToDouble(Display.Text);
            double result = 0;

            switch (operatorSymbol)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber == 0)
                    {
                        Display.Text = "Ошибка";
                        return;
                    }
                    result = firstNumber / secondNumber;
                    break;
            }

            Display.Text = result.ToString(); isOperatorPressed = false;
        }

        private void OtherButton_clicked(object sender, EventArgs e)
        {
            double secondNumber = Convert.ToDouble(Display.Text);
            double result = 0;

            Button button = (Button)sender;
            var localoperatorSymbol = button.Text;
            switch (localoperatorSymbol)
            {
                case "+/-":
                    result = -secondNumber;
                    break;
                case "sqrt":
                    result = Math.Sqrt(secondNumber);
                    break;
                case "1/x":
                    result = 1 / secondNumber;
                    break;
                case "x^2":
                    result = Math.Pow(secondNumber, 2);
                    break;
                case "%":
                    if (isOperatorPressed == true)
                    {
                        switch (operatorSymbol)
                        {
                            case "+":
                                result = firstNumber + ((secondNumber / 100) * firstNumber);
                                break;
                            case "-":
                                result = firstNumber - ((secondNumber / 100) * firstNumber);
                                break;
                            case "*":
                                result = firstNumber * (secondNumber / 100);
                                break;
                            case "/":
                                result = firstNumber / (secondNumber / 100);
                                break;
                               
                        }
                    }
                    else
                    {
                         result = secondNumber / 100;
                    }
                    break;

            }
            Display.Text = result.ToString();
            isOperatorPressed = false;
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            Display.Text = "0";
            firstNumber = 0;
            operatorSymbol = "";
            isOperatorPressed = false;
        }
        private void ClearEButton_Clicked(object sender, EventArgs e)
        {
            if (isOperatorPressed)
            {
                Display.Text = "0";
                operatorSymbol = "";
                isOperatorPressed = false;
                secondNumber = 0;
            }
        }

        private void BackspaceButton_Clicked(object sender, EventArgs e)
        {
            if (Display.Text.Length > 1)
            {
                Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
            }
            else
            {
                Display.Text = "0";
            }
        }

    }

}
