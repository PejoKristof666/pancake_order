using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pancake_order
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int priceForOne = 50;
        static int priceForAll = 0;
        Label Price = new Label() { Content = $"Összesen: {priceForAll} Ft", FontSize = 20 };
        file newfile;
        List<file> all;
        static string number;
        static string doughtype;
        static string fillingtype;

        public MainWindow()
        {
            InitializeComponent();
            newfile = new file("data.txt");
            Everything.Children.Add(Price);
            Start();
        }
        void Start()
        {
            numberInput.GotFocus += changeText;
            doughTypeInput.GotFocus += changeText;
            fillingTypeInput.GotFocus += changeText;

            numberInput.LostFocus += changeBack;
            doughTypeInput.LostFocus += changeBack;
            fillingTypeInput.LostFocus += changeBack;
        
        }

        void changeText(object s, EventArgs e)
        {
            TextBox clicked = s as TextBox;
            if (clicked.Text == clicked.Tag.ToString())
            {
                clicked.Text = "";
            }        
        }

        void changeBack(object s, EventArgs e)
        {
            TextBox clicked = s as TextBox;
            if (clicked.Text == "")
            {
                clicked.Text = clicked.Tag.ToString();
            }
        }

        void clickAdd(object s, EventArgs e)
        {
            if(numberInput.Text == numberInput.Tag.ToString() || doughTypeInput.Text == doughTypeInput.Tag.ToString() || fillingTypeInput.Text == fillingTypeInput.Tag.ToString())
            {
                MessageBox.Show("Írj be megfelelő adatokat");
            }
            else
            {
                number = numberInput.Text;
                doughtype = doughTypeInput.Text;
                fillingtype = fillingTypeInput.Text;

                Everything.Children.Remove(Price);
                priceForAll += 50 * Convert.ToInt32(numberInput.Text);
                Price = new Label() { Content = $"Összesen: {priceForAll} Ft", FontSize = 20 };
                Everything.Children.Add(new Label { Content = Convert.ToString(numberInput.Text) });
                Everything.Children.Add(new Label { Content = doughTypeInput.Text });
                Everything.Children.Add(new Label { Content = fillingTypeInput.Text });
                Everything.Children.Add(new Label { Content = "-----------------------------------" });
                Everything.Children.Add(Price);
            }

        }   
        
        void clickNo(object s, EventArgs e)
        {
            numberInput.Text = numberInput.Tag.ToString();
            doughTypeInput.Text = doughTypeInput.Tag.ToString();
            fillingTypeInput.Text = fillingTypeInput.Tag.ToString();
        }

        void clickCart(object s, EventArgs e)
        {
            

            pancakes onePancakes = new pancakes(Convert.ToInt32(number), doughtype, fillingtype);
            newfile.WriteOneLine(onePancakes);
            Everything.Children.Clear();
            
        }
    }
}
