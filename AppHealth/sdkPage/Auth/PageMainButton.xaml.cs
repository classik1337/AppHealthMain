using System;

using System.Windows;
using System.Windows.Controls;


namespace AppHealth.sdkPage.Auth
{
    /// <summary>
    /// Логика взаимодействия для PageMainButton.xaml
    /// </summary>
    public partial class PageMainButton : Page
    {
        public PageMainButton()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Overide = "sdkPage/Auth/PageReg.xaml";
            this.NavigationService.Navigate(new Uri(Overide, UriKind.Relative));
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            string Overide = "sdkPage/Auth/PageLogin.xaml";
            this.NavigationService.Navigate(new Uri(Overide, UriKind.Relative));
        }
    }
}
