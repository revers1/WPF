using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        List<Test> listtests = new List<Test>();
            private int counter = 3;
        public int currenttest = -1;

        Test test = new Test();
        public Window3()
        {
            
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {/*Button Add*/
            MainWindow main = this.Owner as MainWindow;
            string namecheck = "Check" + counter.ToString();
            string nametextbox = "Textbox" + counter.ToString();
            if (namecheck=="Check3"&&nametextbox=="Textbox3")
            {
                Check3.Visibility = Visibility.Visible;
                Textbox3.Visibility = Visibility.Visible;
            }
            if (namecheck == "Check4" && nametextbox == "Textbox4")
            {
                Check4.Visibility = Visibility.Visible;
                Textbox4.Visibility = Visibility.Visible;
            }
            if (namecheck == "Check5" && nametextbox == "Textbox5")
            {
                Check5.Visibility = Visibility.Visible;
                Textbox5.Visibility = Visibility.Visible;
                counter = 2;
            }
            counter++;


        }

        private void Buttonright_Click(object sender, RoutedEventArgs e)
        {
           
            
            if (currenttest == -1)
            {
                this.DataContext = listtests.FirstOrDefault();
                currenttest = 0;

            }
            else if (currenttest == 0)
            {
                this.DataContext = listtests.LastOrDefault();
                currenttest = listtests.Count - 1;

            }
            else
            {
                this.DataContext = listtests[currenttest-- - 1];
            }
        }

        private void Buttonleft_Click(object sender, RoutedEventArgs e)
        {
           
            if (currenttest == -1 || currenttest == listtests.Count - 1)
            {
                this.DataContext = listtests.FirstOrDefault();
                currenttest = 0;
            }
            else
            {
                this.DataContext = listtests[++currenttest];
            }
            
        }

        private void Buttonsave_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = this.Owner as MainWindow;
            Test test = new Test();
            test.Ask = Textboxask.Text;
            test.Firstask = Textbox1.Text;
            test.Secondask = Textbox2.Text;
            if (Check1.IsChecked==true)
            {
                test.Checkfirst = true;
            }
            if (Check2.IsChecked == true)
            {
                test.Checksecond = true;
            }
            if (Check3.IsChecked == true)
            {
                test.Checkthird = true;
            }
            if (Check4.IsChecked == true)
            {
                test.Checkfourth = true;
            }
            if (Check5.IsChecked == true)
            {
                test.Checkfifth = true;
            }

            /**/

            if (Textbox3.IsVisible==true)
            {
                test.Thirdask = Textbox3.Text;
            }
            if (Textbox4.IsVisible == true)
            {
                test.Fourthask = Textbox4.Text;
            }
            if (Textbox5.IsVisible == true)
            {
                test.Fifthask = Textbox5.Text;
            }

            listtests.Add(test);


                BinaryFormatter binform = new BinaryFormatter();
                using (var file = new FileStream("saved.bin", FileMode.OpenOrCreate))
                {
                    binform.Serialize(file, listtests);

                }
            MessageBox.Show("Збережено");

            Textboxask.Text = "";
            Textbox1.Text = "";
            Textbox2.Text = "";
            Textbox3.Text = "";
            Textbox4.Text = "";
            Textbox5.Text = "";

            Check1.IsChecked = false;
            Check2.IsChecked = false;
            Check3.IsChecked = false;
            Check4.IsChecked = false;
            Check5.IsChecked = false;

        }
        

        private void Buttonclear_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = this.Owner as MainWindow;
            Test test = new Test();
            Textboxask.Text = "";
            Textbox1.Text = "";
            Textbox2.Text = "";
            Textbox3.Text = "";
            Textbox4.Text = "";
            Textbox5.Text = "";

            counter = 3;

            Check1.IsChecked = false;
            Check2.IsChecked = false;
            Check3.IsChecked = false;
            Check4.IsChecked = false;
            Check5.IsChecked = false;


            /**/

            Textbox3.Visibility = Visibility.Hidden;
            Check3.Visibility = Visibility.Hidden;
           

            Check4.Visibility = Visibility.Hidden;
            Textbox4.Visibility = Visibility.Hidden;
           

            Check5.Visibility = Visibility.Hidden;
            Textbox5.Visibility = Visibility.Hidden;
           
            
        }
    }
}
