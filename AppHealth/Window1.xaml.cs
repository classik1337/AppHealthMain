using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Configuration;
using System;


namespace AppHealth
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {


        //string Login = PageLogin.Login;



        public static string nameTable { get; set; }
        public static string surnameTable { get; set; }
        public static string ageTable { get; set; }
        public static string description { get; set; }
        public static string city { get; set; }
        public static string dateBirhday { get; set; }
        public string login = null;
        public static string Login { get; set; }


        public Window1()
        {
            
            InitializeComponent();
           
            string PageMainButton = "sdkPage/Auth/PageMainButton.xaml";
            string Overide = "sdkPage/Overide/PageOveride.xaml";
            frame1.Source = new Uri(PageMainButton, UriKind.Relative);
            
            for (int i = 0; i < 1; i++)
            {
                removeLog();
            }
            userLogin();
        }
       
        public void removeLog()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);
            SqlCommand removeOldLogin = new SqlCommand("DELETE FROM [login]");
            removeOldLogin.Connection = connection;
            connection.Open();
            removeOldLogin.ExecuteReader();
            connection.Close();
        }
        private void userLogin()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);
            SqlCommand command = new SqlCommand("SELECT login FROM [login] ");
            command.Connection = connection;
            connection.Open();
            using (SqlDataReader oReader = command.ExecuteReader())
            {

                while (oReader.Read())
                {
                    login = oReader["login"].ToString();

                }
                connection.Close();
            }
            mainLoginText.Text = login;
        }
        int RoleUser = 0;
        public string addtext(string Login)
        {
            
            SqlConnection connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);//Подключение бд к коду
            SqlCommand command2 = new SqlCommand("SELECT id_user,role FROM [users] WHERE (login)= @uL  ", connection1);//выборка id пользователя по логину входа
            command2.Parameters.Add("@uL", SqlDbType.VarChar).Value = Login;

            command2.Connection = connection1;
            connection1.Open();


            using (SqlDataReader oReader = command2.ExecuteReader())
            {
                int IdUser = 0;
                while (oReader.Read())
                {
                    string StringId = oReader["id_user"].ToString();
                    string StringRoleUser = oReader["role"].ToString();
                    IdUser = Int32.Parse(StringId);//получение id пользователя под переменной
                    RoleUser = Int32.Parse(StringRoleUser);
                }

                connection1.Close();


                SqlCommand command1 = new SqlCommand("SELECT name, surname, age FROM [full_users] where  (id_user)=@uIdUser", connection1);//получение строки с id---IdUser
                command1.Parameters.Add("@uIDUser", SqlDbType.VarChar).Value = IdUser;
                command1.Connection = connection1;


                string name_table = "";
                string surname_table = "";
                string age_table = "";

                connection1.Open();
                using (SqlDataReader oReader1 = command1.ExecuteReader())
                {
                    while (oReader1.Read())
                    {
                        name_table = oReader1["name"].ToString();
                        surname_table = oReader1["surname"].ToString();
                        age_table = oReader1["age"].ToString();
                    }
                }

                if (name_table.Length >= 1 || surname_table.Length >= 1 || age_table.Length >= 1)
                {
                    string InfoStatic = "sdkPage/Profile/PageInfoStatic.xaml";
                    frame1.Source = new Uri(InfoStatic, UriKind.Relative);
                    nameTable = name_table;
                    surnameTable = surname_table;
                    ageTable = age_table;
                    string a = "data";
                    return a ;
                    
                }
                else
                {
                    string InfoAdd = "sdkPage/Profile/PageInfoAdd.xaml";
                    frame1.Source = new Uri(InfoAdd, UriKind.Relative);

                    string b = "null";
                    return b;
                }
                connection1.Close();
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userLogin();
            Login = login;
            if (Login != null)
            {


                addtext(Login);

            }
            else
            {
                MessageBox.Show("Войдите в свой аккаунт!");
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Login = login;
            if (Login != null)
            {
                if (RoleUser <= 2)
                {
                    string Overide = "sdkPage/Overide/PageOveride.xaml";
                    frame1.Source = new Uri(Overide, UriKind.Relative);
                }
                else
                {
                    MessageBox.Show("Приобритете полную версию приложения!");
                    string Overide = "sdkPage/Contact/PageContact.xaml";
                    frame1.Source = new Uri(Overide, UriKind.Relative);
                }
            }
            else
            {
                MessageBox.Show("Войдите в свой аккаунт!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Login = login;
            if (Login != null)
            {
                if (RoleUser <= 2)
                {
                    string Overide = "sdkPage/MedCard/PageMedCard.xaml";
                    frame1.Source = new Uri(Overide, UriKind.Relative);
                }
                else
                {
                    MessageBox.Show("Приобритете полную версию приложения!");
                    string Overide = "sdkPage/Contact/PageContact.xaml";
                    frame1.Source = new Uri(Overide, UriKind.Relative);
                }
            }
            else
            {
                MessageBox.Show("Войдите в свой аккаунт!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Login = login;
            if (Login != null)
            {
                if (RoleUser <= 2)
                {
                    string Overide = "sdkPage/Health/PageHealth.xaml";
                    frame1.Source = new Uri(Overide, UriKind.Relative);
                }
                else
                {
                    MessageBox.Show("Приобритете полную версию приложения!");
                    string Overide = "sdkPage/Contact/PageContact.xaml";
                    frame1.Source = new Uri(Overide, UriKind.Relative);
                }
            }
            else
            {
                MessageBox.Show("Войдите в свой аккаунт!");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Login = login;
            if (Login != null)
            {
                if (RoleUser <= 2)
                {
                    string Overide = "sdkPage/Different/PageDifferent.xaml";
                    frame1.Source = new Uri(Overide, UriKind.Relative);
                }
                else
                {
                    MessageBox.Show("Приобритете полную версию приложения!");
                    string Overide = "sdkPage/Contact/PageContact.xaml";
                    frame1.Source = new Uri(Overide, UriKind.Relative);
                }
            }
            else
            {
                MessageBox.Show("Войдите в свой аккаунт!");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Login = login;
            if (Login != null)
            {
                string Overide = "sdkPage/Contact/PageContact.xaml";
                frame1.Source = new Uri(Overide, UriKind.Relative);
            }
            else
            {
                MessageBox.Show("Войдите в свой аккаунт!");
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            removeLog();
            string Overide = "sdkPage/Auth/PageMainButton.xaml";
            frame1.Source = new Uri(Overide, UriKind.Relative);

        }
    }
}


