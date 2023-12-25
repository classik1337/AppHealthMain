using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System;

namespace AppHealth.sdkPage.Auth
{
    /// <summary>
    /// Логика взаимодействия для PageReg.xaml
    /// </summary>
    public partial class PageReg : Page
    {
        public PageReg()
        {
            InitializeComponent();
        }
        private SqlConnection sqlConnection = null;
        int Admin = 1;
        int GoodUser = 2;
        int ShitUser = 3;


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string login = TextLogin.Text;
            string password = TextPassword.Text;

            SqlConnection connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);
            SqlCommand command = new SqlCommand("INSERT INTO [users] (login , password, role) VALUES (@login, @password, @role) ");
            command.Parameters.Add("@login", SqlDbType.VarChar).Value = TextLogin.Text;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = TextPassword.Text;
            command.Parameters.Add("@role", SqlDbType.VarChar).Value = ShitUser;
            command.Connection = connection1;
            connection1.Open();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт был создан");
                string Overide = "sdkPage/Auth/PageLogin.xaml";
                this.NavigationService.Navigate(new Uri(Overide, UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Аккаунт не был создан");
            }
            connection1.Close();

        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            string Overide = "sdkPage/Auth/PageLogin.xaml";
            this.NavigationService.Navigate(new Uri(Overide, UriKind.Relative));
        }
    }
}

