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
    public partial class WindowDelete : Window
    {
        public WindowDelete()
        {
            InitializeComponent();
        }
        public static int d_number;
        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            int check;
            if (int.TryParse(TbNumber.Text, out check))
            {
                if (Convert.ToInt32(TbNumber.Text) <= MainWindow.ArrFiguresLenth)
                {
                    DialogResult = true;
                    d_number = Convert.ToInt32(TbNumber.Text);
                }
                else
                {
                    MessageBox.Show("Неправильный номер, повторите ввод.");
                }
            }
            else
            {
                MessageBox.Show("Некорректный номер, повторите ввод.");
            }
        }

        private void BtExit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
