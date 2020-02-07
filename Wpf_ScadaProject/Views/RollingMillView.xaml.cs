﻿using System;
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

namespace Wpf_ScadaProject.Views
{
    /// <summary>
    /// Логика взаимодействия для RollingMillView.xaml
    /// </summary>
    public partial class RollingMillView : Window
    {
        public RollingMillView()
        {
            InitializeComponent();

            RollingStand01.upperRoll.Fill = new SolidColorBrush(Colors.Black);
            RollingStand01.lowerRoll.Fill = new SolidColorBrush(Colors.Red);
        }
        
        

    }
}
