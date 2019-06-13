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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<Test> listtests = new List<Test>();
        private int counter = 3;
        public int currenttest = -1;
        Test test = new Test();
        public Window1()
        {
            InitializeComponent();
            
        }

        private void Buttonright_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Buttonleft_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
           
                BinaryFormatter binform = new BinaryFormatter();
                using (FileStream file = new FileStream("saved.bin", FileMode.OpenOrCreate, FileAccess.Read))
                {
                   listtests = (List < Test > )binform.Deserialize(file);
                    this.DataContext = listtests[0];
                }
            

            //grid.ItemsSource = listtests;
        }
    }
}
