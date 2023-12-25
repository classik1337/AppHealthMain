
using System;

using System.Windows.Controls;

using AppHealth.sdkPage.Health.PropHealth;

namespace AppHealth.sdkPage.Health
{
    /// <summary>
    /// Логика взаимодействия для PageHealth.xaml
    /// </summary>
    public partial class PageHealth : Page
    {
        public PageHealth()
        {
            InitializeComponent();
            randomPulse();
            string PageMainButton = "PropHealth/PageProperies.xaml";
            frameHealth.Source = new Uri(PageMainButton, UriKind.Relative);

        }
        
         public void randomPulse()
        {
            Random rnd = new Random();
            int pulse = rnd.Next(60, 110);
            int sleep = rnd.Next(3, 12);
            int fire = 24 - sleep;
            int ves = rnd.Next(55, 110);
            int rost = rnd.Next(130, 210);
            int go = rnd.Next(2000, 20000);


            pulseText.Text = pulse.ToString();
            fireText.Text = fire.ToString();
            vesText.Text = ves.ToString();
            rostText.Text = rost.ToString();
            goText.Text = go.ToString();
            sleepText.Text = sleep.ToString();
            PageProperies pageProperies = new PageProperies();
            pageProperies.pulseText.Text = pulse.ToString();
            pageProperies.sleepText.Text = sleep.ToString();
            pageProperies.fireText.Text = fire.ToString();
            pageProperies.goText.Text = go.ToString();


        }


    }
}
