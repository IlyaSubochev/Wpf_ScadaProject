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
using Wpf_ScadaProject.ViewModels;

namespace Wpf_ScadaProject.Views
{
    /// <summary>
    /// Логика взаимодействия для RollingMillView.xaml
    /// </summary>
    public partial class RollingMillView : Window
    {
        public DependencyObject rollingMillView = new RollingMillView();
        public RollingMillViewModel RMViewModel { get; }
        public RollingMillView()
        {
            InitializeComponent();
            RMViewModel = new RollingMillViewModel();
            RollingMillViewShow();
            //RollingStand01.upperRoll.Fill = new SolidColorBrush(Colors.Black);
            //RollingStand01.lowerRoll.Fill = new SolidColorBrush(Colors.Red);
        }



        void RollingMillViewShow()
        {
            int count = 0;
            foreach (var item in RMViewModel.BackColorTM)
            {
                FindElement("RollingStand" + count, item);
                count += 1;
            }
        }
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        void FindElement(string name, byte item)
        {
            foreach (UserControl itemUC in FindVisualChildren<UserControl>(rollingMillView))
            {
                if (name == itemUC.Name)
                {
                    object currentEllipse = new Ellipse();
                    currentEllipse = itemUC.FindName("upperRoll");
                    switch (Convert.ToInt32(item))
                    {
                        case 0:
                            currentEllipse = new SolidColorBrush(Colors.Gray);
                            break;
                        case 1:
                            currentEllipse = new SolidColorBrush(Colors.Blue);
                            break;
                        case 2:
                            currentEllipse = new SolidColorBrush(Colors.AliceBlue);
                            break;
                        case 4:
                            currentEllipse = new SolidColorBrush(Colors.Green);
                            break;
                        case 8:
                            currentEllipse = new SolidColorBrush(Colors.Black);
                            break;
                        case 16:
                            currentEllipse = new SolidColorBrush(Colors.White);
                            break;
                        case 32:
                            currentEllipse = new SolidColorBrush(Colors.Yellow);
                            break;
                        case 64:
                            currentEllipse = new SolidColorBrush(Colors.Red);
                            break;
                        case 128:
                            currentEllipse = new SolidColorBrush(Colors.LightGray);
                            break;
                        default:
                            currentEllipse = new SolidColorBrush(Colors.Gray);
                            break;

                    }
                }
            }

        }
    }
}
