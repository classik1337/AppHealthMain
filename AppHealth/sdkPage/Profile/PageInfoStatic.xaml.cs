
using Microsoft.Data.SqlClient;
using System;

using System.Windows;
using System.Windows.Controls;

using System.Configuration;

namespace AppHealth.sdkPage
{
    /// <summary>
    /// Логика взаимодействия для PageInfoStatic.xaml
    /// </summary>
    public partial class PageInfoStatic : Page
    {
        string nameTable = Window1.nameTable;
        string surnameTable = Window1.surnameTable;
        string ageTable = Window1.ageTable;
        string Login = Window1.Login;
        string description = Window1.description;
        string city = Window1.city;
        string dateBirthday = Window1.dateBirhday;


        public PageInfoStatic()
        {
            InitializeComponent();
            changeText();

        }
        public int RectangleArea(int a, int b)
        {
            return a * b;
        }
        void changeText()
        {
            loginText.Text = Login;
            nameText.Text = nameTable;
            surnameText.Text = surnameTable;
            ageText.Text = ageTable;
            descriptionText.Text = description;
            cityText.Text = city;
            dateText.Text = dateBirthday;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string InfoEdit = "sdkPage/Profile/PageInfoEdit.xaml";
            this.NavigationService.Navigate(new Uri(InfoEdit, UriKind.Relative));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);
            SqlCommand removeOldLogin = new SqlCommand("DELETE FROM [login]");
            removeOldLogin.Connection = connection;
            connection.Open();
            removeOldLogin.ExecuteReader();
            connection.Close();
            string Overide = "sdkPage/Auth/PageMainButton.xaml";
            this.NavigationService.Navigate(new Uri(Overide, UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string Overide = "sdkPage/Contact/PageContact.xaml";
            this.NavigationService.Navigate(new Uri(Overide, UriKind.Relative));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("У вас установленна последняя версия приложения от 20.12.2023!");
        }
    }
}
