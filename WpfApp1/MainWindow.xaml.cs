using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace _MDK_0101_Shevtsov_Calculator_
{
    public partial class MainWindow : Window
    {
        double a;
        double b;
        int operand;

        public MainWindow()
        {
            InitializeComponent();
            this.SizeToContent = System.Windows.SizeToContent.WidthAndHeight;
            TextBox1.Focus();

            TextBox3.Text = "Результат: ";
        }
        private void displayTextBlock_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox textBlock = (TextBox)sender; 
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                textBlock.Text += Environment.NewLine;
            }
        }
        private void displayTextBlock_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            TextBox textBlock = (TextBox)sender;
            textBlock.Text += e.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox3.Text += " + ";
            operand = 1;
            TextBox2.Focus();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            a = 0;
            b = 0;
            operand = 0;

            TextBox1.TextChanged -= TextBox1_TextChanged;
            TextBox2.TextChanged -= TextBox2_TextChanged;

            TextBox1.Clear();
            TextBox2.Clear();
            TextBox3.Clear();

            TextBox1.TextChanged += TextBox1_TextChanged;
            TextBox2.TextChanged += TextBox2_TextChanged;

            TextBox1.Focus();
            TextBox3.Text = "Итого: ";
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            char number = TextBox1.Text[TextBox1.Text.Length - 1];
            if (Char.IsDigit(number))
            {
                TextBox3.Text += TextBox1.Text[TextBox1.Text.Length - 1];
                a = Convert.ToDouble(TextBox1.Text);
            }
        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox3.Text += TextBox2.Text[TextBox2.Text.Length - 1];
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextBox3.Text += " - ";
            operand = 2;
            TextBox2.Focus();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TextBox3.Text += " * ";
            operand = 3;
            TextBox2.Focus();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TextBox3.Text += " / ";
            operand = 4;
            TextBox2.Focus();
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                b = Convert.ToDouble(TextBox2.Text);
                double res = 0;
                if (operand == 1)
                {
                    res = a + b;
                }
                else if (operand == 2)
                {
                    res = a - b;
                }
                else if (operand == 3)
                {
                    res = a * b;
                }
                else if (operand == 4)
                {
                    res = a / b;
                }
                else
                {
                    res = 0;
                }
                TextBox3.Text += " = " + Convert.ToString(res);
            }
        }
    }
}