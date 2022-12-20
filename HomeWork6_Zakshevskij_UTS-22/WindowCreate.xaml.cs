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

namespace HomeWork6_Zakshevskij_UTS_22
{
    public partial class WindowCreate : Window
    {
        public WindowCreate()
        {
            InitializeComponent();
        }
        public static int check = 0;
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int operation = Cb.SelectedIndex;
            switch(operation)
            {
                case 0:
                    check = 0;
                    Lb_1.Content = "";
                    Lb_2.Content = "";
                    Lb_3.Content = "";
                    Lb_1.Content += "Введите радиус";
                    Tb1.Visibility = Visibility.Visible;
                    Tb2.Visibility = Visibility.Collapsed;
                    Tb3.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    check = 1;
                    Lb_1.Content = "";
                    Lb_2.Content = "";
                    Lb_3.Content = "";
                    Lb_1.Content += "Введите высоту";
                    Lb_2.Content += "Введите ширину";
                    Tb1.Visibility = Visibility.Visible;
                    Tb2.Visibility = Visibility.Visible;
                    Tb3.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    check = 2;
                    Lb_1.Content = "";
                    Lb_2.Content = "";
                    Lb_3.Content = "";
                    Lb_1.Content += "Введите верхнее";
                    Lb_2.Content += "Введите нижнее";
                    Lb_3.Content += "Введите боковую";
                    Tb1.Visibility = Visibility.Visible;
                    Tb2.Visibility = Visibility.Visible;
                    Tb3.Visibility = Visibility.Visible;
                    break;
            }   
        }
        public static int cr_hidth;
        public static int cr_width;
        public static int cr_radius;
        public static int cr_fonthigh;
        public static int cr_high;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int R;
            if (check ==0)
            {
                if (int.TryParse(Tb1.Text, out R))
                {
                    cr_radius = Convert.ToInt32(Tb1.Text);
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Напрвильно введён радиус, повторите ввод");
                }
            }
            else if (check == 1)
            {
                if ((int.TryParse(Tb1.Text, out R))&&(int.TryParse(Tb2.Text, out R)))
                {
                    cr_hidth = Convert.ToInt32(Tb1.Text);
                    cr_width = Convert.ToInt32(Tb2.Text);
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Напрвильно введёны высота или ширина, повторите ввод");
                }
            }
            else if (check == 2)
            {
                if ((int.TryParse(Tb1.Text, out R)) && (int.TryParse(Tb2.Text, out R))&& (int.TryParse(Tb3.Text, out R)))
                {
                    cr_hidth = Convert.ToInt32(Tb1.Text);
                    cr_width = Convert.ToInt32(Tb2.Text);
                    cr_fonthigh = Convert.ToInt32(Tb3.Text);
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Напрвильно введёны верхнее, боковое или нижнее, повторите ввод");  
                }
                
            }
        }

        private void BtExit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
