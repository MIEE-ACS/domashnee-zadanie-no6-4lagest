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

namespace HomeWork6_Zakshevskij_UTS_22
{
    public partial class MainWindow : Window
    {
        public void PrintArrFigure(Figure[] ArrFigure)
        {
            MainLb.Content = "";
            for (int i = 0; i < ArrFigure.Length; i++)
            {
                MainLb.Content += String.Format("\n#{0} ", i+1) + ArrFigure[i].ToSrting();
            }
        }
        public Figure[] ArrFigures = new Figure[5];
        public static int ArrFiguresLenth = 5;
        public MainWindow()
        {
            InitializeComponent();
            NewArrFigure(ArrFigures);
            PrintArrFigure(ArrFigures);
        }
        public void NewArrFigure(Figure[] ArrFigure)
        {
            Random r = new Random();
            for (int i = 1; i <= ArrFigure.Length; i++)
            {
                if (i % 3 == 1)
                {
                    ArrFigure[i-1] = new Rectangle(r.Next(1,10), r.Next(1,10));
                }
                if (i % 3 == 2)
                {
                    ArrFigure[i-1] = new Circle(r.Next(1, 10));
                }
                if (i % 3 == 0)
                {
                    ArrFigure[i-1] = new Trapezoid(r.Next(1, 10), r.Next(1, 10), r.Next(1,10));
                }
            }
        }
        public abstract class Figure
        {
            protected string m_name="";
            public string name
            {
                set { m_name = value; }
                get { return m_name; }
            }
            protected double m_perimetr = 0;
            public double perimetr
            {
                set
                {
                    if (value < 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        m_perimetr = value;
                    }
                }
                get { return m_perimetr; }
            }
            protected double m_square = 0;
            public double square
            {
                set
                {
                    if (value < 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        m_square = value;
                    }
                }
                get {return m_square; }
            }
            private double m_hidth;
            private double m_width;
            public double hidth
            {
                set
                {
                    if (value < 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        m_hidth = value;
                    }
                }
                get { return m_hidth; }
            }
            public double width
            {
                set
                {
                    if (value < 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        m_width = value;
                    }
                }
                get { return m_width; }
            }
            private double m_radius;
            public double radius
            {
                set
                {
                    if (value < 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        m_radius = value;
                    }
                }
                get { return m_radius; }
            }
            private double m_high;
            public double high
            {
                set
                {
                    if (value < 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        m_high = value;
                    }
                }
                get { return m_high; }
            }
            private double m_fonthigh;
            public double fonthigh
            {
                set
                {
                    if (value < 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        m_fonthigh = value;
                    }
                }
                get { return m_fonthigh; }
            }
            public virtual double SetPerimetr()
            {
                return Math.Round((hidth + width)*2,2);
            }
            public virtual double SetSquare()
            {
                return Math.Round(hidth * width,2);
            }
            public virtual string ToSrting()
            {
                return String.Format("Название: {0} Высота: {1} Ширина: {2} Площадь: {3} Периметр: {4}", name, hidth, width, square, perimetr);
            }
            public virtual bool EqualsPerimetr (object obj)
            {
                return (obj as Figure).perimetr == perimetr;
            }
            public virtual bool EqualsSquare(object obj)
            {
                return (obj as Figure).square == square;
            }
        }
        public class Rectangle: Figure
        {
            public override bool EqualsPerimetr(object obj)
            {
                return (obj as Rectangle).perimetr == perimetr;
            }
            public override bool EqualsSquare(object obj)
            {
                return (obj as Rectangle).square == square;
            }
            public Rectangle(double c_width, double c_hidth)
            {
                try
                {
                    width = c_width;
                    hidth = c_hidth;
                    perimetr =SetPerimetr();
                    square = SetSquare();
                    name += "Прямоугольник";
                }
                catch (Exception)
                {
                    MessageBox.Show("Данные введены некорректно, повторите ввод");
                    high = 0;
                    hidth = 0;
                    perimetr = 0;
                    square = 0;
                }
            }
        }
        public class Circle: Figure
        {
            public override bool EqualsPerimetr(object obj)
            {
                return (obj as Circle).perimetr == perimetr;
            }
            public override bool EqualsSquare(object obj)
            {
                return (obj as Circle).square == square;
            }
            public override string ToSrting()
            {
                return String.Format("Название: {0} Радиус: {1} Площадь: {2} Длина окружности: {3}", name, radius, square, perimetr);
            }
            public override double SetPerimetr()
            {
                return Math.Round(2 * Math.PI * radius,2);
            }
            public override double SetSquare()
            {
                return Math.Round(Math.PI * radius * radius,2);
            }
            public Circle(double c_radius)
            {
                try
                {
                    radius = c_radius;
                    perimetr = SetPerimetr();
                    square = SetSquare();
                    name += "Круг";
                }
                catch (Exception)
                {
                    MessageBox.Show("Данные введены некорректно, повторите ввод");
                    radius = 0;
                    perimetr = 0;
                    square = 0;
                }
            }
        }
        public class Trapezoid: Figure
        {
            public override bool EqualsPerimetr(object obj)
            {
                return (obj as Trapezoid).perimetr == perimetr;
            }
            public override bool EqualsSquare(object obj)
            {
                return (obj as Trapezoid).square == square;
            }
            public override string ToSrting()
            {
                return String.Format("Название: {0} Верхнее основание: {1} Нижнее основание: {2} Боковая сторона: {3} Высота: {4} " +
                    "Площадь: {5} Длина окружности: {6}", name, hidth, width, fonthigh, high, square, perimetr);
            }
            public override double SetSquare()
            {
                return Math.Round(((hidth + width)/2) * high,2);
            }
            public override double SetPerimetr()
            {
                return Math.Round(hidth + width + fonthigh * 2,2);
            }
            public Trapezoid(double c_hidth, double c_width, double c_fonthigh)
            {
                try
                {
                    hidth = c_hidth;
                    high = Math.Round(Math.Sqrt(c_fonthigh * c_fonthigh - ((c_hidth - c_width) * (c_hidth - c_width)) / 2),2);
                    width = c_width;
                    fonthigh = c_fonthigh;
                    perimetr = SetPerimetr();
                    square = SetSquare();
                    name += "Трапеция";
                }
                catch (Exception)
                {
                    MessageBox.Show("Данные введены некорректно, повторите ввод");
                    high = 0;
                    hidth = 0;
                    width = 0;
                    fonthigh = 0;
                    perimetr = 0;
                    square = 0;
                }
            }
        }

        private void BtCreate_Click(object sender, RoutedEventArgs e)
        {
            Window Create = new WindowCreate();
            Create.ShowDialog();
            Create.Owner = this;
            if (Create.DialogResult == true)
            {
                if (WindowCreate.check == 0)
                {
                    Figure CreateFigure = new Circle(Convert.ToDouble(WindowCreate.cr_radius));
                    Array.Resize(ref ArrFigures, ArrFigures.Length + 1);
                    ArrFigures[ArrFigures.Length - 1] = CreateFigure;
                    PrintArrFigure(ArrFigures);
                    ArrFiguresLenth += 1;
                }
                else if (WindowCreate.check == 1)
                {
                    Figure CreateFigure = new Rectangle(Convert.ToDouble(WindowCreate.cr_hidth), Convert.ToDouble(WindowCreate.cr_width));
                    Array.Resize(ref ArrFigures, ArrFigures.Length + 1);
                    ArrFigures[ArrFigures.Length - 1] = CreateFigure;
                    PrintArrFigure(ArrFigures);
                    ArrFiguresLenth += 1;
                }
                else if (WindowCreate.check == 2)
                {
                    Figure CreateFigure = new Trapezoid(Convert.ToDouble(WindowCreate.cr_hidth), Convert.ToDouble(WindowCreate.cr_width), Convert.ToDouble(WindowCreate.cr_fonthigh));
                    Array.Resize(ref ArrFigures, ArrFigures.Length + 1);
                    ArrFigures[ArrFigures.Length - 1] = CreateFigure;
                    PrintArrFigure(ArrFigures);
                    ArrFiguresLenth += 1;
                }
            }
        }

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            Window Delete = new WindowDelete();
            Delete.ShowDialog();
            Delete.Owner = this;
            if (Delete.DialogResult == true)
            {
                int cucumber = WindowDelete.d_number;
                for (int i= cucumber-1; i < ArrFigures.Length-1; i++)
                {
                    ArrFigures[i] = ArrFigures[i + 1];
                }
                Array.Resize(ref ArrFigures, ArrFigures.Length - 1);
                PrintArrFigure(ArrFigures);
            }
        }
    }
}
