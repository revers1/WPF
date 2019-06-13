using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            List<My> listmy = new List<My>();
          
        ObservableCollection<My> observcol = new ObservableCollection<My>();
        private int currentgame = -1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
          
            My my = new My();
            my.name = TextboxName.Text;
            
            my.price = Convert.ToInt32(TextboxPrice.Text);//вопрос енам, и хмл как заблокировать выбор
            my.production = TextboxProduction.Text;
            my.ganre = ComboBoxGanre.Text;
            my.datetime = DatePickerdata.DisplayDate;


            if (RadiobuttonYes.IsChecked == true)
            {
                my.multiplayer = true;
            }
            else
                my.multiplayer = false;

            my.Rating = Sliderr.Value;


            if (Checkboxwindows.IsChecked==true)
            {     
                my.oss += " Windows ";              
            }
            if (Checkboxmac.IsChecked == true)
            {          
                my.oss += " Mac ";
            }
             if (Checkboxlinux.IsChecked == true)
            {             
                my.oss += " Linux ";
            }

            listmy.Add(my);


            if (radiobuttonbinary.IsChecked==true)
            {

                BinaryFormatter binform = new BinaryFormatter();
            using (var file = new FileStream("saved.bin", FileMode.OpenOrCreate))
            {
                binform.Serialize(file, listmy);
                   
                }

            }


            else if (radiobuttonxml.IsChecked==true)
            {

            XmlSerializer formatter = new XmlSerializer(typeof(List<My>));

                using (FileStream fs = new FileStream("savein.xml", FileMode.OpenOrCreate))
                {
                formatter.Serialize(fs, listmy);
                 
                }
            
            }







        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
           
            TextboxName.Text = "";
            TextboxPrice.Text = "";
            TextboxProduction.Text = "";
            ComboBoxGanre.SelectedItem = null;
            Sliderr.Value = 5;
            DatePickerdata.SelectedDate = null;
            //обнуление даты
            if (RadiobuttonNo.IsChecked==true||RadiobuttonYes.IsChecked==true)
            {
                RadiobuttonNo.IsChecked = false;
                RadiobuttonYes.IsChecked = false;
            }
         
                Checkboxwindows.IsChecked = false;

            Checkboxlinux.IsChecked = false;

            Checkboxmac.IsChecked = false;


        }

        private void Radiobuttonxml_Checked(object sender, RoutedEventArgs e)
        {
            radiobuttonxml.IsEnabled = false;
            radiobuttonbinary.IsEnabled = false;
        }

        private void Radiobuttonbinary_Checked(object sender, RoutedEventArgs e)
        {
            radiobuttonxml.IsEnabled = false;
            radiobuttonbinary.IsEnabled = false;
        }

        private void Buttonload_Click(object sender, RoutedEventArgs e)
        {
            if (radiobuttonbinary.IsChecked == true)
            {
                BinaryFormatter binform = new BinaryFormatter();
                using (FileStream file = new FileStream("saved.bin", FileMode.OpenOrCreate,FileAccess.Read))
                {
                    observcol= new ObservableCollection<My>((List<My>)binform.Deserialize(file));
                    this.DataContext = observcol[0];
                }

            }
           else if (radiobuttonxml.IsChecked==true)
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<My>));
                using (FileStream fs = new FileStream("savein.xml", FileMode.OpenOrCreate,FileAccess.Read))
                {
                   observcol =new ObservableCollection<My>( (List<My>)formatter.Deserialize(fs));

                    this.DataContext = observcol[0];
                }


            }

            grid.ItemsSource = listmy;

        }

        private void Buttonup_Click(object sender, RoutedEventArgs e)
        {
            if (currentgame == -1)
            {
                this.DataContext = listmy.FirstOrDefault();
                currentgame = 0;
            }
            else if (currentgame == 0)
            {
                this.DataContext = listmy.LastOrDefault();
                currentgame = listmy.Count - 1;
            }
            else
            {
                this.DataContext = listmy[currentgame-- - 1];
            }
        }

        private void Buttondown_Click(object sender, RoutedEventArgs e)
        {
            if (currentgame == -1 || currentgame == listmy.Count - 1)
            {
                this.DataContext = listmy.FirstOrDefault();
                currentgame = 0;
            }
            else
            {
                this.DataContext = listmy[++currentgame];
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }


    [Serializable]
    public class My
    {
     public  My() { }
       
       
        public string name { get; set; }
        public string ganre { get; set; }
        public string production { get; set; }
        public int price { get; set; }
        public DateTime datetime { get; set; }
        public double Rating { get; set; }
        public bool multiplayer { get; set; }
        public string oss { get; set; }
    public  My(string name, string ganre, string production, int price, DateTime datetime, double Rating, bool multiplayer, string oss)
        {
            this.name = name;
            this.ganre = ganre;
            this.production = production;
            this.price = price;
            this.datetime = datetime;
            this.Rating = Rating;
            this.multiplayer = multiplayer;
            this.oss = oss;
        }



    }
}
