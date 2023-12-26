﻿using System;
using System.Collections.Generic;
using System.Data;
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

namespace AppHealth.sdkPage.Health.PropHealth
{

    /// <summary>
    /// Логика взаимодействия для PageProperies.xaml
    /// </summary>
    public partial class PageProperies : Page
    {
        string Pulse = PageHealth.Pulse;
        string Fire = PageHealth.Fire;
        string Sleep = PageHealth.Sleep;
        string Go = PageHealth.Go;
        public PageProperies()
        {
            InitializeComponent();
            pulseText.Text = Pulse;
            fireText.Text = Fire;
            sleepText.Text = Sleep;
            goText.Text = Go;   
            
        }
    }
}
