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

        void RollingStandItemColor(int number)
        {          
                switch (number)
                {
                    case 0:
                        Background = new SolidColorBrush(Colors.Gray);
                        break;
                    case 1:
                        Background = new SolidColorBrush(Colors.Blue);
                        break;
                    case 2:
                        Background = new SolidColorBrush(Colors.AliceBlue);
                        break;
                    case 4:
                        Background = new SolidColorBrush(Colors.Green);
                        break;
                    case 8:
                        Background = new SolidColorBrush(Colors.Black);
                        break;
                    case 16:
                        Background = new SolidColorBrush(Colors.White);
                        break;
                    case 32:
                        Background = new SolidColorBrush(Colors.Yellow);
                        break;
                    case 64:
                        Background = new SolidColorBrush(Colors.Red);
                        break;
                    case 128:
                        Background = new SolidColorBrush(Colors.LightGray);
                        break;
                    default:
                        Background = new SolidColorBrush(Colors.Gray);
                        break;                  
                }
            

        }
    }
}
