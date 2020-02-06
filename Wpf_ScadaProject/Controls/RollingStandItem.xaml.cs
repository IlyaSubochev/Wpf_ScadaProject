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

namespace Wpf_ScadaProject.Controls
{
    /// <summary>
    /// Логика взаимодействия для RollingStandItem.xaml
    /// </summary>
    public partial class RollingStandItem : UserControl
    {   
     
        public RollingStandItem()
        {
            InitializeComponent();
        }

        public Byte CurrentColor
        {
            get
            {
                return (Byte)GetValue(CurrentColorProperty);
            }
            set
            {
                SetValue(CurrentColorProperty, value);
            }
        }

        public static readonly DependencyProperty CurrentColorProperty =
            DependencyProperty.Register("CurrentColor", typeof(Byte), typeof(RollingStandItem),
                new UIPropertyMetadata(0), new ValidateValueCallback(ValidateCurrentColor));

        public static bool ValidateCurrentColor(object value)
        {
            if (Convert.ToInt32(value) >= 0 && Convert.ToInt32(value) <= 255)
                return true;
            else
                return false;
        }

        void RollingStandItemColor(string name, Byte CurrentColor)
        {
            
            object findEllipse = NameProperty;
            if (findEllipse is Ellipse)
            {
                Ellipse currentEllipse = findEllipse as Ellipse;

                switch (Convert.ToInt32(CurrentColor))
                {
                    case 0:
                        currentEllipse.Fill = new SolidColorBrush(Colors.Gray);
                        break;
                    case 1:
                        currentEllipse.Fill = new SolidColorBrush(Colors.Blue);
                        break;
                    case 2:
                        currentEllipse.Fill = new SolidColorBrush(Colors.AliceBlue);
                        break;
                    case 4:
                        currentEllipse.Fill = new SolidColorBrush(Colors.Green);
                        break;
                    case 8:
                        currentEllipse.Fill = new SolidColorBrush(Colors.Black);
                        break;
                    case 16:
                        currentEllipse.Fill = new SolidColorBrush(Colors.White);
                        break;
                    case 32:
                        currentEllipse.Fill = new SolidColorBrush(Colors.Yellow);
                        break;
                    case 64:
                        currentEllipse.Fill = new SolidColorBrush(Colors.Red);
                        break;
                    case 128:
                        currentEllipse.Fill = new SolidColorBrush(Colors.LightGray);
                        break;
                    default:
                        currentEllipse.Fill = new SolidColorBrush(Colors.Gray);
                        break;
                }
            }
            

        }
    }
}
