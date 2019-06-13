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
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        List<Test> listtests = new List<Test>();
        Test test = new Test();
       
        List<Test> checkontrues = new List<Test>();
        private int counter = 3;
        public int currenttest = -1;
        public int mark = 0;

        public Window4()
        {
            InitializeComponent();

            BinaryFormatter binform = new BinaryFormatter();
            using (FileStream file = new FileStream("saved.bin", FileMode.OpenOrCreate, FileAccess.Read))
            {
                listtests = ((List<Test>)binform.Deserialize(file));
                this.DataContext = listtests[0];
            }

           

        }

        private void buttonrightt_Click(object sender, RoutedEventArgs e)
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

        private void buttonleftt_Click(object sender, RoutedEventArgs e)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*Кнопка відповісти !*/

            test.Ask = Textboxask.Text;
            test.Firstask = Textbox1.Text;
            test.Secondask = Textbox2.Text;
            test.Thirdask = Textbox3.Text;
            test.Fourthask = Textbox4.Text;
            test.Fifthask = Textbox5.Text;
            if (Check11.IsChecked == true)
            {
                test.Checkfirst = true;
            }
            if (Check22.IsChecked == true)
            {
                test.Checksecond = true;
            }
            if (Check33.IsChecked == true)
            {
                test.Checkthird = true;
            }
            if (Check44.IsChecked == true)
            {
                test.Checkfourth = true;
            }
            if (Check55.IsChecked == true)
            {
                test.Checkfifth = true;
            }

            checkontrues.Add(test);


        }

        

        private void buttonfinishtest_Click(object sender, RoutedEventArgs e)
        {
            /*Проверка на чекбоксы (правильный ли ответ) */
            for (int i = 0; i < listtests.Count; i++)
            {
                //вылетает
                if (listtests[i].Checkfirst == true && checkontrues[i].Checkfirst == true)
                {
                    mark += 5;
                }
                if (listtests[i].Checksecond == true && checkontrues[i].Checksecond == true)
                {
                    mark += 5;
                }
                if (listtests[i].Checkthird == true && checkontrues[i].Checkthird == true)
                {
                    mark += 5;
                }
                if (listtests[i].Checkfourth == true && checkontrues[i].Checkfourth == true)
                {
                    mark += 5;
                }
                if (listtests[i].Checkfifth == true && checkontrues[i].Checkfifth == true)
                {
                    mark += 5;
                }


            }
          
            MessageBox.Show($"Your mark - {mark}");
           
            this.Close();
        }
    }
   
    
}
