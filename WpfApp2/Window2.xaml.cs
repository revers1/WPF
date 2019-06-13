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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            
        }

   

        private void Pass_GotFocus(object sender, RoutedEventArgs e)
        {
            pass.Text = "";
        }

        private void Buttonlogin_Click(object sender, RoutedEventArgs e)
        {
            Window2 windo2 = new Window2();
            Window3 window3 = new Window3();
            if (pass.Text == "step")
            {
                windows2.Close();
                window3.ShowDialog();

            }
            else
                MessageBox.Show("Пароль не пiдходить, спробуйте звернутися до викладача.");
        }
    }
}
