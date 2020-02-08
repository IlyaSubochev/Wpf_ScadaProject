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
        public RollingMillView()
        {
            InitializeComponent();
            RMViewModel = new RollingMillViewModel();
            
            RollingStand01.upperRoll.Fill = new SolidColorBrush(Colors.Black);
            RollingStand01.lowerRoll.Fill = new SolidColorBrush(Colors.Red);
        }

        public RollingMillViewModel RMViewModel { get; }

        void Show()
        {
            foreach (var item in RMViewModel.BackColorTM)
            {
                
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

        void FindElement()
        {
            foreach (UserControl itemUC in FindVisualChildren<UserControl>(rollingMillView))
            {

            }
        }

    }
}
