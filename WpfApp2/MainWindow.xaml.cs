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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         
       
        /*-------------------*/
       public MainWindow()
        {
            InitializeComponent();
        }


        private void Teacher_Click(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2();
            win2.Owner = this;
            win2.ShowDialog();
            

        
        }
        private void Student_Click(object sender, RoutedEventArgs e)
        {
            Window4 win4 = new Window4();
            win4.Owner = this;
            win4.ShowDialog();
         
            
        }
    }
    [Serializable]
    public class Test
    {
        public Test() { }

        public string Ask { get; set; }
        public string Firstask { get; set; }
        public string Secondask { get; set; }
        public string Thirdask { get; set; }
        public string Fourthask { get; set; }
        public string Fifthask { get; set; }
        public bool Checkfirst { get; set; }
        public bool Checksecond { get; set; }
        public bool Checkthird { get; set; }
        public bool Checkfourth { get; set; }
        public bool Checkfifth { get; set; }



        public Test(string ask,string first,string second,string third,string fourth,string fifth,bool check1,bool check2, bool check3, bool check4, bool check5)
        {
            this.Ask = ask;
            this.Firstask = first;
            this.Secondask = second;
            this.Thirdask = third;
            this.Fourthask = fourth;
            this.Fifthask = fifth;
            this.Checkfirst = check1;
            this.Checksecond = check2;
            this.Checkthird = check3;
            this.Checkfourth = check4;
            this.Checkfifth = check5;
        }
        public Test(string ask, string first, string second, string third, string fourth, bool check1, bool check2, bool check3, bool check4)
        {
            this.Ask = ask;
            this.Firstask = first;
            this.Secondask = second;
            this.Thirdask = third;
            this.Fourthask = fourth;
            this.Checkfirst = check1;
            this.Checksecond = check2;
            this.Checkthird = check3;
            this.Checkfourth = check4;

        }
        public Test(string ask, string first, string second, string third, bool check1, bool check2, bool check3)
        {
            this.Ask = ask;
            this.Firstask = first;
            this.Secondask = second;
            this.Thirdask = third;
            this.Checkfirst = check1;
            this.Checksecond = check2;
            this.Checkthird = check3;

        }
        public Test(string ask, string first, string second, bool check1, bool check2)
        {
            this.Ask = ask;
            this.Firstask = first;
            this.Secondask = second;
            this.Checkfirst = check1;
            this.Checksecond = check2;


        }



    }

}
