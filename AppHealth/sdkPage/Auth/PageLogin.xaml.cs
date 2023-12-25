using Microsoft.Data.SqlClient;
using System;

using System.Data;

using System.Windows;
using System.Windows.Controls;

using System.Configuration;




namespace AppHealth.sdkPage.Auth
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);

            SqlCommand removeOldLogin = new SqlCommand("DELETE FROM [login]");
            removeOldLogin.Connection = connection;
            connection.Open();
            removeOldLogin.ExecuteReader();
            connection.Close();
        }
        private SqlConnection sqlConnection = null;




        class DB
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);

            public void openConnection()
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
            }

            public void closeConnection()
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

            public SqlConnection getConnection()
            {
                return connection;
            }
        }



        public static string Login { get; set; }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string login = TextLogin.Text;
            string password = TextPassword.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM [users] WHERE (login)= @uL AND (password) = @uP ", db.getConnection());
            adapter.SelectCommand = command;
            command.Parameters.Add("@uL", SqlDbType.VarChar).Value = login;
            command.Parameters.Add("@uP", SqlDbType.VarChar).Value = password;
            adapter.Fill(table);


            if (table.Rows.Count > 0 && login != null)
            {
                string Overide = "sdkPage/Overide/PageOveride.xaml";
                this.NavigationService.Navigate(new Uri(Overide, UriKind.Relative));
                Login = login;

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);



                SqlCommand addlogin = new SqlCommand("INSERT INTO [login] (login ) VALUES (@login)", db.getConnection());
                addlogin.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                addlogin.Connection = connection;
                connection.Open();
                addlogin.ExecuteNonQuery();
                connection.Close();










            }
            else
            {
                MessageBox.Show("Не правильный логин или пароль!");
            }

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            string Overide = "sdkPage/Auth/PageReg.xaml";
            this.NavigationService.Navigate(new Uri(Overide, UriKind.Relative));


        }
    }
}

